using UnityEngine;

public class DTEmpresarioRuim : DialogueTrigger
{
    public string areaGovernamentalForaCena;
    

    public override void Start()
    {
        base.Start();

        VerificarTurnoAtual turnoAtual;

        if(GetComponent<VerificarTurnoAtual>() != null)
        {
            turnoAtual = GetComponent<VerificarTurnoAtual>();
            if (turnoAtual.Verificar() == false)
                transform.parent.gameObject.SetActive(false);
        }

        if (estado.save.turno == 5 && estado.save.conversouComGovernador5 == true)
        {
            //FindObjectOfType<DialogueTriggerAssistente>().transform.parent.position = new Vector2(40, -20);
            if(gameObject.scene.name == areaGovernamentalForaCena)
            {
                fazerAndar.AndeParaOPlayer();
            }
            

        }

        else if (estado.save.turno == 7 && estado.save.coletouProvasContraER6 == false)
        {
            FindObjectOfType<DialogueTriggerAssistente>().transform.parent.position = new Vector2(40, -20);
            fazerAndar.AndeParaOPlayer();
            
        }
            
    }

    public override void StartDialogue()
    {
        if (estado.save.turno == 1)
        {
            dialogueManager.StartingDialogue(0, 1);
        }
        else if (estado.save.turno == 2)
        {
            dialogueManager.StartingDialogue(7, 7);
        }
        else if (estado.save.turno == 3)
        {
        }
        else if (estado.save.turno == 4)
        {
            if (estado.save.fimIntroducaoTurno4 == false)
                StartDialogue(23, 23);
            else
                StartDialogue(30, 30);
        }
        else if (estado.save.turno == 5)
        {
            if(estado.save.conversouComGovernador5 == true)
            {
                StartDialogue(37,37);
            }
        }
        else if (estado.save.turno == 6)
        {
            DTplayer.StartDialogue(171, 171);
        }
        else if (estado.save.turno == 7)
        {
            
            FindObjectOfType<DialogueTriggerAssistente>().fazerAndar.PararAndar();
            StartDialogue(32, 32);
        }


        //ele não aparece no turno 8


        //e nem no turno 9

        else if (estado.save.turno == 10)
        {

            if (estado.save.iniciarPuzzleTurno10 == true
                && estado.save.preparouArmadilha10 == true)
                StartDialogue(60, 60);
            
        }
    }

    public override void EndOfDialogue(int lastSentence, string NPCname)
    {
        base.EndOfDialogue(lastSentence, NPCname);
        if (estado.save.turno == 1)
        {
            if (lastSentence == 2)
                DTplayer.StartDialogue(4, 5);
            else if (lastSentence == 6)
                DTplayer.StartDialogue(6, 6);
            else if (lastSentence == 7)
            {
                GetComponentInParent<FazerAndar>().
                    AndePara(new Vector2(transform.position.x + 1, transform.position.y - 7));
                FindObjectOfType<DTGovernandor>().GetComponentInParent<FazerAndar>().
                    AndePara(new Vector2(transform.position.x + 1, transform.position.y - 7));
                estado.save.conheceuGovernador = true;
                FindObjectOfType<DialogueTriggerAssistente>().GetComponentInParent<FazerAndar>()
                    .AndePara(player.transform.position, 1);
            }
        }
        else if (estado.save.turno == 2)
        {
            if (lastSentence == 8)
                DTplayer.StartDialogue(20, 20);
            else if (lastSentence == 10)
                DTplayer.StartDialogue(21, 21);
            else if (lastSentence == 11)
                DTplayer.StartDialogue(22, 22);
            else if (lastSentence == 12)
                FindObjectOfType<DialogueTriggerAssistente>().StartDialogue(30, 31);
            else if (lastSentence == 16)
                DTplayer.StartDialogue(24, 24);
            else if (lastSentence == 17)
            {
                fazerAndar.AndePara(new Vector2(16, -3));
                //FindObjectOfType<DTFazendeiro>().fazerAndar.AndePara(new Vector2(7.4f, -3.8f), 0.5f);
                FindObjectOfType<DTFazendeiro>().fazerAndar.AndeParaOPlayer();
            }
        }
        else if (estado.save.turno == 3)
        {
            if (lastSentence == 18)
                DTplayer.StartDialogue(40, 40);
            else if (lastSentence == 22)
                FindObjectOfType<DTGovernandor>().StartDialogue(9, 11);
            else if (lastSentence == 23)
            {
                FindObjectOfType<DTGovernandor>().fazerAndar.AndePara(new Vector2(16f, -1f));
                fazerAndar.AndePara(new Vector2(16f, -2f));
                estado.save.fimIntroducaoTurno3 = true;
            }
        }
        else if (estado.save.turno == 4)
        {
            if (lastSentence == 24)
                DTplayer.StartDialogue(51, 51);
            else if (lastSentence == 25)
                FindObjectOfType<DTEmpresarioBom>().StartDialogue(9, 9);
            else if (lastSentence == 26)
                FindObjectOfType<DTEmpresarioBom>().StartDialogue(10, 10);
            else if (lastSentence == 29)
                DTplayer.StartDialogue(52, 52);
            else if (lastSentence == 30)
                DTplayer.StartDialogue(53, 53);
            else if (lastSentence == 31)
                FindObjectOfType<DTGovernandor>().StartDialogue(18, 18);
            else if (lastSentence == 32)
            {
                FindObjectOfType<DTGovernandor>().fazerAndar.AndePara(new Vector2(18, -3));
                fazerAndar.AndePara(new Vector2(18, -3));

                player.emDialogo = true;
                FindObjectOfType<DialogueTriggerAssistente>().fazerAndar.AndeParaOPlayer(3);
                FindObjectOfType<DialogueTriggerAssistente>().StartDialogue(57, 57, 5);
            }
        }
        else if (estado.save.turno == 5)
        {
            if(estado.save.fimIntroducaoTurno5 == true)
            {
                if (lastSentence == 34)
                    DTplayer.StartDialogue(155, 155);
                else if (lastSentence == 35)
                    DTplayer.StartDialogue(157, 157);
                else if (lastSentence == 36)
                    FindObjectOfType<DTGovernandor>().StartDialogue(35, 36);
                else if (lastSentence == 37)
                {
                    player.emDialogo = true;
                    estado.save.conversouComGovernador5 = true;
                    CrossfadeLoadEffect crossfade = FindObjectOfType<CrossfadeLoadEffect>();
                    crossfade.ChamarCrossfade(crossfade.areaGovernamentalForaCena, new Vector2(0, -3.5f));
                }

                else if (lastSentence == 38)
                    DTplayer.StartDialogue(161, 161);
                else if (lastSentence == 39)
                {
                    fazerAndar.AndePara(new Vector2(0, 10));
                    player.emDialogo = true;
                    DTplayer.StartDialogue(162, 162, 1f);
                }
                    
            }
        }
        else if (estado.save.turno == 6)
        {
            if(lastSentence == 40)
                DTplayer.StartDialogue(172, 173);
            else if (lastSentence == 41)
                DTplayer.StartDialogue(174, 174);
            else if (lastSentence == 42)
                DTplayer.StartDialogue(175, 177);
            else if (lastSentence == 44)
                DTplayer.StartDialogue(178, 178);
            else if (lastSentence == 46)
                DTplayer.StartDialogue(179, 179);
            else if (lastSentence == 48)
                DTplayer.StartDialogue(180, 180);
            else if (lastSentence == 51)
                DTplayer.StartDialogue(181, 181);
            else if (lastSentence == 52)
                DTplayer.StartDialogue(182, 182);
            else if (lastSentence == 53)
                DTplayer.StartDialogue(183, 183);
            else if (lastSentence == 54)
                DTplayer.StartDialogue(184, 184);
            else if (lastSentence == 60)
            {
                DTplayer.MomentoDeResponder(lastSentence, dialogueData.name);
                DTplayer.answerManager.GerarRespostas(DTplayer.responses[24]);
                DTplayer.answerManager.GerarRespostas(DTplayer.responses[25]);
                
            }
                
        }
        else if (estado.save.turno == 7)
        {
            if (lastSentence == 33)
                DTplayer.StartDialogue(80,80);
        }



        else if (estado.save.turno == 10)
        {
            if (lastSentence == 61)
                FindObjectOfType<DTGovernandor>().StartDialogue(46, 46);
            else if (lastSentence == 62)
                FindObjectOfType<DTGovernandor>().StartDialogue(47, 47);
        }
    }
}