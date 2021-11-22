using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CipoHidreletrica9 : MonoBehaviour
{
    EstadoDeMundo estado;
    DialogueTrigger DTPlayer;

    private void Start()
    {
        estado = FindObjectOfType<EstadoDeMundo>();

        if (estado.save.turno != 9 ||
            estado.save.fimIntroducaoTurno9 == false
            || estado.save.puzzleConcertouHidreletrica9 == true)
        {
            Destroy(this.gameObject);
        }

        DTPlayer = FindObjectOfType<DialogueTriggerPlayer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (estado.save.puzzleConcertouHidreletrica9 == true)
            Destroy(this.gameObject);

        else if (estado.save.puzzleConcertouHidreletrica9 == false)
        {
            estado.save.puzzleConcertouHidreletrica9 = true;
            DTPlayer.StartDialogue(204, 204);
            
            Destroy(this.gameObject);
        }


    }
}
