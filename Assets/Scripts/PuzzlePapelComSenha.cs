using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePapelComSenha : MonoBehaviour
{
    EstadoDeMundo estado;
    DialogueTrigger DTPlayer;

    private void Start()
    {
        estado = FindObjectOfType<EstadoDeMundo>();

        if (estado.save.turno != 9 ||
            estado.save.fimIntroducaoTurno9 == false
            || estado.save.puzzleConcertouSalaDeControle9 == true)
        {
            Destroy(this.transform.parent.gameObject);
        }

        DTPlayer = FindObjectOfType<DialogueTriggerPlayer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (estado.save.puzzleConcertouSalaDeControle9 == true)
            Destroy(this.transform.parent.gameObject);

        else if(estado.save.puzzleAverigouOPC9 == true)
        {
            estado.save.puzzleConcertouSalaDeControle9 = true;
            DTPlayer.StartDialogue(199, 200);
            Destroy(this.transform.parent.gameObject);
        }
        

    }
}
