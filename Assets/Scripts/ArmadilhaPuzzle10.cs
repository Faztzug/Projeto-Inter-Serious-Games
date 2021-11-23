using UnityEngine;

public class ArmadilhaPuzzle10 : MonoBehaviour
{
    private EstadoDeMundo estado;
    [SerializeField]
    GameObject armadilha;

    // Start is called before the first frame update
    private void Start()
    {
        estado = FindObjectOfType<EstadoDeMundo>();

        if (estado.save.turno != 10
            || estado.save.iniciarPuzzleTurno10 == false)
            Destroy(this.transform.parent.gameObject);

        if (estado.save.turno == 10
            && estado.save.preparouArmadilha10 == true)
        {
            armadilha.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (estado.save.iniciarPuzzleTurno10 == true)
            {
                DialogueTriggerPlayer DTPlayer = collision.GetComponent<DialogueTriggerPlayer>();


                armadilha.SetActive(true);

                estado.save.preparouArmadilha10 = true;

                DTPlayer.StartDialogue(213,213);


                this.gameObject.SetActive(false);
            }
        }
    }
}