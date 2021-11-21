using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FimDeTurno : MonoBehaviour
{
    private EstadoDeMundo estado;
    private DialogueTriggerPlayer dtPlayer;
    [SerializeField] private Item[] itens;
    private Inventory inventario;
    private CrossfadeLoadEffect crossfade;

    private void Start()
    {
        estado = FindObjectOfType<EstadoDeMundo>();
        dtPlayer = estado.gameObject.GetComponent<DialogueTriggerPlayer>();
        inventario = estado.gameObject.GetComponent<Inventory>();
        crossfade = FindObjectOfType<CrossfadeLoadEffect>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            

            if (estado.save.turno == 1 && estado.save.coletouFusivel == true 
                && estado.save.coletouTerra == true)
            {

                //Destroy(inventario.slotsManager.AcharItem(itens[0].itemName).gameObject);
                //terra
                Destroy(inventario.slotsManager.AcharItem(itens[1].itemName).gameObject);

                dtPlayer.StartDialogue(14, 16);

                

            }
            else if(estado.save.turno == 2 && estado.save.turno2Concluido == true)
            {
                dtPlayer.StartDialogue(119,120);
            }
            else if (estado.save.turno == 3 && estado.save.puzzleExaustores3Resolvido == true)
            {
                dtPlayer.StartDialogue(128, 129);
            }

            else if (estado.save.turno == 4 && estado.save.puzzleTurno4Concluido == true)
            {
                dtPlayer.StartDialogue(143, 144);
            }

            else if (estado.save.turno == 5 && estado.save.conversouComGovernador5 == true)
            {
                dtPlayer.StartDialogue(163, 163);
            }
            else if (estado.save.turno == 6 && estado.save.fimDialogoER6 == true)
            {
                EncerrarTurno();
            }
        }
        
    }

    public void EncerrarTurno()
    {
        estado.save.turno++;
        crossfade.ChamarCrossfade(this.gameObject.scene.name, dtPlayer.transform.position);
    }
}
