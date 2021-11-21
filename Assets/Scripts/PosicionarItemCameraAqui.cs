using UnityEngine;

public class PosicionarItemCameraAqui : MonoBehaviour
{
    private EstadoDeMundo estado;

    [SerializeField]
    private bool esquerda;

    [SerializeField]
    private bool meio;

    [SerializeField]
    private bool direita;

    [SerializeField]
    private Item ItemCameras;

    private Inventory inventory;

    private void Start()
    {
        estado = FindObjectOfType<EstadoDeMundo>();
        Desativar();

        inventory = FindObjectOfType<Inventory>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player entrou no trigger");

            if (inventory.selectedItem != null && inventory.selectedItem.itemName == ItemCameras.itemName)
            {
                DialogueTriggerPlayer DTPlayer = collision.GetComponent<DialogueTriggerPlayer>();
                Debug.Log("itens Iguais");
                gameObject.SetActive(false);
                inventory.EliminarItemSelecionado();
                Posicionar();
                if (estado.save.posicionouCameraEsquerda6 == true
                    && estado.save.posicionouCameraMeio6 == true
                    && estado.save.posicionouCameraDireita6 == true)
                    DTPlayer.StartDialogue(166, 167);
                else
                    DTPlayer.StartDialogue(166, 166);
            }
        }
    }

    public void Desativar()
    {
        if (esquerda)
        {
            if (estado.save.posicionouCameraEsquerda6)
                this.gameObject.SetActive(false);
        }
        else if (meio)
        {
            if (estado.save.posicionouCameraMeio6)
                this.gameObject.SetActive(false);
        }
        else if (direita)
        {
            if (estado.save.posicionouCameraDireita6)
                this.gameObject.SetActive(false);
        }
    }

    public void Posicionar()
    {
        if (esquerda)
        {
            estado.save.posicionouCameraEsquerda6 = true;
        }
        else if (meio)
        {
            estado.save.posicionouCameraMeio6 = true;
        }
        else if (direita)
        {
            estado.save.posicionouCameraDireita6 = true;
        }
    }
}