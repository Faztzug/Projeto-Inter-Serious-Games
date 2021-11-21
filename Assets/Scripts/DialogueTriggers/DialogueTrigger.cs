using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{

    protected EstadoDeMundo estado;
    protected DialogueManager dialogueManager;
    protected PlayerControl player;
    protected DialogueTriggerPlayer DTplayer;
    [HideInInspector] public FazerAndar fazerAndar;
    protected DialogueData dialogueData;
    

    public virtual void Start()
    {
        estado = FindObjectOfType<EstadoDeMundo>();
        dialogueManager = GetComponent<DialogueManager>();
        player = estado.gameObject.GetComponent<PlayerControl>();
        DTplayer = estado.gameObject.GetComponent<DialogueTriggerPlayer>();
        dialogueData = GetComponent<DialogueData>();

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

    public virtual void StartDialogue(int startSentence, int endSentence, float tempo)
    {
        StartCoroutine(EsperarStartDialogueCourotine(startSentence, endSentence, tempo));
    }

    protected IEnumerator EsperarStartDialogueCourotine(int startSentence, int endSentence, float tempo)
    {
        yield return new WaitForSeconds(tempo);

        StartDialogue(startSentence, endSentence);
    }

}
