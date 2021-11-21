using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrossfadeLoadEffect : MonoBehaviour
{
    private Animator crossfadeTransition;
    [SerializeField] private float tempoDeCrossfade = 1f;
    private GameObject player;
    private PlayerControl playerControl;
    private EstadoDeMundo estado;
    public string tittleScreenCena;
    public string MaquinasCena;
    public string areaGovernamentalForaCena;

    private void Start()
    {
        crossfadeTransition = GetComponent<Animator>();
        AcharPlayer();
    }

    private void AcharPlayer()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if(player != null)
        {
            playerControl = player.GetComponent<PlayerControl>();
            estado = player.GetComponent<EstadoDeMundo>();
        }
        
    }

    public void ChamarCrossfade(string cena, Vector2 novaPosicao)
    {
        StartCoroutine(IniciarCrossfade(cena, novaPosicao));
    }

    private IEnumerator IniciarCrossfade(string cena, Vector2 novaPosicao)
    {
        crossfadeTransition.SetTrigger("Start");
        yield return new WaitForSeconds(tempoDeCrossfade);

        if(FindObjectOfType<SFXPlayer>() != null)
        FindObjectOfType<SFXPlayer>().StopAll();

        SceneManager.LoadScene(cena);

        if (player == null)
        {
            //yield return new WaitForEndOfFrame();
            AcharPlayer();
        }

        if (player != null)
        {
            //GameObject player = GameObject.FindGameObjectWithTag("Player");

            playerControl.touchPosition = novaPosicao;
            player.transform.position = novaPosicao;

            

            playerControl.ChecarCamera();

            if(cena != tittleScreenCena)
            {
                estado.save.cenaAtual = cena;
                estado.save.novaPosicao = novaPosicao;
            }
            
            //estado.save.positionX = novaPosicao.x;
            //estado.save.positionX = novaPosicao.y;

            estado.SaveGame();

            Debug.Log("Nova Posição: " + estado.save.novaPosicao);
            //Debug.Log("Nova Posição: " + estado.save.positionX + ", " + estado.save.positionY);

        }

        

        crossfadeTransition.SetTrigger("End");
    }
}