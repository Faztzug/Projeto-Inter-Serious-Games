using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosicionarItemMicrofone : MonoBehaviour
{
    private EstadoDeMundo estado;

    [SerializeField]
    private Item ItemMicrofone;
    DialogueTriggerPlayer DTPlayer;
    private Inventory inventory;

    private void Start()
    {
        estado = FindObjectOfType<EstadoDeMundo>();

        if (estado.save.turno != 6)
            Destroy(this.gameObject);

        DTPlayer = FindObjectOfType<DialogueTriggerPlayer>();
        inventory = FindObjectOfType<Inventory>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player entrou no trigger");

            if (inventory.selectedItem != null && inventory.selectedItem.itemName == ItemMicrofone.itemName)
            {
                
                Debug.Log("itens Iguais");
                //gameObject.SetActive(false);
                inventory.EliminarItemSelecionado();
                estado.save.posicionouMicrofone6 = true;

            }
                TriggerDialogo();
        }
    }

    public void TriggerDialogo()
    {
        if (estado.save.posicionouMicrofone6 == true
                    && estado.save.posicionouCameraEsquerda6 == true
                    && estado.save.posicionouCameraMeio6 == true
                    && estado.save.posicionouCameraDireita6 == true)
        {
            DTPlayer.StartDialogue(169, 170);
            Destroy(this.gameObject);
        }
            
        else if(estado.save.posicionouMicrofone6 == true)
            DTPlayer.StartDialogue(168, 168);
    }
}
