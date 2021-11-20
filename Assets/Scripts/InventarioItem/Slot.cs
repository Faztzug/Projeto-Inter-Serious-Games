using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    private Inventory inventory;
    public int i;
    public SlotsManager slotsManager;
    public GameObject itemChild;
    [HideInInspector]
    public Image image;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        image = GetComponent<Image>();
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
