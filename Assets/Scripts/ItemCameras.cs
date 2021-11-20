using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCameras : MonoBehaviour
{
    EstadoDeMundo estado;
    // Start is called before the first frame update
    void Start()
    {
        estado = FindObjectOfType<EstadoDeMundo>();

        if (estado.save.coletouCamera6 == true)
            Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            estado.save.coletouCamera6 = true;
        }
    }


}
