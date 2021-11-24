using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DTFazendeiro : DialogueTrigger
{
    public override void Start()
    {
        base.Start();

        VerificarTurnoAtual turnoAtual;

        if (GetComponent<VerificarTurnoAtual>() != null)
        {
            turnoAtual = GetComponent<VerificarTurnoAtual>();
            if (turnoAtual.Verificar() == false)
                transform.parent.gameObject.SetActive(false);
        }
    }

    public override void StartDialogue()
    {
        if(estado.save.turno == 1)
        {
            if(estado.save.conheceuFazendeiro == false)
                dialogueManager.StartingDialogue(0, 2);
        }
            

        if(estado.save.turno == 2)
        {
            DTplayer.StartDialogue(25,25);
        }

        if (estado.save.turno == 6)
        {
            if(estado.save.fimIntroducaoTurno6 == true)
            {
                DTplayer.StartDialogue(215, 215);
            }
            
        }
    }

    public override void EndOfDialogue(int lastSentence, string NPCname)
    {
        base.EndOfDialogue(lastSentence, NPCname);

        if(estado.save.turno == 1)
        {
            if (lastSentence == 3)
                DTplayer.StartDialogue(8, 9);
        }

        else if(estado.save.turno == 2)
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
        else if (estado.save.turno == 3)
        {

        }
        else if (estado.save.turno == 4)
        {

        }
        else if (estado.save.turno == 5)
        {

        }
        else if (estado.save.turno == 6)
        {
            if (lastSentence == 18)
                DTplayer.StartDialogue(216, 216);
            else if (lastSentence == 19)
                DTplayer.StartDialogue(217, 217);
            else if (lastSentence == 20)
                estado.save.conversouFazendeiro6 = true;
        }
        else if (estado.save.turno == 7)
        {
            if (lastSentence == 11)
                DTplayer.StartDialogue(83, 83);
            else if (lastSentence == 12)
                FindObjectOfType<DTVozDoPovo>().StartDialogue(1, 1);
            else if (lastSentence == 13)
                FindObjectOfType<DTVozDoPovo>().StartDialogue(2, 2);
            else if (lastSentence == 17)
                FindObjectOfType<DTVozDoPovo>().StartDialogue(3, 4);
        }
    }
}
