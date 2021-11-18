using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColetarEngrenagem : MonoBehaviour
{
    [SerializeField] Item fusivelUIPrefab;

    private void Start()
    {
        Inventory inventario = FindObjectOfType<Inventory>();
        if(FindObjectOfType<EstadoDeMundo>().save.coletouFusivel == true 
            || inventario.slotsManager.AcharItem(fusivelUIPrefab.itemName))
        {
            this.gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //collision.GetComponent<EstadoDeMundo>().save.coletouFusivel = true;
            collision.GetComponent<DialogueTrigger>().StartDialogue(10, 11);
            this.gameObject.SetActive(false);
        }
    }
}
