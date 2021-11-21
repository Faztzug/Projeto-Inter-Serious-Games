using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGame : MonoBehaviour
{
    private CrossfadeLoadEffect crossfade;
    private EstadoDeMundo estadoDeMundo;
    private Save newGameSave;
    [SerializeField]
    private float taxDeAtualizacao = 0.1f;
    [SerializeField]
    private GameObject rootGameObject;
    private void Start()
    {
        estadoDeMundo = FindObjectOfType<EstadoDeMundo>();
        newGameSave = estadoDeMundo.save;

    }

    public void LoadScene(string sceneName)
    {
        DontDestroyOnLoad(this.transform.root.gameObject);
        crossfade = FindObjectOfType<CrossfadeLoadEffect>();
        crossfade.ChamarCrossfade(sceneName, Vector2.zero);

        StartCoroutine(ProcurarPlayer());
    }

    IEnumerator ProcurarPlayer()
    {
        yield return new WaitForSeconds(taxDeAtualizacao);

        if(GameObject.FindGameObjectWithTag("Player") != null)
        {
            GameObject.FindGameObjectWithTag("Player")
                .GetComponent<EstadoDeMundo>().save = newGameSave;
            this.transform.root.gameObject.SetActive(false);
            Destroy(this.transform.root.gameObject);
        }
        else
        {
            StartCoroutine(ProcurarPlayer());
        }
        
    }
}
