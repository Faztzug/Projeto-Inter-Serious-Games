using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContinueButton : MonoBehaviour
{
    private EstadoDeMundo estado;
    private Button button;
    private Image buttonImg;
    [SerializeField] private Color corBotaoDesativo;

    void Start()
    {
        estado = FindObjectOfType<EstadoDeMundo>();
        button = GetComponent<Button>();
        buttonImg = GetComponent<Image>();

        if (estado.ChecarSeSaveExiste() == false)
        {
            button.interactable = false;
            //buttonImg.raycastTarget = false;
            //buttonImg.color = corBotaoDesativo;
            //this.gameObject.SetActive(false);
        }
    }

    
}
