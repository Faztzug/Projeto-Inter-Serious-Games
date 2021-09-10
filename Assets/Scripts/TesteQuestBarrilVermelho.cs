using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesteQuestBarrilVermelho : MonoBehaviour
{
    EstadoDeMundo estadoDeMundo;

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            estadoDeMundo = collision.gameObject.GetComponent<EstadoDeMundo>();
            if(estadoDeMundo.testeQuestBarrilVermelho == true)
            {
                estadoDeMundo.testeBarrilVermelhoDestruido = true;
                Destroy(gameObject);
            }
            
        }
    }
}
