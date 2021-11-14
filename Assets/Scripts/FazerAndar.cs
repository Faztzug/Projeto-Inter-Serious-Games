using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FazerAndar : MonoBehaviour
{
    private Rigidbody2D rgbd;
    public float velocidade = 5;
    [HideInInspector] public bool andando = false;
    private Vector3 destinoPosition;

    Ray ray;
    RaycastHit raycastHit;

    public bool pararDeAndarAoAtingirPlayer = true;

    private void Start()
    {
        rgbd = GetComponent<Rigidbody2D>();
        AtualizarPosicaoZ();
    }

    private void AtualizarPosicaoZ()
    {
        //ray = Camera.main.ScreenPointToRay(transform.position);
        Physics.Raycast(transform.position, 
            new Vector3(transform.position.x, transform.position.y, transform.position.z + 100), out raycastHit);
        transform.position = new Vector3(transform.position.x, transform.position.y, raycastHit.point.z);


        /*if (Physics.Raycast(ray, out raycastHit))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, raycastHit.point.z);
        }*/
    }

    public void AndeParaOPlayer()
    {
        andando = true;
        destinoPosition = FindObjectOfType<PlayerControl>().transform.position;
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

    public void PararAndar()
    {
        destinoPosition = transform.position;
        andando = false;
    }

    private void FixedUpdate()
    {
        if(andando == true)
        {
            //rgbd.MovePosition(Vector2.MoveTowards(transform.position, destinoPosition, velocidade * Time.fixedDeltaTime));
            transform.position = (Vector3.MoveTowards(transform.position, destinoPosition, velocidade * Time.fixedDeltaTime));
            AtualizarPosicaoZ();
        }
    }

    private void Update()
    {

        if (transform.position == destinoPosition)
            andando = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && pararDeAndarAoAtingirPlayer == true)
            PararAndar();
    }

}
