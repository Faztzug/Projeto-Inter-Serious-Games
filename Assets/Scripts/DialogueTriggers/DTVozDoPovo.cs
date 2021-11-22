using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DTVozDoPovo : DialogueTrigger
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

        }
        else if (estado.save.turno == 2)
        {

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

        }
        else if (estado.save.turno == 7)
        {
            if(estado.save.fimIntroducaoTurno7 == false)
            StartDialogue(0, 0);
        }
    }

    public override void EndOfDialogue(int lastSentence, string NPCname)
    {
        base.EndOfDialogue(lastSentence, NPCname);


        if (estado.save.turno == 1)
        {

        }
        else if (estado.save.turno == 2)
        {

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

        }
        else if (estado.save.turno == 7)
        {
            if (lastSentence == 1)
                FindObjectOfType<DTFazendeiro>().StartDialogue(10,10);
            else if (lastSentence == 2)
                DTplayer.StartDialogue(84, 85);
            else if (lastSentence == 3)
                DTplayer.StartDialogue(86, 86);
            else if (lastSentence == 5)
                DTplayer.StartDialogue(87, 87);

            //dialogo governador
            if(estado.save.averigouProvas7 == true)
            {
                if (lastSentence == 6)
                    DTplayer.StartDialogue(192, 192);
            }
        }

        else if (estado.save.turno == 8)
        {
            if(lastSentence == 7)
                DTplayer.StartDialogue(208, 208);
        }
    }
}
