using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AoColidirComInteragivel : MonoBehaviour
{
    public string NPCCollisionName;
    public DialogueManager NPCFalandoDM;
    public DialogueTrigger dialogueTrigger;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("NPC"))
        {
            //GetComponent<PlayerControl>().emDialogo = true;
            NPCCollisionName = collision.name;
            NPCFalandoDM = collision.GetComponent<DialogueManager>();
            dialogueTrigger = collision.GetComponent<DialogueTrigger>();
            dialogueTrigger.StartDialogue();
        }
    }

    
}
