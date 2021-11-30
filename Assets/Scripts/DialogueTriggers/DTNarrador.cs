using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DTNarrador : DialogueTrigger
{
    [SerializeField] private DialogueData playerPrefab;
    private string playerName;
    [SerializeField] private string titleScreenCena;
    [SerializeField] private string maquinasCena;
    [SerializeField] private string salaControleMeioCena;
    [SerializeField] private string salaControleDireitaCena;
    [SerializeField] private string hidreletricaCena;
    [SerializeField] private string lab1Cena;
    [SerializeField] private string lab2Cena;
    [SerializeField] private string areaGovernamentalFrenteCena;
    [SerializeField] private string floresta3Cena;
    [SerializeField] private string savanaCena;
    [SerializeField] private string rioCena;
    [SerializeField] private string exaustoresCena;
    [SerializeField] private string centro2Cena;

    public override void Start()
    {
        base.Start();

        playerName = playerPrefab.dialogue.characterName;


        if(estado.save.turno == 1)
        {
            if(gameObject.scene.name == lab1Cena
                && estado.save.conheceuEmpresarioRuim == false
                && estado.save.conheceuGovernador == false
                && estado.save.conheceuFazendeiro == false)
            {
                //introdução
                //StartDialogue(1, 10);
                StartDialogue(1,5,0.1f);
            }
        }
    }

    public override void StartDialogue()
    {
        if (estado.save.turno == 1)
        {
            if (gameObject.scene.name == maquinasCena && estado.save.coletouFusivel == false)
                DTplayer.StartDialogue(147, 147);
            else if (gameObject.scene.name == salaControleDireitaCena)
            {
                player.andando = false;
                player.emDialogo = true;
                FindObjectOfType<SFXPlayer>().PlayAudio("Radio Noise");
                DTplayer.StartDialogue(153, 153, 1f);
            }
                
            else if (gameObject.scene.name == hidreletricaCena)
                DTplayer.StartDialogue(154, 154);

            else if (gameObject.scene.name == floresta3Cena)
                DTplayer.StartDialogue(278, 278);
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

            else if(gameObject.scene.name == hidreletricaCena)
                DTplayer.StartDialogue(279, 279);
            else if (gameObject.scene.name == floresta3Cena)
                DTplayer.StartDialogue(280, 280);
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

            else if (gameObject.scene.name == savanaCena)
                DTplayer.StartDialogue(281, 281);

        }
        else if (estado.save.turno == 5)
        {
            if (gameObject.scene.name == salaControleMeioCena)
                DTplayer.StartDialogue(282, 282);
            else if (gameObject.scene.name == maquinasCena)
                DTplayer.StartDialogue(283, 283);
            else if (gameObject.scene.name == hidreletricaCena)
                DTplayer.StartDialogue(284, 284);
            else if (gameObject.scene.name == rioCena)
                DTplayer.StartDialogue(285, 285);
            else if (gameObject.scene.name == exaustoresCena)
                DTplayer.StartDialogue(286, 286);
            else if (gameObject.scene.name == savanaCena)
                DTplayer.StartDialogue(287, 287);
        }
        else if (estado.save.turno == 6)
        {
            if(gameObject.scene.name == lab1Cena)
            {
                if(estado.save.conversouFazendeiro6 == true
                    && estado.save.conversouEB6 == true
                    && estado.save.conversouVozDoPovo6 == true
                    && estado.save.fimDialogoER6 == false)
                {
                    DTplayer.StartDialogue(164,164);
                }

                
            }

            if (gameObject.scene.name == areaGovernamentalFrenteCena)
                DTplayer.StartDialogue(277, 277);

            else if (gameObject.scene.name == maquinasCena)
                DTplayer.StartDialogue(288, 288);
            else if (gameObject.scene.name == hidreletricaCena)
                DTplayer.StartDialogue(289, 289);
            else if (gameObject.scene.name == floresta3Cena)
                DTplayer.StartDialogue(290, 290);
        }
        else if (estado.save.turno == 7)
        {
            if(gameObject.scene.name == salaControleMeioCena)
            {
                DTplayer.StartDialogue(190, 190);
                estado.save.averigouProvas7 = true;
            }

            if(gameObject.scene.name == areaGovernamentalFrenteCena)
            {
                if (estado.save.averigouProvas7 == false)
                    DTplayer.StartDialogue(191, 191);
                else if (estado.save.averigouProvas7 == true)
                    FindObjectOfType<SegurancasCollider>().gameObject.SetActive(false);
            }

            else if(gameObject.scene.name == centro2Cena)
            {
                if(estado.save.mostrouProvasGovernador7 == false)
                    DTplayer.StartDialogue(291, 291);
                else
                    DTplayer.StartDialogue(292, 292);
            }

            else if (gameObject.scene.name == rioCena)
                DTplayer.StartDialogue(293, 293);
        }

        else if (estado.save.turno == 8)
        {

        }

        else if (estado.save.turno == 9)
        {
            if (gameObject.scene.name == salaControleMeioCena)
            {
                if(estado.save.puzzleConcertouSalaDeControle9 == true 
                    && (estado.save.puzzleConcertouHidreletrica9 == false
                    || estado.save.puzzleConcertouMaquinas9 == false))
                DTplayer.StartDialogue(205, 205);
                
            }

            else if (gameObject.scene.name == floresta3Cena)
                DTplayer.StartDialogue(294, 294);
        }

        else if (estado.save.turno == 10)
        {
            if (gameObject.scene.name == salaControleMeioCena)
                DTplayer.StartDialogue(295, 295);
            else if (gameObject.scene.name == lab2Cena)
                DTplayer.StartDialogue(296, 296);
            else if (gameObject.scene.name == maquinasCena)
                DTplayer.StartDialogue(297, 297);
            else if (gameObject.scene.name == rioCena)
                DTplayer.StartDialogue(298, 298);
            else if (gameObject.scene.name == savanaCena)
                DTplayer.StartDialogue(299, 299);
        }

    }
    public override void EndOfDialogue(int lastSentence, string NPCname)
    {
        base.EndOfDialogue(lastSentence, NPCname);


        if(lastSentence == 1)
        {
            FindObjectOfType<CrossfadeLoadEffect>().ChamarCrossfade(titleScreenCena, new Vector2(6, -2));
        }

        if(estado.save.turno == 1)
        {
            if(lastSentence == 6)
            {
                StartDialogue(6, 7);
                FindObjectOfType<TextBoxPortraitsManager>().TrocarSprite(playerName);
            }
            else if(lastSentence == 8)
            {
                StartDialogue(8, 10);
                FindObjectOfType<TextBoxPortraitsManager>().TrocarSprite("");
            }
            else if (lastSentence == 11)
            {
                FindObjectOfType<DialogueTriggerAssistente>().fazerAndar.AndeParaOPlayer();
            }
        }

        else if (estado.save.turno == 10)
        {

            if (lastSentence == 3)
            {
                FindObjectOfType<CrossfadeLoadEffect>().ChamarCrossfade(titleScreenCena, new Vector2(6,-2));
            }
        }
    }
}
