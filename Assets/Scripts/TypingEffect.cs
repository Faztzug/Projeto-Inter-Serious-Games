using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypingEffect : MonoBehaviour
{
    
    private float textTypingSpeed;
    private TextMeshProUGUI dialogueTextMeshPro;
    private TextBoxDialogue textBox;

    

    private void Start()
    {
        textTypingSpeed = FindObjectOfType<EstadoDeMundo>().textTypingSpeed;
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

        //textBox.Activate();

        dialogueTextMeshPro.text = "";
        foreach (char letter in sentence.ToCharArray())
        {

            yield return new WaitForSeconds(0.5f / (textTypingSpeed + 5));
            dialogueTextMeshPro.text += letter;
        }
    }
}
