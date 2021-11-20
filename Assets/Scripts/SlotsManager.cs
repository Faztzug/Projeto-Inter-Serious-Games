using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotsManager : MonoBehaviour
{
    [SerializeField] private Slot[] slots;
    public int selectID;
    public GameObject selected;
    private Inventory inventario;
    [SerializeField] Color corDeselecionado;
    [SerializeField] Color corSelecionado;

    void Start()
    {
        inventario = FindObjectOfType<Inventory>();

        slots = GetComponentsInChildren<Slot>();
        int slotsLength = slots.Length;

        for (int n = 0; n < slotsLength; n++)
        {
            slots[n].i = n;
            slots[n].slotsManager = this;
        }

        
    }

    public void Selecionado()
    {
        inventario.selectID = selectID;
        
        if(selected != null)
        {
            inventario.selectedItem = selected.GetComponent<Item>();
        } else 
        {
            inventario.selectedItem = null;
        }

        AplicarCorSelecao(selectID);
        
        
    }

    public void AplicarCorSelecao(int selecionadoID)
    {
        Debug.Log("Aplicando cores nos slots");
        for (int i = 0; i < slots.Length; i++)
        {
            if(slots[i].i == selecionadoID)
            {
                slots[i].image.color = corSelecionado;
            }
            else
                slots[i].image.color = corDeselecionado;
        }
    }

    public void EliminarItemSelecionado()
    {
        selected = null;
        Destroy(slots[selectID].transform.GetChild(0).gameObject);
        
    }

    public Item AcharItem(string acharItem)
    {
        Debug.Log("procurando Item: " + acharItem + " ...");

        foreach (Item item in GetComponentsInChildren<Item>())
        {
            if (item.itemName == acharItem)
            {
                Debug.Log("Item: " + acharItem + " encontrado!");
                return item;
                
            }
                
        }

        Debug.Log("Item: " + acharItem + " NÃO foi encontrado!");
        return null;
    }

}
