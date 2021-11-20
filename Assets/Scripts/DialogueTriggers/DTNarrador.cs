using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DTNarrador : DialogueTrigger
{
    [SerializeField] private string titleScreenCena;
    [SerializeField] private string maquinasCena;
    [SerializeField] private string salaControleMeioCena;
    [SerializeField] private string salaControleDireitaCena;
    [SerializeField] private string hidreletricaCena;
    [SerializeField] private string lab1Cena;

    public override void StartDialogue()
    {
        if (estado.save.turno == 1)
        {
            if (gameObject.scene.name == maquinasCena && estado.save.coletouFusivel == false)
                DTplayer.StartDialogue(147, 147);
            else if (gameObject.scene.name == salaControleDireitaCena)
                DTplayer.StartDialogue(153, 153);
            else if (gameObject.scene.name == hidreletricaCena)
                DTplayer.StartDialogue(154, 154);
        }
        else if (estado.save.turno == 2)
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
        else if (estado.save.turno == 5)
        {

        }
        else if (estado.save.turno == 6)
        {
            if(gameObject.scene.name == lab1Cena)
            {
                if(estado.save.conversouFazendeiro6 == true
                    && estado.save.conversouEB6 == true
                    && estado.save.conversouVozDoPovo6 == true)
                {
                    DTplayer.StartDialogue(164,164);
                }
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
