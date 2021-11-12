using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private Inventory inventory;
    public GameObject itemButton;

    private void Start()
    {
        inventory = FindObjectOfType<Inventory>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            for (int i = 0; i < inventory.slotsGameObject.Length; i++)
            {
                if (inventory.isFull[i] == false)
                {
                    //Vai ser adicionado.
                    inventory.isFull[i] = true;
                    Instantiate(itemButton, inventory.slotsGameObject[i].transform, false);
                    //inventory.slotsGameObject[i].GetComponent<Slot>().itemChild = itemButton;
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }
}
