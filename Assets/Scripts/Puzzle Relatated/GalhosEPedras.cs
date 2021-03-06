using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalhosEPedras : MonoBehaviour
{
    SpriteRenderer spriteR;
    [SerializeField]
    Sprite spriteRevelar;
    // Start is called before the first frame update
    void Start()
    {
        spriteR = GetComponentInParent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && FindObjectOfType<EstadoDeMundo>().save.apagouIncendio2 == true)
        {
            spriteR.sprite = spriteRevelar;
            spriteR.sortingLayerName = "Cenario";
            //collision.gameObject.GetComponent<EstadoDeMundo>().save.apagouIncendio2 = true;
            //collision.gameObject.GetComponent<EstadoDeMundo>().save.alarmeIncendio2 = false;
            collision.gameObject.GetComponent<EstadoDeMundo>().save.turno2Concluido = true;
            collision.gameObject.GetComponent<DialogueTriggerPlayer>().StartDialogue(115, 117);
        }
    }
}
