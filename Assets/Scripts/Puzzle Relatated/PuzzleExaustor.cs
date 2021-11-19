using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleExaustor : MonoBehaviour
{
    public GameObject itemObject;
    private Item itemClass;
    private string prefabName;
    [SerializeField]
    private int turnoAtivar = 3;
    private EstadoDeMundo estado;

    private void Start()
    {
        itemClass = itemObject.GetComponent<Item>();
        prefabName = itemClass.itemName;
        estado = FindObjectOfType<EstadoDeMundo>();

        if (estado.save.turno != turnoAtivar
            || estado.save.puzzleExaustores3Resolvido == true)
            gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player entrou no trigger");
            Inventory inventario = collision.GetComponent<Inventory>();
            DialogueTriggerPlayer DTPlayer = collision.GetComponent<DialogueTriggerPlayer>();

            if(inventario.selectedItem == null || inventario.selectedItem.itemName != prefabName)
            {
                Debug.Log("Player sem item selecionado");
                DTPlayer.StartDialogue(126, 126);
            }
            else if (inventario.selectedItem != null && inventario.selectedItem.itemName == prefabName)
            {
                DTPlayer.StartDialogue(126, 127);
                Debug.Log("itens Iguais");
                gameObject.SetActive(false);
                inventario.EliminarItemSelecionado();
                FindObjectOfType<EstadoDeMundo>().save.puzzleExaustores3Resolvido = true;
            }
        }
    }
}
