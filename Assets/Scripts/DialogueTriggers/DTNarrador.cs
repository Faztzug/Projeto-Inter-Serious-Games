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
        if (estadoDeMundo.save.turno == 2)
        {
            if(gameObject.scene.name == maquinasCena)
                DTplayer.StartDialogue(112, 112);
        }
        else if(estadoDeMundo.save.turno == 3)
        {
            if (gameObject.scene.name == salaControleMeioCena 
                && estadoDeMundo.save.fimIntroducaoTurno3 == true)
                DTplayer.StartDialogue(125, 125);
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
