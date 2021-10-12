using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextBoxDialogue : MonoBehaviour
{
    [HideInInspector] public Image box;
    [HideInInspector] public TextMeshProUGUI nome;
    private CanvasGroup group;

    private void Start()
    {
        box = GetComponent<Image>();
        nome = transform.Find("Nome").GetComponent<TextMeshProUGUI>();
        group = GetComponent<CanvasGroup>();
    }

    public void Activate()
    {
        Debug.Log("Text Box Activated!");
        group.alpha = 1;
        //gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        Debug.Log("Text Box Deactivated!");
        group.alpha = 0;
        //gameObject.SetActive(false);
    }
}
