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
            FindObjectOfType<DTGovernandor>().GetComponentInParent<FazerAndar>().AndePara(new Vector2(-6.5f, -2.3f));
            Debug.Log("Last Sentence 4");
        }
        else if (lastSentence == 6)
            FindObjectOfType<DTEmpresarioRuim>().StartDialogue(2, 5);
        else if (lastSentence == 7)
            FindObjectOfType<DTEmpresarioRuim>().StartDialogue(6, 6);
        else if (lastSentence == 8)
            FindObjectOfType<DialogueTriggerAssistente>().StartDialogue(5, 8);
        else if (lastSentence == 10)
            FindObjectOfType<DialogueTriggerAssistente>().StartDialogue(9, 9);
        else if (lastSentence == 17)
        {
            MomentoDeResponder(lastSentence, dialogueData.name);
            answerManager.GerarRespostas(responses[2]);
            answerManager.GerarRespostas(responses[3]);
        }
        else if (lastSentence == 18)
        {
            MomentoDeResponder(lastSentence, dialogueData.name);
            answerManager.GerarRespostas(responses[4]);
            answerManager.GerarRespostas(responses[5]);
        }
        else if (lastSentence == 19)
            FindObjectOfType<FimDeTurno>().EncerrarTurno();

        if(estadoDeMundo.save.turno == 2)
        {
            if (lastSentence == 20)
                FindObjectOfType<DialogueTriggerAssistente>().StartDialogue(26, 26);
            else if (lastSentence == 21)
                FindObjectOfType<DTEmpresarioRuim>().StartDialogue(8, 9);
            else if(lastSentence == 22)
                FindObjectOfType<DTEmpresarioRuim>().StartDialogue(10, 10);
            else if (lastSentence == 23)
                FindObjectOfType<DTEmpresarioRuim>().StartDialogue(11, 11);
            else if (lastSentence == 24)
                FindObjectOfType<DTEmpresarioRuim>().StartDialogue(12, 15);
            else if (lastSentence == 25)
                FindObjectOfType<DTEmpresarioRuim>().StartDialogue(16, 16);
            if (lastSentence == 26)
                FindObjectOfType<DialogueTriggerAssistente>().StartDialogue(32, 32);
            if (lastSentence == 27)
                FindObjectOfType<DTFazendeiro>().StartDialogue(4, 4);
            if (lastSentence == 28)
                FindObjectOfType<DTFazendeiro>().StartDialogue(5, 8);
            if (lastSentence == 29)
                FindObjectOfType<DTFazendeiro>().StartDialogue(9, 9);
            if (lastSentence == 30)
                estadoDeMundo.save.fimIntroducaoTurno2 = true;
        }

        else if(estadoDeMundo.save.turno == 3)
        {
            if (lastSentence == 31)
            {
                FindObjectOfType<DTEmpresarioBom>().fazerAndar.AndeParaOPlayer();
            }
            else if (lastSentence == 32)
                FindObjectOfType<DialogueTriggerAssistente>().StartDialogue(42, 42);
            else if (lastSentence == 33)
                FindObjectOfType<DTEmpresarioBom>().StartDialogue(0, 0);
            else if (lastSentence == 34)
                FindObjectOfType<DTEmpresarioBom>().StartDialogue(1, 1);
            else if (lastSentence == 35)
                FindObjectOfType<DTEmpresarioBom>().StartDialogue(2, 2);
            else if (lastSentence == 36)
                FindObjectOfType<DTEmpresarioBom>().StartDialogue(3, 3);
            else if (lastSentence == 37)
                FindObjectOfType<DTEmpresarioBom>().StartDialogue(4, 5);
            else if (lastSentence == 38)
                FindObjectOfType<DTEmpresarioBom>().StartDialogue(6, 6);
            else if (lastSentence == 39)
                FindObjectOfType<DTGovernandor>().StartDialogue(4, 4);
            else if (lastSentence == 40)
                FindObjectOfType<DTGovernandor>().StartDialogue(5, 6);
            else if (lastSentence == 41)
                FindObjectOfType<DTGovernandor>().StartDialogue(7, 7);
            else if (lastSentence == 42)
                FindObjectOfType<DTGovernandor>().StartDialogue(8, 8);
            else if (lastSentence == 44)
                FindObjectOfType<DTGovernandor>().StartDialogue(12, 12);
            else if (lastSentence == 45)
                FindObjectOfType<DTGovernandor>().StartDialogue(13, 14);


        }

        else if (estadoDeMundo.save.turno == 4)
        {
            if (lastSentence == 46)
                FindObjectOfType<DialogueTriggerAssistente>().StartDialogue(46, 46);
            else if (lastSentence == 47)
                FindObjectOfType<DialogueTriggerAssistente>().StartDialogue(53, 54);
            else if (lastSentence == 48 || lastSentence == 49)
                FindObjectOfType<DTEmpresarioBom>().fazerAndar.AndePara(new Vector2(-4.5f, -3.3f));
            else if (lastSentence == 50)
                FindObjectOfType<DTEmpresarioBom>().StartDialogue(7, 7);
            else if (lastSentence == 51)
                FindObjectOfType<DTEmpresarioBom>().StartDialogue(8, 8);

            else if (lastSentence == 52)
                FindObjectOfType<DTEmpresarioRuim>().StartDialogue(24, 24);
            else if (lastSentence == 53)
                FindObjectOfType<DTEmpresarioBom>().StartDialogue(11, 13);
            else if (lastSentence == 54)
            {
                FindObjectOfType<DTEmpresarioRuim>().fazerAndar.AndePara(new Vector2(17, -2));
                FindObjectOfType<DTEmpresarioBom>().StartDialogue(14, 14, 1f);
                //FindObjectOfType<DTEmpresarioBom>().StartDialogue(14, 14);
            }
            else if (lastSentence == 55)
                FindObjectOfType<DTGovernandor>().StartDialogue(15, 17);
            else if (lastSentence == 56)
                FindObjectOfType<DTEmpresarioRuim>().fazerAndar.AndeParaOPlayer();
            else if (lastSentence == 57)
                FindObjectOfType<DialogueTriggerAssistente>().StartDialogue(58,58);
            else if (lastSentence == 58)
                FindObjectOfType<DTEmpresarioBom>().StartDialogue(17, 18);
            else if (lastSentence == 59)
                FindObjectOfType<DTEmpresarioBom>().StartDialogue(19, 19);

        }

        else if (estadoDeMundo.save.turno == 5)
        {
            if (lastSentence == 60)
                FindObjectOfType<DialogueTriggerAssistente>().StartDialogue(71, 71);
            else if (lastSentence == 61)
                FindObjectOfType<DTEmpresarioBom>().fazerAndar.AndeParaOPlayer();
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
            && resposta == dialogueResponses.Responses[2] && ultimaSentenca == 17)
        {
            estadoDeMundo.save.relacaoEmpresarioRuim++;
            estadoDeMundo.save.AceitouAOfertaDoEmpresarioRuim = true;
            StartDialogue(17, 17);
        }
        else if (NPCPerguntando == dialogueData.name
          && resposta == dialogueResponses.Responses[3] && ultimaSentenca == 17)
        {
            estadoDeMundo.save.relacaoEmpresarioRuim--;
            estadoDeMundo.save.AceitouAOfertaDoEmpresarioRuim = false;
            StartDialogue(17, 17);
        }


        if (NPCPerguntando == dialogueData.name
            && resposta == dialogueResponses.Responses[4] && ultimaSentenca == 18)
        {
            estadoDeMundo.save.relacaoFazendeiro++;
            estadoDeMundo.save.AceitouLiberarAguasParaFazendeiro = true;
            StartDialogue(18, 18);
        }
        else if (NPCPerguntando == dialogueData.name
          && resposta == dialogueResponses.Responses[5] && ultimaSentenca == 18)
        {
            estadoDeMundo.save.relacaoFazendeiro--;
            estadoDeMundo.save.AceitouLiberarAguasParaFazendeiro = false; 
            StartDialogue(18, 18);
        }
    }
}
