public class DialogueTriggerEsferaTeste : DialogueTrigger
{

    public override void StartDialogue()
    {
        if (estado.save.testeQuestBarrilVermelho == false)
            dialogueManager.StartingDialogue(0, 3);
        else if (estado.save.testeQuestBarrilVermelho == true 
            && estado.save.testeBarrilVermelhoDestruido == false)
            dialogueManager.StartingDialogue(4, 4);
        else if (estado.save.testeBarrilVermelhoDestruido == true)
            dialogueManager.StartingDialogue(5, 6);
        else
            base.StartDialogue();
    }

    

    public override void EndOfDialogue(int lastSentence, string NPCname)
    {
        base.EndOfDialogue(lastSentence, NPCname);
        if (lastSentence == 4)
        {
            estado.save.testeQuestBarrilVermelho = true;
        }
        else if (lastSentence == 7)
        {
            FindObjectOfType<DialogueTriggerPlayer>().MomentoDeResponder(lastSentence, NPCname);
        }
        else if (lastSentence == 8)
            FindObjectOfType<DialogueTriggerPlayer>().StartDialogue(0,0);
        else if (lastSentence == 9)
            FindObjectOfType<DialogueTriggerPlayer>().StartDialogue(1, 1);
        
    }
}