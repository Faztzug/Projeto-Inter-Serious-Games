using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotsManager : MonoBehaviour
{
    [SerializeField] private Slot[] slots;
    public int selectID;
    public GameObject selected;
    private Inventory inventario;

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
        
        
    }

    public void EliminarItemSelecionado()
    {
        selected = null;
        Destroy(slots[selectID].transform.GetChild(0).gameObject);
        
    }

}
