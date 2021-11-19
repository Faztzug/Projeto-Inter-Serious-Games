using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleExtintor : MonoBehaviour
{
    private VerificarTurnoAtual verificarTurno;
    private EstadoDeMundo estado;

    private void Start()
    {
        estado = FindObjectOfType<EstadoDeMundo>();
        verificarTurno = GetComponent<VerificarTurnoAtual>();
        if (estado.save.turno != 2 || (estado.save.turno == 2 && estado.save.apagouIncendio2 == true))
        {
            Debug.Log("Extintor deveria não ser pegavel");
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
            
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
