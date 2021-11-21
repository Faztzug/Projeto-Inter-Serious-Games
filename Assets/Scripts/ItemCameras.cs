using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCameras : MonoBehaviour
{
    EstadoDeMundo estado;
    string itemCameraName;
    [SerializeField] int itemCameraNumber;
    Inventory inventario;
    // Start is called before the first frame update
    void Start()
    {
        estado = FindObjectOfType<EstadoDeMundo>();
        itemCameraName = GetComponent<PickUp>().itemButton.GetComponent<Item>().itemName;
        inventario = FindObjectOfType<Inventory>();

        if (estado.save.coletouCamera6 == true)
            Destroy(this.gameObject);

        if (inventario.slotsManager.AcharItemQuantidade(itemCameraName) > itemCameraNumber)
            Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            
            if(inventario.slotsManager.AcharItemQuantidade(itemCameraName) > 2)
            estado.save.coletouCamera6 = true;
        }
    }


}
