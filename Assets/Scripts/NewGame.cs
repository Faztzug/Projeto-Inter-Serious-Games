using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGame : MonoBehaviour
{
    private CrossfadeLoadEffect crossfade;
    [SerializeField]
    private EstadoDeMundo estadoDeMundo;
    private Save newGameSave;
    [SerializeField]
    private float taxDeAtualizacao = 0.1f;
    [SerializeField]
    private GameObject BlackScreen;
    private string cenaQueFoiCarregada;
    private void Start()
    {
        estadoDeMundo = FindObjectOfType<EstadoDeMundo>();
        newGameSave = estadoDeMundo.save;

    }

    public void LoadScene(string sceneName)
    {
        cenaQueFoiCarregada = sceneName;
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
            Instantiate(BlackScreen);

            GameObject player;
            Debug.Log("Save state set to New Game!");
            player = GameObject.FindGameObjectWithTag("Player");
                player.GetComponent<EstadoDeMundo>().save = newGameSave;

            FindObjectOfType<CrossfadeLoadEffect>().ChamarCrossfade(cenaQueFoiCarregada, player.transform.position);
            this.transform.root.gameObject.SetActive(false);
            Destroy(this.transform.root.gameObject);
        }
        else
        {
            StartCoroutine(ProcurarPlayer());
        }
        
    }
}
