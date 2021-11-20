using UnityEngine;

public class DTEmpresarioRuim : DialogueTrigger
{
    public string areaGovernamentalForaCena;
    

    public override void Start()
    {
        base.Start();

        if (estado.save.turno == 5 && estado.save.conversouComGovernador5 == true)
        {
            //FindObjectOfType<DialogueTriggerAssistente>().transform.parent.position = new Vector2(40, -20);
            if(gameObject.scene.name == areaGovernamentalForaCena)
            {
                fazerAndar.AndeParaOPlayer();
            }
            

        }

        else if (estado.save.turno == 7 && estado.save.coletouProvasContraER7 == false)
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

        }
        else if (estado.save.turno == 7)
        {
            
            FindObjectOfType<DialogueTriggerAssistente>().fazerAndar.PararAndar();
            StartDialogue(32, 32);
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

        }
        else if (estado.save.turno == 7)
        {
            if (lastSentence == 33)
                DTplayer.StartDialogue(80,80);
        }
    }
}