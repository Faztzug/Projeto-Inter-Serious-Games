using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotsManager : MonoBehaviour
{
    [SerializeField] private Slot[] slots;

    void Start()
    {
        slots = GetComponentsInChildren<Slot>();
        int slotsLength = slots.Length;

        for (int n = 0; n < slotsLength; n++)
        {
            slots[n].i = n;
        }

    }

}
