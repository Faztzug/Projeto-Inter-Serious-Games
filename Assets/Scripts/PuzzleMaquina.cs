using UnityEngine;

public class PuzzleMaquina : MonoBehaviour
{
    public GameObject itemObject;
    private Item itemClass;
    private string prefabName;

    private void Start()
    {
        itemClass = itemObject.GetComponent<Item>();
        prefabName = itemClass.itemName;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player entrou no trigger");
            Inventory inventario = collision.GetComponent<Inventory>();

            if (inventario.selectedItem != null && inventario.selectedItem.itemName == prefabName)
            {
                Debug.Log("itens Iguais");
                Instantiate(itemClass.worldItem, transform.position, transform.rotation);
                inventario.EliminarItemSelecionado();
            }
        }
    }
}