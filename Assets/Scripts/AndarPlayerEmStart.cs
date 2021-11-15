using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndarPlayerEmStart : MonoBehaviour
{
    private FazerAndar fazerAndar;
    [SerializeField]
    private bool[] turnos;
    private EstadoDeMundo estado;
    

    void Start()
    {
        fazerAndar = GetComponent<FazerAndar>();
        estado = FindObjectOfType<EstadoDeMundo>();

        int length = turnos.Length;

        for (int i = 0; i < length; i++)
        {
            if (estado.save.turno - 1 == i && turnos[i] == true)
                fazerAndar.AndeParaOPlayer();

        }

        
    }

    
}
