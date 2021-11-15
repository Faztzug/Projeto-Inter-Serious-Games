using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DTEmpresarioRuim : DialogueTrigger
{
    public override void StartDialogue()
    {
        if(estadoDeMundo.save.turno == 1)
        {
            dialogueManager.StartingDialogue(0, 1);
        }

        if(estadoDeMundo.save.turno == 2)
        {
            dialogueManager.StartingDialogue(7, 7);
        }
    }

    public override void EndOfDialogue(int lastSentence, string NPCname)
    {
        base.EndOfDialogue(lastSentence, NPCname);
        if (lastSentence == 2)
            DTplayer.StartDialogue(4,5);
        else if(lastSentence == 6)
            DTplayer.StartDialogue(6, 6);
        else if(lastSentence == 7)
        {
            GetComponentInParent<FazerAndar>().
                AndePara(new Vector2(transform.position.x + 1, transform.position.y - 7));
            FindObjectOfType<DTGovernandor>().GetComponentInParent<FazerAndar>().
                AndePara(new Vector2(transform.position.x + 1, transform.position.y - 7));
            estadoDeMundo.save.conheceuGovernador = true;
            FindObjectOfType<DialogueTriggerAssistente>().GetComponentInParent<FazerAndar>()
                .AndePara(player.transform.position, 1);
        }

        if(estadoDeMundo.save.turno == 2)
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
    }

}
