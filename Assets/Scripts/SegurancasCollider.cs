using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegurancasCollider : MonoBehaviour
{
    EstadoDeMundo estado;
    VerificarTurnoAtual turnoAtual;

    private void Start()
    {
        estado = FindObjectOfType<EstadoDeMundo>();
        turnoAtual = GetComponent<VerificarTurnoAtual>();

        if(turnoAtual.Verificar() == false)
        {
            gameObject.SetActive(false);
        }

        if(estado.save.turno == 5)
        {
            if(estado.save.conversouComGovernador5 == false)
            {
                gameObject.SetActive(false);
            }
        }
        /*else if(estado.save.turno != 5)
        {
            gameObject.SetActive(false);
        }*/
    }
}
