using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrirEFecharPia : MonoBehaviour
{
    [SerializeField]
    private Sprite piaAberta;
    [SerializeField]
    private Sprite piaFechada;
    private SpriteRenderer spriteRenderer;
    private bool fechada = true;
    [SerializeField]
    private GameObject[] childs = new GameObject[3];

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        piaFechada = spriteRenderer.sprite;

        for (int i = 0; i < transform.childCount; i++)
        {
            childs[i] = transform.GetChild(i).gameObject;
            childs[i].SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(fechada == true)
            {
                spriteRenderer.sprite = piaAberta;
                fechada = false;

                for (int i = 0; i < childs.Length; i++)
                {
                    if(childs[i] != null)
                    {
                        childs[i].SetActive(true);
                    }
                }
            }
            else if(fechada == false)
            {
                spriteRenderer.sprite = piaFechada;
                fechada = true;
            }
        }
    }
}
