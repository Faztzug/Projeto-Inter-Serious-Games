using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrilsToxicos : MonoBehaviour
{
    EstadoDeMundo estado;
    // Start is called before the first frame update
    void Start()
    {
        estado = FindObjectOfType<EstadoDeMundo>();

        if (estado.save.turno != 4 || estado.save.olhouCamerasSeguranca4 == false)
            gameObject.SetActive(false);
    }

    
}
