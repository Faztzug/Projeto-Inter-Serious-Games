using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FimDeTurno : MonoBehaviour
{
    private EstadoDeMundo estado;
    private DialogueTriggerPlayer dtPlayer;
    private void Start()
    {
        estado = FindObjectOfType<EstadoDeMundo>();
        dtPlayer = estado.gameObject.GetComponent<DialogueTriggerPlayer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(estado.testColetouPecaMaquinaria == true && estado.testColetouTerra == true)
        {
            dtPlayer.StartDialogue(16, 18);
        }
    }
}
