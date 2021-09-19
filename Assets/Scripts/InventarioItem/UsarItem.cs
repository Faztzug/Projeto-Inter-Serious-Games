using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsarItem : MonoBehaviour
{
    private Transform player;
    public GameObject item;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void Use()
    {
        Vector2 playerPos = new Vector2(player.position.x, player.position.y + 2);
        Instantiate(item, playerPos, Quaternion.identity);
        Destroy(gameObject);
    }
}
