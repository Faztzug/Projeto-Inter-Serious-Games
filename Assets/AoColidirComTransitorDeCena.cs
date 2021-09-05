using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AoColidirComTransitorDeCena : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.CompareTag("Trancisao de Cena")) Debug.Log(this.gameObject + "Colidiu com o Troca Cena!");

        if (collision.CompareTag("Trancisao de Cena"))
            collision.GetComponent<TrocarCena>().CarregarCena();

        

    }
}
