using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool[] isFull;
    public GameObject[] slotsGameObject;
    
    public int selectID;
    public Item selectedItem;
    [HideInInspector] public SlotsManager slotsManager;


    private void Start()
    {
        slotsManager = FindObjectOfType<SlotsManager>();
        slotsGameObject = GameObject.FindGameObjectsWithTag("Slot");
        int slotsLength = slotsGameObject.Length;

        if(slotsGameObject[0] != null)
        slotsGameObject[0].transform.parent.gameObject.SetActive(false);
    }

    public void EliminarItemSelecionado()
    {
        selectedItem = null;
        slotsManager.EliminarItemSelecionado();
    }
}
