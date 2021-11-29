using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapPosition : MonoBehaviour
{

    [SerializeField] private Transform playerPositionIcon;

    [SerializeField] private Transform Lab;
    [SerializeField] private Transform Centro;
    [SerializeField] private Transform SalaControle;
    [SerializeField] private Transform Governo;

    [SerializeField] private Transform Comercial;
    [SerializeField] private Transform Fazenda;

    [SerializeField] private Transform Maquinas;
    [SerializeField] private Transform Hidreletrica;
    [SerializeField] private Transform Rio;

    [SerializeField] private Transform Exaustores;
    [SerializeField] private Transform Savana;
    [SerializeField] private Transform Floresta;

    [SerializeField] private Transform ForaDoMapa;



    [SerializeField] private string lab1Cena;
    [SerializeField] private string lab2Cena;

    [SerializeField] private string centro1Cena;
    [SerializeField] private string centro2Cena;

    [SerializeField] private string governoFrenteCena;
    [SerializeField] private string governoDentroCena;

    [SerializeField] private string salaControle1Cena;
    [SerializeField] private string salaControle2Cena;
    [SerializeField] private string salaControle3Cena;

    [SerializeField] private string floresta1Cena;
    [SerializeField] private string floresta2Cena;
    [SerializeField] private string floresta3Cena;

    [SerializeField] private string maquinasCena;
    [SerializeField] private string exaustoresCena;
    [SerializeField] private string hidreletricaCena;
    [SerializeField] private string rioCena;
    [SerializeField] private string savanaCena;
    [SerializeField] private string comercialCena;
    [SerializeField] private string fazendaCena;


    private EstadoDeMundo estado;
    

    private void Start()
    {
        //estado = FindObjectOfType<EstadoDeMundo>();
        Atualizar();
        gameObject.transform.parent.gameObject.SetActive(false);
    }

    public void Atualizar()
    {
        estado = FindObjectOfType<EstadoDeMundo>();
        string currentScene = Camera.main.gameObject.scene.name;

        if (currentScene == lab1Cena 
            || currentScene == lab2Cena)
        {
            playerPositionIcon.position = Lab.position;
        } 
        else if (currentScene == floresta1Cena 
            || currentScene == floresta2Cena
            || currentScene == floresta3Cena)
        {
            playerPositionIcon.position = Floresta.position;
        }
        else if (currentScene == governoFrenteCena 
            || currentScene == governoDentroCena)
        {
            playerPositionIcon.position = Governo.position;
        }
        else if (currentScene == centro1Cena
            || currentScene == centro2Cena)
        {
            playerPositionIcon.position = Centro.position;
        }
        else if (currentScene == salaControle1Cena
            || currentScene == salaControle2Cena
            || currentScene == salaControle3Cena)
        {
            playerPositionIcon.position = SalaControle.position;
        }
        else if (currentScene == exaustoresCena)
        {
            playerPositionIcon.position = Exaustores.position;
        }
        else if (currentScene == maquinasCena)
        {
            playerPositionIcon.position = Maquinas.position;
        }
        else if (currentScene == comercialCena)
        {
            playerPositionIcon.position = Comercial.position;
        }
        else if (currentScene == fazendaCena)
        {
            playerPositionIcon.position = Fazenda.position;
        }
        else if (currentScene == rioCena)
        {
            playerPositionIcon.position = Rio.position;
        }
        else if (currentScene == hidreletricaCena)
        {
            playerPositionIcon.position = Hidreletrica.position;
        }
        else if (currentScene == savanaCena)
        {
            playerPositionIcon.position = Savana.position;
        }
        else
        {
            playerPositionIcon.position = ForaDoMapa.position;
        }

    }

}
