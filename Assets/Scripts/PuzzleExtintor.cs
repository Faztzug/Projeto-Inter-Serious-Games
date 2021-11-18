using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleExtintor : MonoBehaviour
{
    private VerificarTurnoAtual verificarTurno;

    private void Start()
    {
        verificarTurno = GetComponent<VerificarTurnoAtual>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (verificarTurno.Verificar())
            {
                Debug.Log("Player entrou no trigger");
            }
            
        }
    }
}
