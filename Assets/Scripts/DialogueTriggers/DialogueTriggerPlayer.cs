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
            else if (lastSentence == 62)
                FindObjectOfType<DTEmpresarioBom>().StartDialogue(21,21);
            else if (lastSentence == 63)
                FindObjectOfType<DTEmpresarioBom>().StartDialogue(22, 22);
            else if (lastSentence == 64)
                FindObjectOfType<DTEmpresarioBom>().StartDialogue(23, 24);
            else if (lastSentence == 65)
                FindObjectOfType<DTEmpresarioBom>().StartDialogue(25, 26);
            else if (lastSentence == 66)
            {
                player.emDialogo = true;
                FindObjectOfType<DialogueTriggerAssistente>().fazerAndar.AndeParaOPlayer();
                FindObjectOfType<DialogueTriggerAssistente>().StartDialogue(76, 76, 0.5f);
            }
            else if (lastSentence == 67)
                FindObjectOfType<DialogueTriggerAssistente>().StartDialogue(77, 78);
            else if (lastSentence == 68)
                FindObjectOfType<DialogueTriggerAssistente>().StartDialogue(79, 79);
            else if (lastSentence == 69)
            {
                estadoDeMundo.save.fimIntroducaoTurno5 = true;
                FindObjectOfType<DTEmpresarioBom>().fazerAndar.AndePara(new Vector2(17f, -3f));
                
            }

        }

        else if (estadoDeMundo.save.turno == 6)
        {
            if (lastSentence == 70)
            {
                player.emDialogo = true;
                FindObjectOfType<DTGovernandor>().fazerAndar.AndeParaOPlayer();
            }
            else if (lastSentence == 71)
                FindObjectOfType<DTGovernandor>().StartDialogue(20, 22);
            else if (lastSentence == 72)
                FindObjectOfType<DTGovernandor>().StartDialogue(23, 24);
            else if (lastSentence == 73)
                FindObjectOfType<DTGovernandor>().StartDialogue(25, 25);
            else if (lastSentence == 74)
                FindObjectOfType<DTGovernandor>().StartDialogue(26, 26);
            else if (lastSentence == 75)
            {
                FindObjectOfType<DTGovernandor>().fazerAndar.AndePara(new Vector2(17, -10f));
                player.emDialogo = true;
                StartDialogue(75,75,2f);
            }
            else if (lastSentence == 76)
                FindObjectOfType<DialogueTriggerAssistente>().StartDialogue(86, 86);
            else if (lastSentence == 77)
                FindObjectOfType<DialogueTriggerAssistente>().StartDialogue(87, 87);
            else if (lastSentence == 79)
                FindObjectOfType<DialogueTriggerAssistente>().StartDialogue(88, 89);
            else if (lastSentence == 80)
                FindObjectOfType<DialogueTriggerAssistente>().StartDialogue(90, 90);



        }

        else if (estadoDeMundo.save.turno == 7)
        {
            if (lastSentence == 81)
                FindObjectOfType<DTNarrador>().StartDialogue(0, 0);
            else if (lastSentence == 82)
                FindObjectOfType<DialogueTriggerAssistente>().StartDialogue(91, 91);
            else if (lastSentence == 83)
            {
                player.emDialogo = true;
                FindObjectOfType<DTFazendeiro>().fazerAndar.AndeParaOPlayer();
                FindObjectOfType<DTVozDoPovo>().fazerAndar.AndeParaOPlayer();
            }
            else if (lastSentence == 84)
                FindObjectOfType<DTFazendeiro>().StartDialogue(11, 11);
            else if (lastSentence == 86)
                FindObjectOfType<DTFazendeiro>().StartDialogue(12, 12);
            else if (lastSentence == 87)
                FindObjectOfType<DTFazendeiro>().StartDialogue(13, 16);
            else if (lastSentence == 88)
            {
                player.emDialogo = true;
                FindObjectOfType<DTFazendeiro>().fazerAndar.AndePara(new Vector2(17, -17));
                FindObjectOfType<DTVozDoPovo>().fazerAndar.AndePara(new Vector2(17, -17));
                FindObjectOfType<DialogueTriggerAssistente>().fazerAndar.AndeParaOPlayer(1);
                FindObjectOfType<DialogueTriggerAssistente>().StartDialogue(92, 92, 1.3f);
            }
            else if (lastSentence == 89)
                FindObjectOfType<DialogueTriggerAssistente>().StartDialogue(93, 93);
            else if (lastSentence == 90)
                FindObjectOfType<DialogueTriggerAssistente>().StartDialogue(94, 94);
        }

        else if (estadoDeMundo.save.turno == 8)
        {
            if (lastSentence == 91)
                FindObjectOfType<DialogueTriggerAssistente>().StartDialogue(98, 99);

            else if (lastSentence == 93)
                FindObjectOfType<DialogueTriggerAssistente>().StartDialogue(102, 103);

            else if (lastSentence == 92)
                FindObjectOfType<DialogueTriggerAssistente>().StartDialogue(104, 104);

            else if (lastSentence == 94)
                FindObjectOfType<DialogueTriggerAssistente>().StartDialogue(107, 107);
            else if (lastSentence == 95)
                FindObjectOfType<DialogueTriggerAssistente>().StartDialogue(108, 108);
            else if (lastSentence == 96)
                FindObjectOfType<DialogueTriggerAssistente>().StartDialogue(109, 109);
            else if (lastSentence == 97)
                FindObjectOfType<DialogueTriggerAssistente>().StartDialogue(110, 110);
            else if (lastSentence == 98)
                estadoDeMundo.save.fimIntroducaoTurno8 = true;


        }

        else if (estadoDeMundo.save.turno == 9)
        {
             if (lastSentence == 99)
                FindObjectOfType<DialogueTriggerAssistente>().StartDialogue(117, 118);
             else if (lastSentence == 100)
                FindObjectOfType<DialogueTriggerAssistente>().StartDialogue(119, 119);
            else if (lastSentence == 101)
                FindObjectOfType<DialogueTriggerAssistente>().StartDialogue(120, 120);
        }

        else if (estadoDeMundo.save.turno == 10)
        {
            //sucesso
            if (lastSentence == 102)
                FindObjectOfType<DialogueTriggerAssistente>().StartDialogue(123, 123);
            else if (lastSentence == 103)
            {
                FindObjectOfType<DialogueTriggerAssistente>().StartDialogue(124, 124);
                //player.emDialogo = true;
                //StartDialogue(104, 104, 4f);
            }
            else if (lastSentence == 104)
                FindObjectOfType<DialogueTriggerAssistente>().StartDialogue(125, 125);
            else if (lastSentence == 105)
            {
                FindObjectOfType<DialogueTriggerAssistente>().StartDialogue(126, 126);
                
            }
            else if (lastSentence == 106)
            {
                player.emDialogo = true;
                FindObjectOfType<DTGovernandor>().fazerAndar.AndeParaOPlayer(3f);
            }
                
            else if (lastSentence == 107)
            {
                FindObjectOfType<DTGovernandor>().StartDialogue(28, 28);
                
            }
            else if (lastSentence == 108)
            {
                
                FindObjectOfType<DTGovernandor>().fazerAndar.AndePara(new Vector2(17, -3));
                player.emDialogo = true;
                StartDialogue(108, 108, 3f);
                estadoDeMundo.save.fimIntroducaoTurno10 = true;
            }

            //fracasso
            else if (lastSentence == 110)
                FindObjectOfType<DialogueTriggerAssistente>().StartDialogue(128, 128);
            else if (lastSentence == 111)
                FindObjectOfType<DialogueTriggerAssistente>().StartDialogue(129, 129);
            else if (lastSentence == 112)
            {
                CrossfadeLoadEffect crossfade = FindObjectOfType<CrossfadeLoadEffect>();

                crossfade.ChamarCrossfade(crossfade.tittleScreenCena, player.transform.position);
            }



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
