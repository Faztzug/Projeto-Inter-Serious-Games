using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DTEmpresarioBom : DialogueTrigger
{
    public override void StartDialogue()
    {
        if(estadoDeMundo.save.turno == 3)
        {
            DTplayer.StartDialogue(31,31);
        }
        else if (estadoDeMundo.save.turno == 4)
        {
            if (estadoDeMundo.save.fimIntroducaoTurno4 == false)
                DTplayer.StartDialogue(49, 49);
            else
                StartDialogue(16,16);
        }
    }

    public override void EndOfDialogue(int lastSentence, string NPCname)
    {
        base.EndOfDialogue(lastSentence, NPCname);
        
        if(estadoDeMundo.save.turno == 3)
        {
            if (lastSentence == 1)
                DTplayer.StartDialogue(33, 33);
            else if (lastSentence == 2)
                FindObjectOfType<DialogueTriggerAssistente>().StartDialogue(43, 43);
            else if (lastSentence == 3)
                DTplayer.StartDialogue(35, 35);
            else if (lastSentence == 4)
                FindObjectOfType<DialogueTriggerAssistente>().StartDialogue(44, 44);
            else if (lastSentence == 6)
                DTplayer.StartDialogue(37, 37);
            else if (lastSentence == 7)
            {
                FindObjectOfType<DTEmpresarioRuim>().transform.parent.position = new Vector2(10.3f, -2.7f);
                FindObjectOfType<DTEmpresarioRuim>().fazerAndar.AndeParaOPlayer();
                FindObjectOfType<DTGovernandor>().transform.parent.position = new Vector2(10f, -2.5f);
                FindObjectOfType<DTGovernandor>().fazerAndar.AndeParaOPlayer();
                fazerAndar.AndePara(new Vector2(16f, -2.5f));
            }
                
        }
        else if (estadoDeMundo.save.turno == 4)
        {
            if (lastSentence == 8)
                DTplayer.StartDialogue(50, 50);
            else if (lastSentence == 9)
                FindObjectOfType<DTEmpresarioRuim>().fazerAndar.AndeParaOPlayer();
            else if (lastSentence == 10)
                FindObjectOfType<DTEmpresarioRuim>().StartDialogue(25, 25);
            else if (lastSentence == 11)
                FindObjectOfType<DTEmpresarioRuim>().StartDialogue(26, 28);
            else if (lastSentence == 14)
                FindObjectOfType<DTEmpresarioRuim>().StartDialogue(29, 29);
            else if (lastSentence == 15)
            {
                FindObjectOfType<DTGovernandor>().fazerAndar.AndePara(new Vector2(5.5f, -3.2f));
                StartDialogue(15, 15, 2);
                //StartDialogue(15, 15);
                estadoDeMundo.save.fimIntroducaoTurno4 = true;
            }
            else if (lastSentence == 16)
                fazerAndar.AndePara(new Vector2(17, -5));
            else if (lastSentence == 17)
                DTplayer.StartDialogue(57, 57);
            else if (lastSentence == 19)
                DTplayer.StartDialogue(58, 58);
            else if (lastSentence == 20)
                fazerAndar.AndePara(new Vector2(17, -5));


        }
    }
}
