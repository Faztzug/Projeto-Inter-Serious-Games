using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleHidreletrica9 : MonoBehaviour
{
    [SerializeField]
    GameObject cipo;
    EstadoDeMundo estado;
    DialogueTrigger DTPlayer;

    bool Ativar;

    private void Start()
    {
        estado = FindObjectOfType<EstadoDeMundo>();

        if (estado.save.turno != 9 ||
            estado.save.fimIntroducaoTurno9 == false
            || estado.save.concertouAMaquinaNaHidreletrica9 == true)
        {
            if (estado.save.puzzleConcertouHidreletrica9 == false 
                && estado.save.concertouAMaquinaNaHidreletrica9 == true)
                cipo.SetActive(true);
            Destroy(this.gameObject);
        }

        DTPlayer = FindObjectOfType<DialogueTriggerPlayer>();

        StartCoroutine(EsperarUmFrame());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(Ativar == true)
        {
            if (estado.save.puzzleConcertouHidreletrica9 == true)
                Destroy(this.gameObject);

            else if (estado.save.concertouAMaquinaNaHidreletrica9 == false)
            {
                estado.save.concertouAMaquinaNaHidreletrica9 = true;
                DTPlayer.StartDialogue(203, 203);
                cipo.SetActive(true);
                Destroy(this.gameObject);
            }
        }

        


    }

    IEnumerator EsperarUmFrame()
    {
        yield return new WaitForEndOfFrame();

        Ativar = true;
    }
}
