using UnityEngine;

public class PuzzlePoteMaquina : MonoBehaviour
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
                gameObject.SetActive(false);
                inventario.EliminarItemSelecionado();
            }
        }
    }
}