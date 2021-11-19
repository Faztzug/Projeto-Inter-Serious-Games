using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColetarEngrenagem : MonoBehaviour
{
    [SerializeField] Item fusivelUIPrefab;
    EstadoDeMundo estado;
    [SerializeField] int turnoAparecer = 1;
    private Inventory inventario;

    private void Start()
    {
        inventario = FindObjectOfType<Inventory>();
        estado = inventario.gameObject.GetComponent<EstadoDeMundo>();

        //if (estado.save.coletouFusivel == true)
            //this.gameObject.SetActive(false);
        /*if(estado != null)
        {
            if (estado.save.coletouFusivel == true
            || inventario.slotsManager.AcharItem(fusivelUIPrefab.itemName).name == fusivelUIPrefab.itemName
            || estado.save.turno != turnoAparecer)
            {
                this.gameObject.SetActive(false);
            }
        } else if (FindObjectOfType<EstadoDeMundo>().save.coletouFusivel == true
            || inventario.slotsManager.AcharItem(fusivelUIPrefab.itemName)
            || FindObjectOfType<EstadoDeMundo>().save.turno != turnoAparecer)
        {
            this.gameObject.SetActive(false);
        }*/

    }

    IEnumerator EsperarFrameStart()
    {
        yield return new WaitForEndOfFrame();
        if (FindObjectOfType<EstadoDeMundo>().save.coletouFusivel == true
            || inventario.slotsManager.AcharItem(fusivelUIPrefab.itemName)
            || FindObjectOfType<EstadoDeMundo>().save.turno != turnoAparecer)
        {
            this.gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //collision.GetComponent<EstadoDeMundo>().save.coletouFusivel = true;
            collision.GetComponent<DialogueTrigger>().StartDialogue(10, 11);
            this.gameObject.SetActive(false);
        }
    }
}
