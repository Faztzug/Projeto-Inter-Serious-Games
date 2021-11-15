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
    }
}
