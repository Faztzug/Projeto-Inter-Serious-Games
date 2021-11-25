using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DTGovernandor : DialogueTrigger
{
    public string florestaMeioCena;
    public string florestaEsquerdaCena;
    public string areaGovernamentalDentro;

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
            //StartDialogue(19, 19);
        }

        

        else if (estado.save.turno == 10)
        {
            //StartDialogue(27, 27);

            if(estado.save.iniciarPuzzleTurno10 == true)
            {
                if(gameObject.scene.name == florestaMeioCena)
                {
                    if (estado.save.preparouArmadilha10 == true)
                        Destroy(this.transform.parent.gameObject);
                    else
                    {
                        player.emDialogo = true;
                        StartDialogue(45, 45, 4f);
                    }
                    
                }
                    
            }
        }
    }

    public override void StartDialogue()
    {
        if (estado.save.turno == 1)
        {
            if(estado.save.conheceuGovernador == false)
            {
                dialogueManager.StartingDialogue(0, 3);
                fazerAndar.pararDeAndarAoAtingirPlayer = false;
            }

            if(estado.save.conheceuGovernador == true 
                && gameObject.scene.name == areaGovernamentalDentro)
            {
                DTplayer.StartDialogue(266,266);
            }
            

            
        }
        else if (estado.save.turno == 2)
        {
            if(estado.save.fimIntroducaoTurno2 == true)
            StartDialogue(49, 49);
        }
        else if (estado.save.turno == 3)
        {
            if (estado.save.fimIntroducaoTurno3 == false)
                DTplayer.StartDialogue(38, 38);
            else if (estado.save.fimIntroducaoTurno3 == true)
                DTplayer.StartDialogue(270,270);
        }
        else if (estado.save.turno == 4)
        {
            if(estado.save.fimIntroducaoTurno4 == false)
            DTplayer.StartDialogue(54, 54);
        }
        else if (estado.save.turno == 5)
        {
            if(estado.save.fimIntroducaoTurno5 == true
                && estado.save.conversouComGovernador5 == false)
            {
                DTplayer.StartDialogue(152,152);
            }
        }
        else if (estado.save.turno == 6)
        {
            if(estado.save.fimIntroducaoTurno6 == false)
            StartDialogue(19, 19);
        }

        else if (estado.save.turno == 8)
        {
            if (estado.save.fimIntroducaoTurno8 == true 
                && estado.save.conversouGovernador8 == false)
                DTplayer.StartDialogue(206, 206);
        }

        else if (estado.save.turno == 7)
        {
            if (estado.save.averigouProvas7 == true && estado.save.mostrouProvasGovernador7 == false)
                FindObjectOfType<DTVozDoPovo>().StartDialogue(5,5);
        }

        else if(estado.save.turno == 9)
        {
            if(estado.save.fimIntroducaoTurno9 == true)
            {
                DTplayer.StartDialogue(273,273);
            }
        }


        else if (estado.save.turno == 10)
        {
            if(estado.save.fimIntroducaoTurno10 == false)
            StartDialogue(27, 27);
            else if(estado.save.fimIntroducaoTurno10 == true && estado.save.iniciarPuzzleTurno10 == false)
                StartDialogue(44, 44);
        }

    }
    public override void EndOfDialogue(int lastSentence, string NPCname)
    {
        base.EndOfDialogue(lastSentence, NPCname);
        if (lastSentence == 4)
            FindObjectOfType<DTEmpresarioRuim>().GetComponentInParent<FazerAndar>()
                .AndePara(new Vector2(-6.5f,-3));

        if(estado.save.turno == 2)
        {
            if (lastSentence == 50)
                DTplayer.StartDialogue(267,267);
            else if (lastSentence == 51)
                DTplayer.StartDialogue(268, 268);
            else if (lastSentence == 52)
                DTplayer.StartDialogue(269, 269);
        }

        else if(estado.save.turno == 3)
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

            //interação
            if (lastSentence == 53)
                DTplayer.StartDialogue(271,271);
            else if (lastSentence == 54)
                DTplayer.StartDialogue(272, 272);

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


        else if (estado.save.turno == 7)
        {
            if(estado.save.averigouProvas7 == true)
            {
                if (lastSentence == 39)
                    DTplayer.StartDialogue(193, 193);
                else if (lastSentence == 40)
                    DTplayer.StartDialogue(194, 194);
            }
        }

        else if (estado.save.turno == 8)
        {
            if (estado.save.fimIntroducaoTurno8 == true)
            {
                if (lastSentence == 41)
                    DTplayer.StartDialogue(207, 207);
                else if (lastSentence == 42)
                {
                    DTplayer.MomentoDeResponder(lastSentence, dialogueData.dialogue.characterName);
                    DTplayer.answerManager.GerarRespostas(DTplayer.responses[28]); //preparado
                    DTplayer.answerManager.GerarRespostas(DTplayer.responses[29]); //despreparado
                }
                else if (lastSentence == 43)
                {
                    player.emDialogo = true;
                    fazerAndar.AndePara(new Vector2(-4,0.6f));
                    fazerAndar.AndePara(new Vector2(-10, 0.6f), 0.7f);
                    FindObjectOfType<DTEmpresarioBom>().StartDialogue(29,29,2f);
                }
                else if (lastSentence == 44)
                    DTplayer.StartDialogue(209, 209);
            }
        }

        else if(estado.save.turno == 9)
        {
            if (lastSentence == 55)
                DTplayer.StartDialogue(274,274);
            else if (lastSentence == 56)
                DTplayer.StartDialogue(275, 275);
            else if (lastSentence == 57)
                DTplayer.StartDialogue(276, 276);
        }


        else if (estado.save.turno == 10)
        {
            if (lastSentence == 28)
                DTplayer.StartDialogue(106, 106);
            else if (lastSentence == 29)
                DTplayer.StartDialogue(107, 107);

            //final
            else if(lastSentence == 45)
                DTplayer.StartDialogue(211, 211);
            else if (lastSentence == 46)
                DTplayer.StartDialogue(212, 212);

            else if (lastSentence == 47)
            {
                player.emDialogo = true;

                DTEmpresarioRuim DTER = FindObjectOfType<DTEmpresarioRuim>();

                DTER.fazerAndar.AndePara(new Vector2(1f, -4.5f));
                DTER.fazerAndar.AndePara(new Vector2(40f, -5.0f), 0.35f);

                DTER.StartDialogue(61,61, 6f);

            }
            else if (lastSentence == 48)
                DTplayer.StartDialogue(214, 214);

            else if (lastSentence == 49)
            {
                player.emDialogo = true;
                FindObjectOfType<DTNarrador>().StartDialogue(1, 2);
            }
        }



    }
}
