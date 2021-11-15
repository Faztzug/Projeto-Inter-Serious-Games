using UnityEngine;

public class DialogueTriggerAssistente : DialogueTrigger
{
    public override void Start()
    {
        base.Start();
        if (estadoDeMundo.save.turno == 2 && estadoDeMundo.save.fimIntroducaoTurno2 == true)
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

        if (estadoDeMundo.save.turno == 2 && estadoDeMundo.save.fimIntroducaoTurno2 == false)
        {
            dialogueManager.StartingDialogue(14, 14);
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
    }
}