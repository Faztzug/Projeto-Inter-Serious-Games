using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorDeRespostas : MonoBehaviour
{
    private int i;

    private void Awake()
    {
        i = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            i++;
            FindObjectOfType<AnswerManager>().GerarRespostas("Resposta" + i);
        }
        
        
    }
}
