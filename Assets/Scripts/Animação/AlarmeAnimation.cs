using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmeAnimation : MonoBehaviour
{
    EstadoDeMundo estado;
    [SerializeField] string alarmeSom;
    MusicPlayer music;
    
    void Start()
    {

        music = FindObjectOfType<MusicPlayer>();
        estado = FindObjectOfType<EstadoDeMundo>();
        if(estado.save.turno == 2 && estado.save.fimIntroducaoTurno2 == true
            && estado.save.apagouIncendio2 == false)
        {
            GetComponent<Animator>().SetTrigger("Incendio");
            estado.save.alarmeIncendio2 = true;
            music.ChangeMusic(alarmeSom);
        }
        else if (estado.save.turno == 3 && estado.save.fimIntroducaoTurno3 == true
           && estado.save.puzzleExaustores3Resolvido == false)
        {
            GetComponent<Animator>().SetTrigger("Incendio");
            music.ChangeMusic(alarmeSom);
        }
        else if (estado.save.turno == 4 && estado.save.fimIntroducaoTurno4 == true
           && estado.save.fimDialogoGovernadorTurno4 == true && estado.save.puzzleTurno4Concluido == false)
        {
            GetComponent<Animator>().SetTrigger("Incendio");
            music.ChangeMusic(alarmeSom);
            estado.save.alarmePoluicaoRio4 = true;
        }
        else if (estado.save.turno == 9 && estado.save.fimIntroducaoTurno9 == true
           && (estado.save.puzzleConcertouHidreletrica9 == false 
           || estado.save.puzzleConcertouMaquinas9 == false
           || estado.save.puzzleConcertouSalaDeControle9 == false))
        {
            GetComponent<Animator>().SetTrigger("Incendio");
            music.ChangeMusic(alarmeSom);
            
        }
    }

    
}
