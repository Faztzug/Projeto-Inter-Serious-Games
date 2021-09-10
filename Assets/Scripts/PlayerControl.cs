using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private float velocidade; //velocidade de movimento do personagem
    [HideInInspector] public Vector2 touchPosition; //variavel para posição do toque, aonde o personagem irá precisar ir
    private Vector2 currentPosition; //posição do personagem
    private Rigidbody2D rgbd;
    private bool andando; //se o personagem ainda não chegou ao destino
    private float distanceX;
    private float distanceY;
    [SerializeField] private float margemDeParada;
    [SerializeField] private float margemDeAndo;
    [SerializeField] private float segundosPararDeAndarAoColidir;
    private float contadorPararDeAndarAoColidir;

    public bool emDialogo = false;
    private Ray ray;
    private RaycastHit2D raycastHit2d;



    private void Start()
    {
        contadorPararDeAndarAoColidir = segundosPararDeAndarAoColidir;
        rgbd = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (andando)
        {
            CalcularDistancia();

            //UpdatePosition();

            rgbd.MovePosition(Vector2.MoveTowards(currentPosition, touchPosition, velocidade * Time.fixedDeltaTime));

            if (currentPosition == touchPosition
                || Mathf.Abs(distanceX) < margemDeParada && Mathf.Abs(distanceY) < margemDeParada)            
            {
                andando = false;
                //rgbd.velocity = Vector2.zero;
                Debug.Log("Parou de Andar");
            }
        }
    }

    private void Update()
    {
    }

    public void CalcularDistancia()
    {
        currentPosition = transform.position;

        if (touchPosition.x - currentPosition.x > 0)
        {
            distanceX = touchPosition.x - currentPosition.x;
        }
        else
        {
            distanceX = touchPosition.x * -1 + currentPosition.x;
            distanceX = distanceX * -1;
        }

        if (touchPosition.y - currentPosition.y > 0)
        {
            distanceY = touchPosition.y - currentPosition.y;
        }
        else
        {
            distanceY = touchPosition.y * -1 + currentPosition.y;
            distanceY = distanceY * -1;
        }

        //Debug.Log("distanceX: " + distanceX);
        //Debug.Log("distanceY: " + distanceY);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (andando == true)
        {
            contadorPararDeAndarAoColidir -= 1 * Time.deltaTime;
            if (contadorPararDeAndarAoColidir < 0)
            {
                andando = false;
                //rgbd.velocity = Vector2.zero;
                Debug.Log("Parou de Andar");
                contadorPararDeAndarAoColidir = segundosPararDeAndarAoColidir;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        contadorPararDeAndarAoColidir = segundosPararDeAndarAoColidir;
    }

    public void UpdatePosition()
    {
        rgbd.velocity = Vector2.zero;
        if (currentPosition.x < touchPosition.x && distanceX > margemDeAndo)
            rgbd.velocity = new Vector2(velocidade, rgbd.velocity.y);
        if (currentPosition.y < touchPosition.y && distanceY > margemDeAndo)
            rgbd.velocity = new Vector2(rgbd.velocity.x, velocidade);
        if (currentPosition.x > touchPosition.x && distanceX < -margemDeAndo)
            rgbd.velocity = new Vector2(-velocidade, rgbd.velocity.y);
        if (currentPosition.y > touchPosition.y && distanceY < -margemDeAndo)
            rgbd.velocity = new Vector2(rgbd.velocity.x, -velocidade);
    }

    public void Andar()
    {
        if (emDialogo == false)
        {
            //Touch touch = Input.GetTouch(0);
            touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            andando = true;
            Debug.Log("touch " + touchPosition);
        }
    }

    public void ContinueDialogue()
    {
        if (emDialogo == true)
            GetComponent<AoColidirComInteragivel>().NPCFalandoDM.NextSentence();

        /*if (emDialogo == true)
        {

            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            raycastHit2d = Physics2D.GetRayIntersection(ray);
            if (raycastHit2d.collider != null)
            {
                //Debug.Log("Raycast Hit on: " + raycastHit2d.collider.name);
                if(raycastHit2d.collider.name == 
                    GetComponent<AoColidirComInteragivel>().NPCCollisionName)
                {
                    raycastHit2d.collider.GetComponent<DialogueManager>().NextSentence();
                }
            }
        }*/


    }
}