using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsarItem : MonoBehaviour
{
    private Transform maquina;
    public GameObject item;
    private GameObject slot;

    private void Start()
    {
        maquina = GameObject.FindGameObjectWithTag("Maquina").transform;
        slot = GameObject.Find("Slots");
    }

    public void Use()
    {
        slot.active = false;
        Vector2 maquinaPos = new Vector2(maquina.position.x, maquina.position.y);
        Instantiate(item, maquinaPos, Quaternion.identity);
        Destroy(gameObject);
    }
}
