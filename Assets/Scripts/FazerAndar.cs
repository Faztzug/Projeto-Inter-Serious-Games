using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FazerAndar : MonoBehaviour
{
    private Rigidbody2D rgbd;
    public float velocidade = 5;
    [HideInInspector] public bool andando = false;
    private Vector2 destinoPosition;

    private void Start()
    {
        rgbd = GetComponent<Rigidbody2D>();
    }

    public void AndePara(Vector2 position)
    {
        andando = true;
        destinoPosition = position;

    }

    public void AndePara(Vector2 position, float tempoEspera)
    {
        StartCoroutine(AndeParaCouroutine(position, tempoEspera));
    }

    public IEnumerator AndeParaCouroutine(Vector2 position, float tempoEspera)
    {
        yield return new WaitForSeconds(tempoEspera);
        andando = true;
        destinoPosition = position;
    }

    private void FixedUpdate()
    {
        if(andando == true)
        {
            rgbd.MovePosition(Vector2.MoveTowards(transform.position, destinoPosition, velocidade * Time.fixedDeltaTime));

        }
    }

    private void Update()
    {

        if (rgbd.position == destinoPosition)
            andando = false;
    }
}
