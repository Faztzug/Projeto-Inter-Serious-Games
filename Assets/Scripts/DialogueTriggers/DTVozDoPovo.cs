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
            DTplayer.StartDialogue(244,244);
        }
        else if (estado.save.turno == 2)
        {
            if (estado.save.fimIntroducaoTurno2 == true)
                DTplayer.StartDialogue(245,245);
        }
        else if (estado.save.turno == 3)
        {
            if (estado.save.fimIntroducaoTurno3 == true)
            {
                if (estado.save.aceitouCompartilharMaquinasFazendeiro == true)
                    DTplayer.StartDialogue(246, 246);
                else if (estado.save.aceitouCompartilharMaquinasFazendeiro == false)
                    DTplayer.StartDialogue(250, 250);
            }
                
        }
        else if (estado.save.turno == 4)
        {
            if (estado.save.fimIntroducaoTurno4 == true)
                DTplayer.StartDialogue(253,253);
        }
        else if (estado.save.turno == 5)
        {
            if (estado.save.fimIntroducaoTurno5 == true)
                DTplayer.StartDialogue(256, 256);
        }
        else if (estado.save.turno == 6)
        {
            if(estado.save.fimIntroducaoTurno6 == true)
            {
                DTplayer.StartDialogue(218, 218);
            }
        }
        else if (estado.save.turno == 7)
        {
            if(estado.save.fimIntroducaoTurno7 == false)
            StartDialogue(0, 0);
        }


        else if (estado.save.turno == 9)
        {
            if (estado.save.fimIntroducaoTurno9 == true)
            {
                DTplayer.StartDialogue(261, 261);
            }
        }

        else if (estado.save.turno == 10)
        {
            if (estado.save.fimIntroducaoTurno10 == true)
            {
                DTplayer.StartDialogue(264, 264);
            }
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
            if (lastSentence == 12)
                DTplayer.StartDialogue(247,247);
            else if (lastSentence == 13)
                DTplayer.StartDialogue(248, 248);
            else if (lastSentence == 14)
                DTplayer.StartDialogue(249, 249);

            else if (lastSentence == 15)
                DTplayer.StartDialogue(251, 251);
            else if (lastSentence == 16)
                DTplayer.StartDialogue(252, 252);
        }
        else if (estado.save.turno == 4)
        {
            if (lastSentence == 18)
                DTplayer.StartDialogue(254,254);
            else if (lastSentence == 19)
                DTplayer.StartDialogue(255, 255);
        }
        else if (estado.save.turno == 5)
        {
            if (lastSentence == 20)
                FindObjectOfType<DTEmpresarioBom>().StartDialogue(32,32);
            else if (lastSentence == 21)
                DTplayer.StartDialogue(258, 258);
            else if (lastSentence == 22)
                DTplayer.StartDialogue(259, 259);
        }
        else if (estado.save.turno == 6)
        {
            if (lastSentence == 8)
                FindObjectOfType<DTEmpresarioBom>().StartDialogue(30,30);
            else if (lastSentence == 9)
                DTplayer.StartDialogue(220, 220);
            else if (lastSentence == 10)
            {
                estado.save.conversouVozDoPovo6 = true;
                estado.save.conversouEB6 = true;
            }
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

        else if (estado.save.turno == 9)
        {
            if (lastSentence == 23)
                DTplayer.StartDialogue(262, 262);
            else if (lastSentence == 24)
                DTplayer.StartDialogue(263, 263);
        }

        else if (estado.save.turno == 10)
        {
            if (lastSentence == 25)
                DTplayer.StartDialogue(265, 265);
            else if (lastSentence == 26)
                FindObjectOfType<DTEmpresarioBom>().StartDialogue(37, 37);

        }
    }
}
