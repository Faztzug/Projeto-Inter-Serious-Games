using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextBoxDialogue : MonoBehaviour
{
    [HideInInspector] public Image box;
    [HideInInspector] public TextMeshProUGUI nome;

    private void Start()
    {
        box = GetComponent<Image>();
        nome = transform.Find("Nome").GetComponent<TextMeshProUGUI>();
    }
}
