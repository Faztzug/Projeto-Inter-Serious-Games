using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegurancasCollider : MonoBehaviour
{
    EstadoDeMundo estado;

    private void Start()
    {
        estado = FindObjectOfType<EstadoDeMundo>();

        if(estado.save.turno == 5)
        {
            if(estado.save.conversouComGovernador5 == false)
            {
                gameObject.SetActive(false);
            }
        }
        else if(estado.save.turno != 5)
        {
            gameObject.SetActive(false);
        }
    }
}
