using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGameButton : MonoBehaviour
{
    [SerializeField] private string cena;
    [SerializeField] private GameObject caseSensetive;
    private EstadoDeMundo estado;
    private LoadSceneOnClick loadOnClick;
    private NewGame newGame;

    private void Start()
    {
        estado = FindObjectOfType<EstadoDeMundo>();
        loadOnClick = GetComponent<LoadSceneOnClick>();
        newGame = GetComponent<NewGame>();
        caseSensetive.SetActive(false);
    }

    public void CaseSensentive()
    {
        if(estado.ChecarSeSaveExiste() == true)
        {
            caseSensetive.SetActive(true);
        } else
        {
            //loadOnClick.LoadScene(cena);
            newGame.LoadScene(cena);
        }
    }
}
