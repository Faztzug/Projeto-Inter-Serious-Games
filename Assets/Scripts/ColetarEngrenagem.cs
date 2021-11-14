using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColetarEngrenagem : MonoBehaviour
{
    private void Start()
    {
        if(FindObjectOfType<EstadoDeMundo>().save.coletouFusivel == true)
        {
            this.gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<EstadoDeMundo>().save.coletouFusivel = true;
            collision.GetComponent<DialogueTrigger>().StartDialogue(10, 11);
            this.gameObject.SetActive(false);
        }
    }
}
