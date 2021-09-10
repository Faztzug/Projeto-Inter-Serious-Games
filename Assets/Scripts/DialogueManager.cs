using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    private int startSentence;
    private int finalSentence;
    private DialogueTrigger dialogueTrigger;
    private bool dialogoIniciado = false;
    private TextMeshProUGUI dialogueTextMeshPro;
    
    public int numberSentences;
    private int currentSentence = 0;
    private Dialogue dialogueData;
    
    [SerializeField]
    private float textTypingSpeed = 0.01f;

    

    private void Start()
    {
        dialogueTrigger = GetComponent<DialogueTrigger>();
        
        dialogueData = GetComponent<DialogueData>().dialogue;
        numberSentences = dialogueData.sentences.Length;
        
        
        dialogueTextMeshPro = FindObjectOfType<TextMeshProUGUI>();
        
    }

    public void StartingDialogue(int startSentence, int finalSentence)
    {
        this.startSentence = startSentence;
        this.finalSentence = finalSentence;
        currentSentence = startSentence;
        NextSentence();
    }

    public void NextSentence()
    {
        

        StopAllCoroutines();
        dialogueTextMeshPro.color = dialogueData.textColor;

        //coloca o texto na mesma posição do personagem
        dialogueTextMeshPro.transform.position = Camera.main.WorldToScreenPoint(transform.position);

        //e então altera a posição do texto em + textPosition
        //Todavia eu não sei ao certo o que este "Viewport" faz,
        //mas ele mantém a posição do objeto constante independente da reslução da tela
        //Utilizar o metodo WorldToScreenPoint junto com o translate mandava
        //a caixa de texto para fora do canvas
        //porém anote o valor em float, sempre abaixo de 1, como 0.1f
        //senão irá mandar o objeto para fora da tela
        dialogueTextMeshPro.transform.Translate(Camera.main.ViewportToScreenPoint(dialogueData.textPosition));

        if (currentSentence < numberSentences && currentSentence <= finalSentence)
        {
            
            dialogueTextMeshPro.text = dialogueData.sentences[currentSentence];
            StartCoroutine(TypingSentence(dialogueData.sentences[currentSentence]));
            currentSentence++;
        }else if(currentSentence >= numberSentences || currentSentence >= finalSentence)
        {
            dialogueTrigger.EndOfDialogue(currentSentence, dialogueData.characterName);

            dialogueTextMeshPro.text = "";
            
            currentSentence = 0;
            
            dialogoIniciado = false;
        }
    }

    IEnumerator TypingSentence(string sentence)
    {
        
        dialogueTextMeshPro.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            
            dialogueTextMeshPro.text += letter;
            yield return new WaitForSeconds(textTypingSpeed);
        }
    }
}
