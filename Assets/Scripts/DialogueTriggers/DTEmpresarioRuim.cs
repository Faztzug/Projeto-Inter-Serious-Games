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
            estadoDeMundo.save.conheceuGovernadorEEmpresario = true;
            FindObjectOfType<DialogueTriggerAssistente>().GetComponentInParent<FazerAndar>()
                .AndePara(player.transform.position, 1);
        }
    }

}
