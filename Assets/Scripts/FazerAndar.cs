using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FazerAndar : MonoBehaviour
{
    private Rigidbody2D rgbd;
    public float velocidade = 5;
    [HideInInspector] public bool andando = false;
    private Vector3 destinoPosition;
    private Vector2 currentPosition;
    [HideInInspector]
    public float distanceX;
    [HideInInspector]
    public float distanceY;

    Ray ray;
    RaycastHit raycastHit;

    public bool pararDeAndarAoAtingirPlayer = true;
    

    private void Start()
    {
        rgbd = GetComponent<Rigidbody2D>();
        AtualizarPosicaoZ();
        
    }

    public void CalcularDistancia()
    {
        currentPosition = transform.position;

        

        if (destinoPosition.x - currentPosition.x > 0)
        {
            distanceX = destinoPosition.x - currentPosition.x;
        }
        else
        {
            distanceX = destinoPosition.x * -1 + currentPosition.x;
            distanceX = distanceX * -1;
        }

        if (destinoPosition.y - currentPosition.y > 0)
        {
            distanceY = destinoPosition.y - currentPosition.y;
        }
        else
        {
            distanceY = destinoPosition.y * -1 + currentPosition.y;
            distanceY = distanceY * -1;
        }

        //Debug.Log("distanceX: " + distanceX);
        //Debug.Log("distanceY: " + distanceY);
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

    public void AndeParaOPlayer(float tempo)
    {
        StartCoroutine(AndeParaOPlayerCouroutine(tempo));
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

    protected IEnumerator AndeParaCouroutine(Vector2 position, float tempoEspera)
    {
        yield return new WaitForSeconds(tempoEspera);
        andando = true;
        destinoPosition = position;
    }

    protected IEnumerator AndeParaOPlayerCouroutine(float tempoEspera)
    {
        yield return new WaitForSeconds(tempoEspera);
        andando = true;
        destinoPosition = FindObjectOfType<PlayerControl>().transform.position;
    }

    public void PararAndar()
    {
        if(gameObject.activeSelf == true)
        StartCoroutine(PararAndarCourotine());
    }

    private IEnumerator PararAndarCourotine()
    {
        yield return new WaitForEndOfFrame();
        Debug.Log(gameObject.name + " mandei pra parar parou!");
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
            CalcularDistancia();
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
