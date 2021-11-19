using UnityEngine;

public class DialogueTriggerAssistente : DialogueTrigger
{
    public override void Start()
    {
        base.Start();
        if (estadoDeMundo.save.turno == 2 && estadoDeMundo.save.fimIntroducaoTurno2 == true)
        {
            fazerAndar.PararAndar();
            if(estadoDeMundo.save.apagouIncendio2 == false)
            {
                player.emDialogo = true;
                DTplayer.StartDialogue(113, 113, 1f);
            }
            
        }
            
        else if(estadoDeMundo.save.turno == 3 && estadoDeMundo.save.fimIntroducaoTurno3 == true)
        {
            fazerAndar.PararAndar();
            if(estadoDeMundo.save.puzzleExaustores3Resolvido == false)
            DTplayer.StartDialogue(123, 123, 1f);
        }
            
        else if (estadoDeMundo.save.turno == 4 && estadoDeMundo.save.fimIntroducaoTurno4 == true)
            fazerAndar.PararAndar();
        else if (estadoDeMundo.save.turno == 5 && estadoDeMundo.save.fimIntroducaoTurno5 == true)
            fazerAndar.PararAndar();
        else if (estadoDeMundo.save.turno == 6 && estadoDeMundo.save.fimIntroducaoTurno6 == true)
            fazerAndar.PararAndar();
        else if (estadoDeMundo.save.turno == 7 && estadoDeMundo.save.fimIntroducaoTurno7 == true)
            fazerAndar.PararAndar();
        else if (estadoDeMundo.save.turno == 8 && estadoDeMundo.save.fimIntroducaoTurno8 == true)
            fazerAndar.PararAndar();
        else if (estadoDeMundo.save.turno == 9 && estadoDeMundo.save.fimIntroducaoTurno9 == true)
            fazerAndar.PararAndar();
        else if (estadoDeMundo.save.turno == 10 && estadoDeMundo.save.fimIntroducaoTurno10 == true)
            fazerAndar.PararAndar();
    }

    public override void StartDialogue()
    {
        Debug.Log("Começar StartDialogue() comum.");

        if (estadoDeMundo.save.turno == 1)
        {
            if (estadoDeMundo.save.conheceuGovernador == false)
                dialogueManager.StartingDialogue(0, 1);
            else if (estadoDeMundo.save.conheceuGovernador == true
                && estadoDeMundo.save.conheceuFazendeiro == false)
                dialogueManager.StartingDialogue(2, 4);
            else if (estadoDeMundo.save.conheceuFazendeiro == true)
                dialogueManager.StartingDialogue(10, 13);
        }
        else if (estadoDeMundo.save.turno == 2 && estadoDeMundo.save.fimIntroducaoTurno2 == false)
        {
            dialogueManager.StartingDialogue(14, 14);
        }
        else if (estadoDeMundo.save.turno == 3 && estadoDeMundo.save.fimIntroducaoTurno3 == false)
        {
            dialogueManager.StartingDialogue(14, 14);
        }
        else if (estadoDeMundo.save.turno == 4 && estadoDeMundo.save.fimIntroducaoTurno4 == false)
        {
            StartDialogue(45, 45);
        }
        else if (estadoDeMundo.save.turno == 5 && estadoDeMundo.save.fimIntroducaoTurno5 == false)
        {
            StartDialogue(59, 59);
        }
        else if (estadoDeMundo.save.turno == 6 && estadoDeMundo.save.fimIntroducaoTurno6 == false)
        {
            StartDialogue(80, 80);
        }
        else if (estadoDeMundo.save.turno == 7 && estadoDeMundo.save.fimIntroducaoTurno7 == false)
        {
            DTplayer.StartDialogue(81,81);
        }
        else if (estadoDeMundo.save.turno == 8 && estadoDeMundo.save.fimIntroducaoTurno8 == false)
        {
            StartDialogue(95, 95);
        }
        else if (estadoDeMundo.save.turno == 9 && estadoDeMundo.save.fimIntroducaoTurno9 == false)
        {
            StartDialogue(111, 111);
        }
        else if (estadoDeMundo.save.turno == 10 && estadoDeMundo.save.fimIntroducaoTurno10 == false)
        {
            StartDialogue(121, 121);
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
            estadoDeMundo.save.conheceuFazendeiro = true;
            GetComponentInParent<FazerAndar>()
                .AndePara(player.transform.position);
        }
        else if (lastSentence == 14)
        {
            GetComponentInParent<FazerAndar>()
                .AndePara(new Vector2(transform.position.x + 14, transform.position.y));
        }

        if (estadoDeMundo.save.turno == 2)
        {
            //introdução
            if (lastSentence == 15)
            {
                if (estadoDeMundo.save.AceitouAOfertaDoEmpresarioRuim == true)
                {
                    dialogueManager.StartingDialogue(15, 18);
                }
                else if (estadoDeMundo.save.AceitouAOfertaDoEmpresarioRuim == false)
                    dialogueManager.StartingDialogue(19, 21);
            }
            else if (lastSentence == 19 || lastSentence == 22)
            {
                dialogueManager.StartingDialogue(22, 22);
            }
            else if (lastSentence == 23)
            {
                if (estadoDeMundo.save.AceitouLiberarAguasParaFazendeiro == true)
                    dialogueManager.StartingDialogue(23, 25);
                else if (estadoDeMundo.save.AceitouLiberarAguasParaFazendeiro == false)
                    dialogueManager.StartingDialogue(27, 29);
            }
            else if (lastSentence == 26)
                DTplayer.StartDialogue(19, 19);
            else if (lastSentence == 27 || lastSentence == 30)
                FindObjectOfType<DTEmpresarioRuim>().fazerAndar.AndeParaOPlayer();
            else if (lastSentence == 32)
                DTplayer.StartDialogue(23, 23);
            else if (lastSentence == 33)
                FindObjectOfType<DTFazendeiro>().StartDialogue(3, 3);
            else if (lastSentence == 34)
                DTplayer.StartDialogue(29, 29);

            //resto
            else if (lastSentence == 131)
                DTplayer.StartDialogue(114, 114);
        }
        else if (estadoDeMundo.save.turno == 3)
        {
            //introdução
            if (lastSentence == 15)
            {
                if (estadoDeMundo.save.aceitouPlantacaoDePlantaNaFloresta == true)
                    StartDialogue(34, 35);
                else if (estadoDeMundo.save.aceitouPlantacaoDePlantaNaFloresta == false)
                    StartDialogue(36, 37);
            }
            else if (lastSentence == 36 || lastSentence == 38)
            {
                if (estadoDeMundo.save.aceitouCompartilharMaquinasFazendeiro == true)
                    StartDialogue(38, 39);
                else if (estadoDeMundo.save.aceitouCompartilharMaquinasFazendeiro == false)
                    StartDialogue(40, 41);
            }
            else if (lastSentence == 40 || lastSentence == 42)
                DTplayer.StartDialogue(30, 30);
            else if (lastSentence == 43)
                DTplayer.StartDialogue(32,32);
            else if (lastSentence == 44)
                DTplayer.StartDialogue(34, 34);
            else if (lastSentence == 45)
                DTplayer.StartDialogue(36, 36);

            //puzzle
            else if (lastSentence == 132)
                DTplayer.StartDialogue(124, 124);

        }
        else if (estadoDeMundo.save.turno == 4)
        {
            if (lastSentence == 46)
                DTplayer.StartDialogue(45, 45);
            else if (lastSentence == 47)
            {
                if (estadoDeMundo.save.investiuHidreletrica == true
                    && estadoDeMundo.save.investiuMaquinas == true)
                    StartDialogue(47, 50);
                else if (estadoDeMundo.save.investiuHidreletrica == true
                    || estadoDeMundo.save.investiuMaquinas == false)
                    StartDialogue(47, 48);
                else if (estadoDeMundo.save.investiuMaquinas == true)
                    StartDialogue(49, 50);
            }
            else if (lastSentence == 49 || lastSentence == 51)
            {
                if (estadoDeMundo.save.aceitouCompraERDoProjeto == true)
                    StartDialogue(51, 52);
                else if (estadoDeMundo.save.aceitouCompraERDoProjeto == false)
                    StartDialogue(55, 56);
            }
            else if (lastSentence == 53)
                DTplayer.StartDialogue(46, 46);
            else if (lastSentence == 55)
                DTplayer.StartDialogue(47, 47);
            else if (lastSentence == 57)
                DTplayer.StartDialogue(48, 48);
            else if (lastSentence == 58)
                DTplayer.StartDialogue(56, 56);
            else if (lastSentence == 59)
            {
                player.emDialogo = true;
                FindObjectOfType<DTEmpresarioBom>().fazerAndar.AndeParaOPlayer();
            }
                



        }
        else if (estadoDeMundo.save.turno == 5)
        {
            if (lastSentence == 60)
            {
                if (estadoDeMundo.save.aceitouDoarDinheiroER == true)
                    StartDialogue(60, 61);
                else if (estadoDeMundo.save.aceitouDoarDinheiroER == false)
                    StartDialogue(62, 63);
            }
            else if (lastSentence == 62 || lastSentence == 64)
            {
                if (estadoDeMundo.save.aceitouEBComprarTerrenoFazendeiro == true)
                    StartDialogue(64, 65);
                else if (estadoDeMundo.save.aceitouEBComprarTerrenoFazendeiro == false)
                    StartDialogue(66, 67);
            }
            else if (lastSentence == 66 || lastSentence == 68)
            {
                if (estadoDeMundo.save.aceitouEBParticiparProjetoRemedios == true)
                    StartDialogue(69, 70);
                else if (estadoDeMundo.save.aceitouEBParticiparProjetoRemedios == false)
                    StartDialogue(73, 75);
            }
            else if (lastSentence == 71)
                DTplayer.StartDialogue(59, 59);
            else if (lastSentence == 72)
            {
                if (estadoDeMundo.save.aceitouCompraERDoProjeto == true)
                    StartDialogue(72, 72);
                else
                    DTplayer.StartDialogue(60, 60);

            }
            else if (lastSentence == 73 || lastSentence == 76)
                DTplayer.StartDialogue(60, 60);
            else if (lastSentence == 77)
                DTplayer.StartDialogue(66, 66);
            else if (lastSentence == 79)
                DTplayer.StartDialogue(67, 67);
            else if (lastSentence == 80)
                FindObjectOfType<DTEmpresarioBom>().StartDialogue(27,27);



        }

        else if (estadoDeMundo.save.turno == 6)
        {
            if (lastSentence == 81)
            {
                if (estadoDeMundo.save.ONUInvestiuSalaContorle5 == true)
                    StartDialogue(81, 81);
                else if (estadoDeMundo.save.ONUInvestiuMaquinaria5 == true)
                    StartDialogue(82, 82);
                else if (estadoDeMundo.save.ONUInvestiuHidreletrica5 == true)
                    StartDialogue(83, 83);
                else if (estadoDeMundo.save.ONUInvestiuExaustores5 == true)
                    StartDialogue(84, 84);

            }
            else if (lastSentence > 81 && lastSentence < 86)
                StartDialogue(85, 85);
            else if (lastSentence == 86)
                DTplayer.StartDialogue(69, 69);
            else if (lastSentence == 87)
                DTplayer.StartDialogue(76, 76);
            else if (lastSentence == 88)
                DTplayer.StartDialogue(77, 78);
            else if (lastSentence == 90)
                DTplayer.StartDialogue(79, 79);
            else if (lastSentence == 91)
                estadoDeMundo.save.fimIntroducaoTurno6 = true;


        }

        else if (estadoDeMundo.save.turno == 7)
        {
            if (lastSentence == 92)
                DTplayer.StartDialogue(82, 82);
            else if (lastSentence == 93)
                DTplayer.StartDialogue(88, 88);
            else if (lastSentence == 94)
                DTplayer.StartDialogue(89, 89);
            else if (lastSentence == 95)
            {
                estadoDeMundo.save.fimIntroducaoTurno7 = true;
            }
        }

        else if (estadoDeMundo.save.turno == 8)
        {
            if (lastSentence == 96)
            {
                
                if (estadoDeMundo.save.aceitouDarAguaFazendeiro7 == false)
                    StartDialogue(96, 97);
                else if (estadoDeMundo.save.aceitouDarAguaFazendeiro7 == true)
                    StartDialogue(100, 101);


            }
            else if (lastSentence == 98)
                DTplayer.StartDialogue(90,90);
            else if (lastSentence == 100)
                DTplayer.StartDialogue(91, 91);
            else if (lastSentence == 102)
                DTplayer.StartDialogue(92, 92);
            else if (lastSentence == 104)
                DTplayer.StartDialogue(91, 91);
            else if (lastSentence == 105)
            {
                
                if (estadoDeMundo.save.biancaInvestiuMaquinas7 == true)
                    StartDialogue(105, 105);
                else if (estadoDeMundo.save.biancaInvestiuHidreletrica7 == true)
                    StartDialogue(106, 106);
                else
                {
                    estadoDeMundo.save.biancaInvestiuHidreletrica7 = true;
                    StartDialogue(106, 106);
                }

            }
            else if (lastSentence == 106 || lastSentence == 107)
                DTplayer.StartDialogue(93, 93);
            else if (lastSentence == 108)
                DTplayer.StartDialogue(94, 94);
            else if (lastSentence == 109)
                DTplayer.StartDialogue(95, 95);
            else if (lastSentence == 110)
                DTplayer.StartDialogue(96, 96);
            else if (lastSentence == 111)
                DTplayer.StartDialogue(97, 97);
        }

        else if (estadoDeMundo.save.turno == 9)
        {
            if (lastSentence == 112)
            {
                if (estadoDeMundo.save.InvestiuSalaContorle8 == true)
                    StartDialogue(112, 112);
                else if (estadoDeMundo.save.InvestiuMaquinaria8 == true)
                    StartDialogue(113, 113);
                else if (estadoDeMundo.save.InvestiuHidreletrica8 == true)
                    StartDialogue(114, 114);
                else if (estadoDeMundo.save.InvestiuExaustores8 == true)
                    StartDialogue(115, 115);
                else
                {
                    estadoDeMundo.save.InvestiuExaustores8 = true;
                    estadoDeMundo.save.avancoProjeto++;
                    estadoDeMundo.save.relacaoGovernador++;
                    StartDialogue(115, 115);
                }

            }
            else if (lastSentence > 112 && lastSentence < 116)
            {
                estadoDeMundo.save.avancoProjeto += 2;
                StartDialogue(116, 116);
            }
                
            else if (lastSentence == 117)
                DTplayer.StartDialogue(98, 98);
            else if (lastSentence == 119)
                DTplayer.StartDialogue(99, 99);
            else if (lastSentence == 120)
                DTplayer.StartDialogue(100, 100);
            else if (lastSentence == 121)
                estadoDeMundo.save.fimIntroducaoTurno9 = true;


        }

        else if (estadoDeMundo.save.turno == 10)
        {
            if (lastSentence == 122)
            {
                if (estadoDeMundo.save.projetoSucesso == true)
                    StartDialogue(122, 122);
                else
                    StartDialogue(127,127);
            }
            //sucesso
            else if (lastSentence == 123)
                DTplayer.StartDialogue(101, 101);
            else if (lastSentence == 124)
                DTplayer.StartDialogue(102, 102);
            else if (lastSentence == 125)
                DTplayer.StartDialogue(103, 103);

            else if (lastSentence == 126)
            {
                player.emDialogo = true;
                DTplayer.StartDialogue(104, 104, 2f);
            }
                
            else if (lastSentence == 127)
                DTplayer.StartDialogue(105, 105);

            //fracasso
            else if (lastSentence == 128)
                DTplayer.StartDialogue(109, 109);
            else if (lastSentence == 129)
                DTplayer.StartDialogue(110, 110);
            else if (lastSentence == 130)
                DTplayer.StartDialogue(111, 111);
        }
    }
}