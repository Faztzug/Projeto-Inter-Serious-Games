using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class VerificarTurnoAtual : MonoBehaviour
{
    private EstadoDeMundo estado;
    public bool[] turnos = new bool[10];


    private void Start()
    {
        estado = FindObjectOfType<EstadoDeMundo>();
    }

    public bool Verificar()
    {
        if (turnos[estado.save.turno - 1] == true)
            return true;
        else
            return false;
    }

}
