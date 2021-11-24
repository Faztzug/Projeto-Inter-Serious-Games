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

        if (FindObjectOfType<EstadoDeMundo>().save.turno != 1)
            gameObject.SetActive(false);

        if(FindObjectOfType<EstadoDeMundo>().save.coletouFusivel == true)
            gameObject.SetActive(false);
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
                FindObjectOfType<EstadoDeMundo>().save.coletouFusivel = true;
            }
        }
    }
}