using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrocarCena : MonoBehaviour
{
    [SerializeField] private Vector2 novaPosicao;
    [SerializeField] private string carregarCena;
    //[HideInInspector] public bool iniciarTransisao = false;
    private Animator crossfadeTransition;
    [SerializeField] private float tempoDeCrossfade = 1f;

    private void Start()
    {
        crossfadeTransition = FindObjectOfType<Canvas>().GetComponent<Animator>();
        
    }


    public void CarregarCena()
    {
        StartCoroutine(IniciarCrossfade());    
    }

    IEnumerator IniciarCrossfade()
    {
        crossfadeTransition.SetTrigger("Start");
        yield return new WaitForSeconds(tempoDeCrossfade);

        SceneManager.LoadScene(carregarCena);
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        player.GetComponent<PlayerControl>().touchPosition = novaPosicao;
        player.transform.position = novaPosicao;
        crossfadeTransition.SetTrigger("End");
    }

    



    
}
