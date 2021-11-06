using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColetarTerra : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<EstadoDeMundo>().testColetouTerra = true;
        }
    }
}
