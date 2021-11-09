using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool[] isFull;
    public GameObject[] slots;
    

    private void Start()
    {

        slots = GameObject.FindGameObjectsWithTag("Slot");
        int slotsLength = slots.Length;

        if(slots[0])
        slots[0].transform.parent.gameObject.SetActive(false);
    }
}
