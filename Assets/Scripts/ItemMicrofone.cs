using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMicrofone : MonoBehaviour
{
    EstadoDeMundo estado;
    // Start is called before the first frame update
    void Start()
    {
        estado = FindObjectOfType<EstadoDeMundo>();

        if (estado.save.coletouMicrofone6 == true)
            Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            estado.save.coletouMicrofone6 = true;
            collision.GetComponent<DialogueTriggerPlayer>().StartDialogue(165, 165);
        }
    }
}
