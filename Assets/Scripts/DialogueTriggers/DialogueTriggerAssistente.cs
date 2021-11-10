using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerAssistente : DialogueTrigger
{
    public override void StartDialogue()
    {
        if(estadoDeMundo.turno == 1)
        {
            if(estadoDeMundo.conheceuGovernadorEEmpresario == false)
            dialogueManager.StartingDialogue(0, 1);

            else if (estadoDeMundo.conheceuGovernadorEEmpresario == true 
                && estadoDeMundo.conheceuFazendeiro == false)
                dialogueManager.StartingDialogue(2, 4);

            else if(estadoDeMundo.conheceuFazendeiro == true)
                dialogueManager.StartingDialogue(10, 13);
        } 
    }

    public override void EndOfDialogue(int lastSentence, string NPCname)
    {
        base.EndOfDialogue(lastSentence, NPCname);
        if (lastSentence == 2)
            DTplayer.StartDialogue(3, 3);
        else if (lastSentence == 5)
            DTplayer.StartDialogue(7, 7);
        else if (lastSentence == 9)
            FindObjectOfType<DTFazendeiro>().GetComponentInParent<FazerAndar>()
                .AndePara(new Vector2(7.5f, -3.5f));
        else if (lastSentence == 10)
        {
            FindObjectOfType<DTFazendeiro>().GetComponentInParent<FazerAndar>()
                .AndePara(new Vector2(8.47f, -9.22f));
            estadoDeMundo.conheceuFazendeiro = true;
            GetComponentInParent<FazerAndar>()
                .AndePara(player.transform.position);
            
            
        }
        else if (lastSentence == 14)
        {
            
            GetComponentInParent<FazerAndar>()
                .AndePara(new Vector2(transform.position.x + 14, transform.position.y));
        }



    }
}
