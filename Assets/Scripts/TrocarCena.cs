using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;

public class TrocarCena : MonoBehaviour
{
    [SerializeField] private Vector2 novaPosicao;
    [SerializeField] private string carregarCena;
    //[HideInInspector] public bool iniciarTransisao = false;
    
    //[SerializeField] private float tempoDeCrossfade = 1f;

    private CrossfadeLoadEffect crossfade;

    private void Start()
    {
        crossfade = FindObjectOfType<CrossfadeLoadEffect>();
        
    }


    public void CarregarCena()
    {
        crossfade.ChamarCrossfade(carregarCena, novaPosicao);    
    }

    

    



    
}
