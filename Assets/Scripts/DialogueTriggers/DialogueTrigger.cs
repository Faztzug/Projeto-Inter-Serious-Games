using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{

    protected EstadoDeMundo estadoDeMundo;
    protected DialogueManager dialogueManager;
    protected PlayerControl player;
    protected DialogueTriggerPlayer DTplayer;
    protected FazerAndar fazerAndar;
    

    private void Start()
    {
        estadoDeMundo = FindObjectOfType<EstadoDeMundo>();
        dialogueManager = GetComponent<DialogueManager>();
        player = estadoDeMundo.gameObject.GetComponent<PlayerControl>();
        DTplayer = estadoDeMundo.gameObject.GetComponent<DialogueTriggerPlayer>();

        if (gameObject.GetComponentInParent<FazerAndar>() != null)
            fazerAndar = gameObject.GetComponentInParent<FazerAndar>();
    }

    public virtual void StartDialogue()
    {
        dialogueManager.StartingDialogue(0, dialogueManager.numberSentences - 1);
        
    }

    public virtual void StartDialogue(int start, int end)
    {
        dialogueManager.StartingDialogue(start, end);
    }

    public virtual void EndOfDialogue(int lastSentence, string NPCname)
    {
        player.emDialogo = false;
        Debug.Log("fim de dialogo com " + NPCname + "Ultima fala foi: " + lastSentence);
    }

}
