using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzleColetarAgua : MonoBehaviour
{
    public GameObject itemObject;
    private Item itemClass;
    private string prefabName;
    [SerializeField]
    private int turnoAtivar = 4;
    private EstadoDeMundo estado;
    [SerializeField]
    private GameObject spawnItem;
    [SerializeField]
    private Item agentePurificador;

    private void Start()
    {
        itemClass = itemObject.GetComponent<Item>();
        prefabName = itemClass.itemName;
        estado = FindObjectOfType<EstadoDeMundo>();

        if (estado.save.turno != turnoAtivar
            || estado.save.puzzleTurno4Concluido == true)
            gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player entrou no trigger");
            Inventory inventario = collision.GetComponent<Inventory>();
            DialogueTriggerPlayer DTPlayer = collision.GetComponent<DialogueTriggerPlayer>();

            if (inventario.selectedItem != null && inventario.selectedItem.itemName == agentePurificador.itemName)
            {
                Debug.Log("itens Iguais");
                gameObject.SetActive(false);
                inventario.EliminarItemSelecionado();
                
                DTPlayer.StartDialogue(136, 138);
                estado.save.rioPurificado4 = true;
                estado.save.alarmePoluicaoRio4 = false;
                
            }
            else if (inventario.selectedItem == null || inventario.selectedItem.itemName != prefabName)
            {
                Debug.Log("Player sem item selecionado");
                if(inventario.slotsManager.AcharItem(spawnItem.name))
                    DTPlayer.StartDialogue(134, 134);
                else
                    DTPlayer.StartDialogue(133, 133);
            }
            else if (inventario.selectedItem != null && inventario.selectedItem.itemName == prefabName)
            {
                Debug.Log("itens Iguais");
                gameObject.SetActive(false);
                inventario.EliminarItemSelecionado();
                Instantiate(spawnItem, inventario.transform.position, inventario.transform.rotation);
                DTPlayer.StartDialogue(133, 134);
            }
        }
    }
}
