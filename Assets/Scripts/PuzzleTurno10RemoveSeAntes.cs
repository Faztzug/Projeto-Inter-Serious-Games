using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleTurno10RemoveSeAntes : MonoBehaviour
{
    public string florestaMeio = "Floresta_1";
    public string florestaEsquerda = "Floresta_3";
    // Start is called before the first frame update
    void Start()
    {
        DialogueTrigger dialogueTrigger = GetComponentInChildren<DialogueTrigger>();
        EstadoDeMundo estado = FindObjectOfType<EstadoDeMundo>();

        if (estado.save.turno != 10 || estado.save.iniciarPuzzleTurno10 == false)
            Destroy(this.gameObject);

        if (FindObjectOfType<DTGovernandor>() != null)
        {
            if (dialogueTrigger.dialogueData.dialogue.characterName
            == FindObjectOfType<DTGovernandor>().dialogueData.dialogue.characterName)
            {
                if(gameObject.scene.name == florestaEsquerda)
                {
                    if (estado.save.preparouArmadilha10 == false)
                        Destroy(this.gameObject);
                }
            }
        }

        if (FindObjectOfType<DTEmpresarioRuim>() != null)
        {
            if (dialogueTrigger.dialogueData.dialogue.characterName
            == FindObjectOfType<DTEmpresarioRuim>().dialogueData.dialogue.characterName)
            {
                if (gameObject.scene.name == florestaEsquerda)
                {
                    if (estado.save.preparouArmadilha10 == false)
                        Destroy(this.gameObject);
                }
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
