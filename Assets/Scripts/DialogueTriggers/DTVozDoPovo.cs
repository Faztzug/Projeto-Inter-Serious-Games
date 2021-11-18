using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DTVozDoPovo : DialogueTrigger
{
    public override void StartDialogue()
    {
        if(estadoDeMundo.save.turno == 1)
        {

        }
        else if (estadoDeMundo.save.turno == 2)
        {

        }
        else if (estadoDeMundo.save.turno == 3)
        {

        }
        else if (estadoDeMundo.save.turno == 4)
        {

        }
        else if (estadoDeMundo.save.turno == 5)
        {

        }
        else if (estadoDeMundo.save.turno == 6)
        {

        }
        else if (estadoDeMundo.save.turno == 7)
        {
            StartDialogue(0, 0);
        }
    }

    public override void EndOfDialogue(int lastSentence, string NPCname)
    {
        base.EndOfDialogue(lastSentence, NPCname);


        if (estadoDeMundo.save.turno == 1)
        {

        }
        else if (estadoDeMundo.save.turno == 2)
        {

        }
        else if (estadoDeMundo.save.turno == 3)
        {

        }
        else if (estadoDeMundo.save.turno == 4)
        {

        }
        else if (estadoDeMundo.save.turno == 5)
        {

        }
        else if (estadoDeMundo.save.turno == 6)
        {

        }
        else if (estadoDeMundo.save.turno == 7)
        {
            if (lastSentence == 1)
                FindObjectOfType<DTFazendeiro>().StartDialogue(10,10);
            else if (lastSentence == 2)
                DTplayer.StartDialogue(84, 85);
            else if (lastSentence == 3)
                DTplayer.StartDialogue(86, 86);
            else if (lastSentence == 5)
                DTplayer.StartDialogue(87, 87);
        }
    }
}
