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
    private int ultimaSentenca;

    private void Awake()
    {
        answerManager = FindObjectOfType<AnswerManager>();
        dialogueData = GetComponent<DialogueData>();
        dialogueResponses = GetComponent<DialogueResponses>();
        sentences = dialogueData.dialogue.sentences;
        responses = dialogueResponses.Responses;
    }

    public override void EndOfDialogue(int lastSentence, string NPCname)
    {      
        base.EndOfDialogue(lastSentence, NPCname);
        
        if (lastSentence == 4)
        {
            FindObjectOfType<DTGovernandor>().GetComponentInParent<FazerAndar>().AndePara(new Vector2(-7.2f, -2.3f));
            Debug.Log("Last Sentence 4");
        }
        else if (lastSentence == 6)
            FindObjectOfType<DTEmpresarioRuim>().StartDialogue(2,5);
        else if(lastSentence == 7)
            FindObjectOfType<DTEmpresarioRuim>().StartDialogue(6, 6);
        else if (lastSentence == 8)
            FindObjectOfType<DialogueTriggerAssistente>().StartDialogue(5, 8);
        else if(lastSentence == 10)
            FindObjectOfType<DialogueTriggerAssistente>().StartDialogue(9, 9);
        else if(lastSentence == 19)
        {
            MomentoDeResponder(lastSentence, dialogueData.name);
            answerManager.GerarRespostas(responses[0]);
            answerManager.GerarRespostas(responses[1]);
        }
        else if (lastSentence == 20)
        {
            MomentoDeResponder(lastSentence, dialogueData.name);
            answerManager.GerarRespostas(responses[0]);
            answerManager.GerarRespostas(responses[1]);
        }

    }

    public void MomentoDeResponder(int sentence, string NPCname)
    {
        ultimaSentenca = sentence;

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

        if (NPCPerguntando == dialogueData.name
            && resposta == "Sim" && ultimaSentenca == 19)
        {
            estadoDeMundo.relacaoEmpresarioRuim++;
            StartDialogue(19, 19);
        }
        else if (NPCPerguntando == dialogueData.name
          && resposta == "Não" && ultimaSentenca == 19)
        {
            estadoDeMundo.relacaoEmpresarioRuim--;
            StartDialogue(19, 19);
        }


        if (NPCPerguntando == dialogueData.name
            && resposta == "Sim" && ultimaSentenca == 20)
        {
            estadoDeMundo.relacaoFazendeiro++;
            StartDialogue(20, 20);
        }
        else if (NPCPerguntando == dialogueData.name
          && resposta == "Não" && ultimaSentenca == 20)
        {
            estadoDeMundo.relacaoFazendeiro--;
            StartDialogue(20, 20);
        }
    }
}
