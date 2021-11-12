using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DTFazendeiro : DialogueTrigger
{
    public override void StartDialogue()
    {
        if(estadoDeMundo.save.turno == 1)
            dialogueManager.StartingDialogue(0, 2);
    }

    public override void EndOfDialogue(int lastSentence, string NPCname)
    {
        base.EndOfDialogue(lastSentence, NPCname);
        if (lastSentence == 3)
            DTplayer.StartDialogue(8,9);
    }
}
