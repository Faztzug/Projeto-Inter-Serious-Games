using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogoOverlay : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private float tempo;
    [SerializeField] int turnoAtivar;

    // Start is called before the first frame update
    void Start()
    {
        EstadoDeMundo estado = FindObjectOfType<EstadoDeMundo>();
        
        if(estado.save.turno != turnoAtivar || estado.save.alarmeIncendio2 == false 
            || estado.save.apagouIncendio2 == true)
        {
            this.gameObject.SetActive(false);
            Destroy(this.gameObject);
        }

        
        anim = GetComponent<Animator>();
        StartCoroutine(ApagarFogo());
    }

    IEnumerator ApagarFogo()
    {
        FindObjectOfType<PlayerControl>().emDialogo = true;
        yield return new WaitForSeconds(tempo);
        anim.SetTrigger("Apagou");
    }


    
}
