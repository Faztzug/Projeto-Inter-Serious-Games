using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColetarTerra : MonoBehaviour
{
    private void Start()
    {
        if (FindObjectOfType<EstadoDeMundo>().testColetouTerra == true)
        {
            this.gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<EstadoDeMundo>().testColetouTerra = true;
            collision.GetComponent<DialogueTrigger>().StartDialogue(13, 15);
            this.gameObject.SetActive(false);
        }
    }
}
