using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DTGovernandor : DialogueTrigger
{
    public override void Start()
    {
        base.Start();

        if(estadoDeMundo.save.turno == 4)
        {
            if (estadoDeMundo.save.fimIntroducaoTurno4 == true
                && estadoDeMundo.save.fimDialogoGovernadorTurno4 == false)
                fazerAndar.AndeParaOPlayer();
        }
    }

    public override void StartDialogue()
    {
        if (estadoDeMundo.save.turno == 1 && estadoDeMundo.save.conheceuGovernador == false)
        {
            dialogueManager.StartingDialogue(0, 3);
            fazerAndar.pararDeAndarAoAtingirPlayer = false;
        }
        else if (estadoDeMundo.save.turno == 3)
        {
            DTplayer.StartDialogue(38, 38);
        }
        else if (estadoDeMundo.save.turno == 4)
        {
            DTplayer.StartDialogue(54, 54);
        }

    }
    public override void EndOfDialogue(int lastSentence, string NPCname)
    {
        base.EndOfDialogue(lastSentence, NPCname);
        if (lastSentence == 4)
            FindObjectOfType<DTEmpresarioRuim>().GetComponentInParent<FazerAndar>()
                .AndePara(new Vector2(-6.5f,-3));

        if(estadoDeMundo.save.turno == 3)
        {
            if (lastSentence == 5)
                DTplayer.StartDialogue(39, 39);
            else if (lastSentence == 7)
                FindObjectOfType<DTEmpresarioRuim>().StartDialogue(17, 17);
            else if (lastSentence == 8)
                DTplayer.StartDialogue(41, 41);
            else if (lastSentence == 9)
                FindObjectOfType<DTEmpresarioRuim>().StartDialogue(18, 21);
            else if (lastSentence == 12)
                DTplayer.StartDialogue(42, 43);
            else if (lastSentence == 13)
                DTplayer.StartDialogue(44, 44);
            else if (lastSentence == 15)
                FindObjectOfType<DTEmpresarioRuim>().StartDialogue(22, 22);
        }
        else if (estadoDeMundo.save.turno == 4)
        {
            if (lastSentence == 18)
               DTplayer.StartDialogue(55,55);
            else if (lastSentence == 19)
                FindObjectOfType<DTEmpresarioRuim>().StartDialogue(31, 31);
        }
    }
}
