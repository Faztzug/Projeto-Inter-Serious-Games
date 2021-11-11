using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool[] isFull;
    public GameObject[] slots;
    public int selectID;
    public Item selectedItem;
    [HideInInspector] public SlotsManager slotsManager;


    private void Start()
    {
        slotsManager = FindObjectOfType<SlotsManager>();
        slots = GameObject.FindGameObjectsWithTag("Slot");
        int slotsLength = slots.Length;

        if(slots[0] != null)
        slots[0].transform.parent.gameObject.SetActive(false);
    }

    public void EliminarItemSelecionado()
    {
        selectedItem = null;
        slotsManager.EliminarItemSelecionado();
    }
}
