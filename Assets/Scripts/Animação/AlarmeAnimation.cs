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
        else if (estado.save.turno == 3 && estado.save.fimIntroducaoTurno3 == true
           && estado.save.InvestiuExaustores8 == false)
        {
            GetComponent<Animator>().SetTrigger("Incendio");
            
        }
    }

    
}
