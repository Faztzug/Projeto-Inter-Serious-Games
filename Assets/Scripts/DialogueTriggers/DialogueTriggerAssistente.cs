using UnityEngine;

public class DialogueTriggerAssistente : DialogueTrigger
{
    public override void Start()
    {
        base.Start();
        if (estadoDeMundo.save.turno == 2 && estadoDeMundo.save.fimIntroducaoTurno2 == true)
            fazerAndar.PararAndar();
        else if(estadoDeMundo.save.turno == 3 && estadoDeMundo.save.fimIntroducaoTurno3 == true)
            fazerAndar.PararAndar();
        else if (estadoDeMundo.save.turno == 4 && estadoDeMundo.save.fimIntroducaoTurno4 == true)
        { }
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
        }
        else if (estadoDeMundo.save.turno == 3)
        {
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
    }
}