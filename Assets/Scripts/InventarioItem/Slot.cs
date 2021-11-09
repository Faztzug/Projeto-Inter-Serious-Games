using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    private Inventory inventory;
    public int i;
    public SlotsManager slotsManager;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    public void Selecionar()
    {
        slotsManager.selectID = i;

        if (transform.childCount > 0)
        {
            slotsManager.selected = transform.GetChild(0).gameObject;
        } else
        {
            slotsManager.selected = null;
        }

            slotsManager.Selecionado();
        
            
    }

    private void Update()
    {
        if (transform.childCount <= 0)
        {
            inventory.isFull[i] = false;
        }
    }
}
