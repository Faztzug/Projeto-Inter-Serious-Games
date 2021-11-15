using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DTFazendeiro : DialogueTrigger
{
    public override void StartDialogue()
    {
        if(estadoDeMundo.save.turno == 1)
            dialogueManager.StartingDialogue(0, 2);

        if(estadoDeMundo.save.turno == 2)
        {
            DTplayer.StartDialogue(25,25);
        }
    }

    public override void EndOfDialogue(int lastSentence, string NPCname)
    {
        base.EndOfDialogue(lastSentence, NPCname);
        if (lastSentence == 3)
            DTplayer.StartDialogue(8,9);

        if(estadoDeMundo.save.turno == 2)
        {
            if (lastSentence == 4)
                DTplayer.StartDialogue(26,26);
            else if (lastSentence == 5)
                DTplayer.StartDialogue(27, 27);
            else if (lastSentence == 9)
                DTplayer.StartDialogue(28, 28);
            else if (lastSentence == 10)
            {
                fazerAndar.AndePara(new Vector2
                    (transform.position.x + 7, transform.position.y + 1));
                FindObjectOfType<DialogueTriggerAssistente>().StartDialogue(33,33);
            }
                

        }
    }
}
