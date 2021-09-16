using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypingEffect : MonoBehaviour
{
    
    private float textTypingSpeed;
    private TextMeshProUGUI dialogueTextMeshPro;

    

    private void Start()
    {
        textTypingSpeed = FindObjectOfType<EstadoDeMundo>().textTypingSpeed;
        dialogueTextMeshPro = GetComponent<TextMeshProUGUI>();
    }


    public void CallTyping(string sentence)
    {
        
        
        StartCoroutine(TypingSentence(sentence));       
    }

    IEnumerator TypingSentence(string sentence)
    {

        dialogueTextMeshPro.text = "";
        foreach (char letter in sentence.ToCharArray())
        {

            dialogueTextMeshPro.text += letter;
            yield return new WaitForSeconds(0.5f / (textTypingSpeed + 5));
        }
    }
}
