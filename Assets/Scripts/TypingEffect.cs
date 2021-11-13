using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypingEffect : MonoBehaviour
{
    
    [HideInInspector] public float textTypingSpeed;
    private TextMeshProUGUI dialogueTextMeshPro;
    private TextBoxDialogue textBox;

    

    private void Start()
    {
        textTypingSpeed = FindObjectOfType<EstadoDeMundo>().save.textTypingSpeed;
        dialogueTextMeshPro = GetComponent<TextMeshProUGUI>();
        textBox = gameObject.GetComponentInParent<TextBoxDialogue>();
    }


    public void CallTyping(string sentence)
    {
        
        
        StartCoroutine(TypingSentence(sentence));       
    }

    IEnumerator TypingSentence(string sentence)
    {
        Debug.Log("Start Typing: "+sentence);

        textBox.AtualizarSprite();

        dialogueTextMeshPro.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            textBox.Activate();
            yield return new WaitForSeconds(0.5f / (textTypingSpeed + 5));
            dialogueTextMeshPro.text += letter;
        }
    }
}
