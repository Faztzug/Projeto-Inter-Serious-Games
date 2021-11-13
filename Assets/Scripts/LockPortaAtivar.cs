using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockPortaAtivar : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite lockAtivado;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("colidiu Lock");
        
        if (collision.CompareTag("Player"))
        {
            TrocarSprite();
        }
    }

    public void TrocarSprite()
    {
        Debug.Log("Ativou Lock");
        spriteRenderer.sprite = lockAtivado;
    }
}
