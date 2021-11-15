using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turno1ChecagemDeIntroducaoFeita : MonoBehaviour
{
    private EstadoDeMundo estado;
    // Start is called before the first frame update
    void Start()
    {
        estado = FindObjectOfType<EstadoDeMundo>();
        if(estado.save.turno == 1)
        {
            if (estado.save.conheceuFazendeiro == true)
                FindObjectOfType<DialogueTriggerAssistente>()
                    .transform.parent.gameObject.SetActive(false);
        }
        
    }

    
}
