using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerEsferaTeste : DialogueTrigger
{

    public override void StartDialogue()
    {
        if (estadoDeMundo.testeQuestBarrilVermelho == false)
            dialogueManager.StartingDialogue(0, 3);
        else if (estadoDeMundo.testeQuestBarrilVermelho == true && estadoDeMundo.testeBarrilVermelhoDestruido == false)
            dialogueManager.StartingDialogue(4, 4);
        else if (estadoDeMundo.testeBarrilVermelhoDestruido == true)
            dialogueManager.StartingDialogue(5, dialogueManager.numberSentences - 1);
        else
            base.StartDialogue();
    }

    public override void EndOfDialogue(int lastSentence, string NPCname)
    {
        base.EndOfDialogue(lastSentence, NPCname);
        if(lastSentence == 4)
        {
            estadoDeMundo.testeQuestBarrilVermelho = true;
        }
    }
}
