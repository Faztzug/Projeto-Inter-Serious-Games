using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerPlayer : DialogueTrigger
{
    private AnswerManager answerManager;
    private DialogueData dialogueData;
    private DialogueResponses dialogueResponses;
    private string[] responses;
    private string[] sentences;
    private string NPCPerguntando;

    private void Awake()
    {
        answerManager = FindObjectOfType<AnswerManager>();
        dialogueData = GetComponent<DialogueData>();
        dialogueResponses = GetComponent<DialogueResponses>();
        sentences = dialogueData.dialogue.sentences;
        responses = dialogueResponses.Responses;
    }
    public void MomentoDeResponder(int sentence, string NPCname)
    {
        NPCPerguntando = NPCname;
        if(NPCname == "Esfera Circular Arrendondada Com Circuferencia"
            && sentence == 7)
        {
            answerManager.GerarRespostas(responses[0]);
            answerManager.GerarRespostas(responses[1]);

        }
    }

    public void RespostaSelecionada(string resposta)
    {
        if(NPCPerguntando == "Esfera Circular Arrendondada Com Circuferencia"
            && resposta == "Sim")
        {
            FindObjectOfType<DialogueTriggerEsferaTeste>().StartDialogue(7, 7);
        } else if (NPCPerguntando == "Esfera Circular Arrendondada Com Circuferencia"
            && resposta == "Não")
        {
            FindObjectOfType<DialogueTriggerEsferaTeste>().StartDialogue(8, 8);
        }
    }
}
