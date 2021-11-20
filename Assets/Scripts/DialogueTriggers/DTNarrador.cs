using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DTNarrador : DialogueTrigger
{
    [SerializeField] private string titleScreenCena;
    [SerializeField] private string maquinasCena;
    [SerializeField] private string salaControleMeioCena;

    public override void StartDialogue()
    {
        if (estado.save.turno == 2)
        {
            if(gameObject.scene.name == maquinasCena)
                DTplayer.StartDialogue(112, 112);
        }
        else if(estado.save.turno == 3)
        {
            if (gameObject.scene.name == salaControleMeioCena 
                && estado.save.fimIntroducaoTurno3 == true 
                && estado.save.puzzleExaustores3Resolvido == false)
                DTplayer.StartDialogue(125, 125);
        }
        else if (estado.save.turno == 4)
        {
            if (gameObject.scene.name == salaControleMeioCena
                && estado.save.rioPurificado4 == true
                && estado.save.puzzleTurno4Concluido == false)
            {
                DTplayer.StartDialogue(139, 140);
                estado.save.olhouCamerasSeguranca4 = true;
            }
                
            else if (gameObject.scene.name == maquinasCena
                && estado.save.olhouCamerasSeguranca4 == true
                && estado.save.puzzleTurno4Concluido == false)
            {
                DTplayer.StartDialogue(141, 142);
                estado.save.puzzleTurno4Concluido = true;
            }
                
        }
    }
    public override void EndOfDialogue(int lastSentence, string NPCname)
    {
        base.EndOfDialogue(lastSentence, NPCname);

        if(lastSentence == 1)
        {
            FindObjectOfType<CrossfadeLoadEffect>().ChamarCrossfade(titleScreenCena, player.transform.position);
        }

        
    }
}
