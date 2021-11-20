using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DTGovernandor : DialogueTrigger
{
    public override void Start()
    {
        base.Start();

        if(estado.save.turno == 4)
        {
            if (estado.save.fimIntroducaoTurno4 == true
                && estado.save.fimDialogoGovernadorTurno4 == false)
                fazerAndar.AndeParaOPlayer();
        }
        else if (estado.save.turno == 6)
        {
            StartDialogue(19, 19);
        }



        else if (estado.save.turno == 10)
        {
            StartDialogue(27, 27);
        }
    }

    public override void StartDialogue()
    {
        if (estado.save.turno == 1 && estado.save.conheceuGovernador == false)
        {
            dialogueManager.StartingDialogue(0, 3);
            fazerAndar.pararDeAndarAoAtingirPlayer = false;
        }
        else if (estado.save.turno == 3)
        {
            DTplayer.StartDialogue(38, 38);
        }
        else if (estado.save.turno == 4)
        {
            DTplayer.StartDialogue(54, 54);
        }
        else if (estado.save.turno == 5)
        {
            if(estado.save.fimIntroducaoTurno5 == true)
            {
                DTplayer.StartDialogue(152,152);
            }
        }
        else if (estado.save.turno == 6)
        {
            StartDialogue(19, 19);
        }


        else if (estado.save.turno == 10)
        {

            StartDialogue(27, 27);
        }

    }
    public override void EndOfDialogue(int lastSentence, string NPCname)
    {
        base.EndOfDialogue(lastSentence, NPCname);
        if (lastSentence == 4)
            FindObjectOfType<DTEmpresarioRuim>().GetComponentInParent<FazerAndar>()
                .AndePara(new Vector2(-6.5f,-3));

        if(estado.save.turno == 3)
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

        else if (estado.save.turno == 4)
        {
            if (lastSentence == 18)
               DTplayer.StartDialogue(55,55);
            else if (lastSentence == 19)
                FindObjectOfType<DTEmpresarioRuim>().StartDialogue(31, 31);
        }

        else if (estado.save.turno == 5)
        {
            if (estado.save.fimIntroducaoTurno5)
            {
                if(lastSentence == 30)
                    FindObjectOfType<DTEmpresarioRuim>().StartDialogue(33, 33);
                else if (lastSentence == 31)
                    DTplayer.StartDialogue(156, 156);
                else if (lastSentence == 32)
                    FindObjectOfType<DTEmpresarioRuim>().StartDialogue(34, 34);
                else if (lastSentence == 33)
                    DTplayer.StartDialogue(158, 158);
                else if (lastSentence == 34)
                    DTplayer.StartDialogue(159, 159);
                else if (lastSentence == 35)
                    FindObjectOfType<DTEmpresarioRuim>().StartDialogue(35, 35);
                else if (lastSentence == 37)
                    DTplayer.StartDialogue(160, 160);
                else if (lastSentence == 38)
                    FindObjectOfType<DTEmpresarioRuim>().StartDialogue(36, 36);
            }

        }

        else if (estado.save.turno == 6)
        {
            if (lastSentence == 20)
                DTplayer.StartDialogue(70, 70);
            else if (lastSentence == 23)
                DTplayer.StartDialogue(71, 71);
            else if (lastSentence == 25)
                DTplayer.StartDialogue(72, 72);
            else if (lastSentence == 26)
                DTplayer.StartDialogue(73, 73);
            else if (lastSentence == 27)
                DTplayer.StartDialogue(74, 74);
        }







        else if (estado.save.turno == 10)
        {
            if (lastSentence == 28)
                DTplayer.StartDialogue(106, 106);
            else if (lastSentence == 29)
                DTplayer.StartDialogue(107, 107);
        }



    }
}
