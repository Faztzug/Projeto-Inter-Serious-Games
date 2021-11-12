using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FimDeTurno : MonoBehaviour
{
    private EstadoDeMundo estado;
    private DialogueTriggerPlayer dtPlayer;
    [SerializeField] private Item[] itens;
    Inventory inventario;

    private void Start()
    {
        estado = FindObjectOfType<EstadoDeMundo>();
        dtPlayer = estado.gameObject.GetComponent<DialogueTriggerPlayer>();
        inventario = estado.gameObject.GetComponent<Inventory>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            

            if (estado.save.testColetouPecaMaquinaria == true && estado.save.testColetouTerra == true)
            {

                Destroy(inventario.slotsManager.AcharItem(itens[0].itemName).gameObject);
                Destroy(inventario.slotsManager.AcharItem(itens[1].itemName).gameObject);

                dtPlayer.StartDialogue(16, 18);

                

            }
        }
        
    }
}
