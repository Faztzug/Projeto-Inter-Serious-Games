using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turno10Collider : MonoBehaviour
{
    EstadoDeMundo estado;
    // Start is called before the first frame update
    void Start()
    {
        estado = FindObjectOfType<EstadoDeMundo>();

        if (estado.save.turno != 10
            || estado.save.iniciarPuzzleTurno10 == false)
            Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (estado.save.preparouArmadilha10 == true)
            Destroy(this.gameObject);
    }
}
