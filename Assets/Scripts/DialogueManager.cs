﻿using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    private int startSentence;
    private int finalSentence;
    private DialogueTrigger dialogueTrigger;

    [HideInInspector]
    public int numberSentences;

    private int currentSentence = 0;
    private Dialogue dialogueData;

    private TextMeshProUGUI dialogueTextMeshPro;
    private TypingEffect typingEffect;

    private PlayerControl playerControl;
    private bool NextSentenceFirstCall;

    private EstadoDeMundo estadoDeMundo;

    private void Start()
    {
        NextSentenceFirstCall = true;
        typingEffect = FindObjectOfType<TypingEffect>();
        dialogueTextMeshPro = typingEffect.gameObject.GetComponent<TextMeshProUGUI>();

        dialogueTrigger = GetComponent<DialogueTrigger>();

        dialogueData = GetComponent<DialogueData>().dialogue;
        numberSentences = dialogueData.sentences.Length;

        playerControl = FindObjectOfType<PlayerControl>();
        estadoDeMundo = playerControl.gameObject.GetComponent<EstadoDeMundo>();
    }

    public void StartingDialogue(int startSentence, int finalSentence)
    {
        playerControl.emDialogo = true;
        playerControl.andando = false;
        playerControl.NPCfalando = this;
        this.startSentence = startSentence;
        this.finalSentence = finalSentence;
        currentSentence = startSentence;
        NextSentence();
    }

    public void NextSentence()
    {
        typingEffect.StopAllCoroutines();
        
        if (NextSentenceFirstCall == true
            || dialogueTextMeshPro.text == dialogueData.sentences[currentSentence]) //-1
        {
            
            dialogueTextMeshPro.color = dialogueData.textColor;

            //coloca o texto na mesma posição do personagem
            dialogueTextMeshPro.transform.position = Camera.main.WorldToScreenPoint(transform.position);

            //e então altera a posição do texto em + textPosition
            dialogueTextMeshPro.transform.Translate(Camera.main.ViewportToScreenPoint(dialogueData.textPosition));

            //checagem se o texto está fora da tela, e correção de posição
            TextBoxRearrange();


            if (dialogueTextMeshPro.text == dialogueData.sentences[currentSentence])
            {
                currentSentence++;
            }

            if (currentSentence < numberSentences && currentSentence <= finalSentence)
            {
                Debug.Log("FirstCall: " + currentSentence + dialogueData.sentences[currentSentence]);
                typingEffect.CallTyping(dialogueData.sentences[currentSentence]);
                NextSentenceFirstCall = false;
            }
            else if (currentSentence >= numberSentences || currentSentence >= finalSentence)
            {
                dialogueTrigger.EndOfDialogue(currentSentence, dialogueData.characterName);

                dialogueTextMeshPro.text = "";

                currentSentence = 0;
                NextSentenceFirstCall = true;
            }
            
        }
        else if (dialogueTextMeshPro.text != dialogueData.sentences[currentSentence] //-1
          && NextSentenceFirstCall == false)
        {
            Debug.Log("SecondCall: " + currentSentence + dialogueData.sentences[currentSentence]);
            dialogueTextMeshPro.text = dialogueData.sentences[currentSentence]; //-1
            NextSentenceFirstCall = true;
        }
    }

    public void TextBoxRearrange()
    {
        Vector2 textViewPortPosition = Camera.main.ScreenToViewportPoint(dialogueTextMeshPro.transform.position);
        Debug.Log(textViewPortPosition);

        if (textViewPortPosition.y > estadoDeMundo.textBoxBoundsY)
        {
            
            dialogueTextMeshPro.transform.position = 
                Camera.main.ViewportToScreenPoint
                (new Vector2(textViewPortPosition.x, estadoDeMundo.textBoxBoundsY));
            Debug.Log(textViewPortPosition);
        }

        if (textViewPortPosition.x > estadoDeMundo.textBoxBoundsX)
        {

            dialogueTextMeshPro.transform.position =
                Camera.main.ViewportToScreenPoint
                (new Vector2(estadoDeMundo.textBoxBoundsX, textViewPortPosition.y));
            Debug.Log(textViewPortPosition);
        }

        if (textViewPortPosition.x < 1-estadoDeMundo.textBoxBoundsX)
        {

            dialogueTextMeshPro.transform.position =
                Camera.main.ViewportToScreenPoint
                (new Vector2(1-estadoDeMundo.textBoxBoundsX, textViewPortPosition.y));
            Debug.Log(textViewPortPosition);
        }



    }
}