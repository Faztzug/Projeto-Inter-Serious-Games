using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DTFazendeiro : DialogueTrigger
{
    [SerializeField] private string fazendaCena;

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
            if (estado.save.conheceuFazendeiro == false)
                dialogueManager.StartingDialogue(0, 2);
            else if (estado.save.conheceuFazendeiro == true)
                DTplayer.StartDialogue(221,221);
        }
            

        if(estado.save.turno == 2)
        {
            if(estado.save.fimIntroducaoTurno2 == false)
            DTplayer.StartDialogue(25,25);
        }

        if (estado.save.turno == 3)
        {
            if(estado.save.fimIntroducaoTurno3 == true)
            {
                if (estado.save.aceitouCompartilharMaquinasFazendeiro == true)
                    StartDialogue(20, 20);
                else if (estado.save.aceitouCompartilharMaquinasFazendeiro == false)
                    StartDialogue(22, 22);
            }
            
        }

        if (estado.save.turno == 4)
        {
            if (estado.save.fimIntroducaoTurno4 == true)
            {
                if (estado.save.investiuHidreletrica == true)
                    StartDialogue(26, 26);
                else if (estado.save.investiuMaquinas == true)
                    DTplayer.StartDialogue(229, 229);
            }

        }

        if (estado.save.turno == 5)
        {
            if (estado.save.fimIntroducaoTurno5 == true)
            {
                
                    DTplayer.StartDialogue(231, 231);
            }

        }

        if (estado.save.turno == 6)
        {
            if(estado.save.fimIntroducaoTurno6 == true)
            {
                DTplayer.StartDialogue(215, 215);
            }
            
        }

        if (estado.save.turno == 7 && gameObject.scene.name == fazendaCena)
        {
            DTplayer.StartDialogue(235,235);

        }

        if (estado.save.turno == 8)
        {
            if (estado.save.fimIntroducaoTurno8 == true)
            {
                DTplayer.StartDialogue(236, 236);
            }

        }

        if (estado.save.turno == 9)
        {
            if (estado.save.fimIntroducaoTurno9 == true)
            {
                DTplayer.StartDialogue(239, 239);
            }

        }

        if (estado.save.turno == 10)
        {
            if (estado.save.fimIntroducaoTurno10 == true)
            {
                DTplayer.StartDialogue(242, 242);
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
            if (lastSentence == 21)
                DTplayer.StartDialogue(222,222);
            else if (lastSentence == 22)
                DTplayer.StartDialogue(223, 223);

            else if(lastSentence == 23)
                DTplayer.StartDialogue(224, 224);
            else if (lastSentence == 24)
                DTplayer.StartDialogue(225, 225);
            else if (lastSentence == 25)
                DTplayer.StartDialogue(226, 226);
        }
        else if (estado.save.turno == 4)
        {
            if (lastSentence == 27)
                DTplayer.StartDialogue(227,227);
            else if (lastSentence == 28)
                DTplayer.StartDialogue(228, 228);

            else if (lastSentence == 29)
                DTplayer.StartDialogue(230, 230);
            
        }
        else if (estado.save.turno == 5)
        {
            if (lastSentence == 31)
                DTplayer.StartDialogue(232,232);
            else if (lastSentence == 32)
                DTplayer.StartDialogue(233, 233);
            
            else if(lastSentence == 34)
                DTplayer.StartDialogue(234, 234);
            
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

        else if (estado.save.turno == 8)
        {
            if (lastSentence == 36)
                DTplayer.StartDialogue(237, 237);
            else if (lastSentence == 37)
                DTplayer.StartDialogue(238, 238);

        }

        else if (estado.save.turno == 9)
        {
            if (lastSentence == 38)
                DTplayer.StartDialogue(240, 240);
            else if (lastSentence == 39)
                DTplayer.StartDialogue(241, 241);

        }

        else if (estado.save.turno == 10)
        {
            if (lastSentence == 41)
                DTplayer.StartDialogue(243, 243);
            

        }
    }
}
