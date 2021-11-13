using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AoColidirComTransitorDeCena : MonoBehaviour
{
    PlayerControl playerControl;
    [SerializeField] float esperaChecarCamera = 1f;

    private void Start()
    {
        playerControl = GetComponent<PlayerControl>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Trancisao de Cena")) Debug.Log(this.gameObject + "Colidiu com o Troca Cena!");

        if (collision.CompareTag("Trancisao de Cena"))
        {
            playerControl.andando = false;
            playerControl.emTransicaoDECena = true;
            collision.GetComponent<TrocarCena>().CarregarCena();
            StartCoroutine(ChecarCameraNovamente());
        }
            

        

    }

    IEnumerator ChecarCameraNovamente()
    {
        yield return new WaitForSeconds(esperaChecarCamera);
        GetComponent<PlayerControl>().ChecarCamera();
        playerControl.emTransicaoDECena = false;
    }

}
