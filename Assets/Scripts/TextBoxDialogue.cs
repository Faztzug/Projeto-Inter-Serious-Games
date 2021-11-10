using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextBoxDialogue : MonoBehaviour
{
    [HideInInspector] public Image box;
    [HideInInspector] public TextMeshProUGUI nome;
    [SerializeField] private CanvasGroup group;
    public bool ativa;
    private TextBoxPortraitsManager spritesManager;


    private void Start()
    {
        box = GetComponent<Image>();
        nome = transform.Find("Nome").GetComponent<TextMeshProUGUI>();
        group = this.gameObject.GetComponentInParent<CanvasGroup>();
        spritesManager = FindObjectOfType<TextBoxPortraitsManager>();
        Debug.Log("Deactivated TextBox on Start");
        Deactivate();
    }

    /*private void Update()
    {
        if (ativa == true)
            group.alpha = 1;
        else if (ativa == false)
            group.alpha = 0;
    }*/

    public void Activate()
    {
        Debug.Log("Text Box Activated!");
        group.alpha = 1;
        //gameObject.SetActive(true);
        ativa = true;
    }

    public void Deactivate()
    {
        Debug.Log("Text Box Deactivated!");
        group.alpha = 0;
        //gameObject.SetActive(false);
        ativa = false;
        //spritesManager.TirarImagem();
    }

    public void AtualizarSprite()
    {
        spritesManager.TrocarSprite(nome.text);
    }
}
