using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogoOverlay : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private float tempo;
    [SerializeField] int turnoAtivar;
    [SerializeField] Item extintor;

    // Start is called before the first frame update
    void Start()
    {
        EstadoDeMundo estado = FindObjectOfType<EstadoDeMundo>();
        
        if(estado.save.turno != turnoAtivar || estado.save.alarmeIncendio2 == false 
            || estado.save.apagouIncendio2 == true)
        {
            this.transform.parent.gameObject.SetActive(false);
            Destroy(this.transform.parent.gameObject);
        }

        
        anim = GetComponent<Animator>();


        if (FindObjectOfType<Inventory>().slotsManager.AcharItem(extintor.itemName))
        {
            StartCoroutine(ApagarFogo());
            Destroy(FindObjectOfType<Inventory>().slotsManager.AcharItem(extintor.itemName).gameObject);
        }
        
    }

    IEnumerator ApagarFogo()
    {
        FindObjectOfType<PlayerControl>().emDialogo = true;
        yield return new WaitForSeconds(tempo);
        anim.SetTrigger("Apagou");
        FindObjectOfType<ChamasAnimation>().apagar = true;
        FindObjectOfType<EstadoDeMundo>().save.apagouIncendio2 = true;
        FindObjectOfType<EstadoDeMundo>().save.alarmeIncendio2 = false;
    }


    
}
