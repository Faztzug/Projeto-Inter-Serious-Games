using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmeAnimation : MonoBehaviour
{
    EstadoDeMundo estado;
    [SerializeField] string alarmeSom;
    MusicPlayer music;
    [SerializeField] string lab1;
    [SerializeField] string lab2;


    void Start()
    {

        music = FindObjectOfType<MusicPlayer>();
        estado = FindObjectOfType<EstadoDeMundo>();

        if(estado.save.turno == 2 && estado.save.fimIntroducaoTurno2 == true
            && estado.save.apagouIncendio2 == false)
        {
            if(gameObject.scene.name == lab1)
            {
                GetComponent<Animator>().SetTrigger("Incendio");
                estado.save.alarmeIncendio2 = true;
                music.ChangeMusic(alarmeSom);
            } else if(gameObject.scene.name == lab2 && estado.save.alarmeIncendio2 == true)
            {
                GetComponent<Animator>().SetTrigger("Incendio");
                
                music.ChangeMusic(alarmeSom);
            }

            
        }
        else if (estado.save.turno == 3 && estado.save.fimIntroducaoTurno3 == true
           && estado.save.puzzleExaustores3Resolvido == false)
        {
            if (gameObject.scene.name == lab1)
            {
                GetComponent<Animator>().SetTrigger("Incendio");
                music.ChangeMusic(alarmeSom);
                estado.save.alarme3 = true;
            }
            else if (gameObject.scene.name == lab2 && estado.save.alarme3 == true)
            {
                GetComponent<Animator>().SetTrigger("Incendio");

                music.ChangeMusic(alarmeSom);
            }
            
        }
        else if (estado.save.turno == 4 && estado.save.fimIntroducaoTurno4 == true
           && estado.save.fimDialogoGovernadorTurno4 == true && estado.save.puzzleTurno4Concluido == false
           && estado.save.rioPurificado4 == false)
        {
            if (gameObject.scene.name == lab1)
            {
                GetComponent<Animator>().SetTrigger("Incendio");
                music.ChangeMusic(alarmeSom);
                estado.save.alarmePoluicaoRio4 = true;
            }
            else if (gameObject.scene.name == lab2 && estado.save.alarmePoluicaoRio4 == true)
            {
                GetComponent<Animator>().SetTrigger("Incendio");

                music.ChangeMusic(alarmeSom);
            }
            
        }
        else if (estado.save.turno == 9 && estado.save.fimIntroducaoTurno9 == true
           && (estado.save.puzzleConcertouHidreletrica9 == false 
           || estado.save.puzzleConcertouMaquinas9 == false
           || estado.save.puzzleConcertouSalaDeControle9 == false))
        {
            if (gameObject.scene.name == lab1)
            {
                GetComponent<Animator>().SetTrigger("Incendio");
                music.ChangeMusic(alarmeSom);
                estado.save.alarme9 = true;
            }
            else if (gameObject.scene.name == lab2 && estado.save.alarme9 == true)
            {
                GetComponent<Animator>().SetTrigger("Incendio");

                music.ChangeMusic(alarmeSom);
            }

            
        }
    }

    
}
