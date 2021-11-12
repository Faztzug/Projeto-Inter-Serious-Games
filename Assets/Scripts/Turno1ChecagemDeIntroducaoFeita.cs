using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turno1ChecagemDeIntroducaoFeita : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (FindObjectOfType<EstadoDeMundo>().save.conheceuFazendeiro == true)
            FindObjectOfType<DialogueTriggerAssistente>().transform.parent.gameObject.SetActive(false);
    }

    
}
