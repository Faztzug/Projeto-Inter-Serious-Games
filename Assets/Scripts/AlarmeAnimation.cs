using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmeAnimation : MonoBehaviour
{
    EstadoDeMundo estado;
    
    void Start()
    {
        estado = FindObjectOfType<EstadoDeMundo>();
        if(estado.save.turno == 2 && estado.save.fimIntroducaoTurno2 == true
            && estado.save.apagouIncendio2 == false)
        {
            GetComponent<Animator>().SetTrigger("Incendio");
            estado.save.alarmeIncendio2 = true;
        }
    }

    
}
