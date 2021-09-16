using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testStarDialogue : MonoBehaviour
{
    DialogueTriggerEsferaTeste esfera;
    [SerializeField] int start;
    [SerializeField] int end;

    private void Start()
    {
        esfera = FindObjectOfType<DialogueTriggerEsferaTeste>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        esfera.StartDialogue(start, end);
    }
}
