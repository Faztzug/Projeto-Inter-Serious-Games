using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private Inventory inventory;
    public GameObject itemButton;
    private VerificarTurnoAtual verificarTurno;
    [SerializeField] private bool apagarDuplicata = true;


    private void Start()
    {
        inventory = FindObjectOfType<Inventory>();

        if(GetComponent<VerificarTurnoAtual>() != null)
        {
            Debug.Log(gameObject.name + " Achou Verificar turno");
            verificarTurno = GetComponent<VerificarTurnoAtual>();
            if (verificarTurno.Verificar() == false)
            {
                this.gameObject.SetActive(false);
                Destroy(this.gameObject);
            }
                
        }
        

        if(apagarDuplicata == true)
        {
            if (inventory.slotsManager.AcharItem(itemButton.GetComponent<Item>().itemName))
                Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if(verificarTurno != null)
            {
                if (verificarTurno.Verificar())
                {
                    for (int i = 0; i < inventory.slotsGameObject.Length; i++)
                    {
                        if (inventory.isFull[i] == false)
                        {
                            //sonzinho
                            FindObjectOfType<SFXPlayer>().PlayAudio("Coletou Item");
                            //Vai ser adicionado.
                            inventory.isFull[i] = true;
                            Instantiate(itemButton, inventory.slotsGameObject[i].transform, false);
                            //inventory.slotsGameObject[i].GetComponent<Slot>().itemChild = itemButton;
                            Destroy(gameObject);
                            break;
                        }
                    }
                }
                else
                {
                    //fazer nada
                }
            }
            else
            {
                for (int i = 0; i < inventory.slotsGameObject.Length; i++)
                {
                    if (inventory.isFull[i] == false)
                    {
                        //Vai ser adicionado.
                        inventory.isFull[i] = true;
                        Instantiate(itemButton, inventory.slotsGameObject[i].transform, false);
                        //inventory.slotsGameObject[i].GetComponent<Slot>().itemChild = itemButton;
                        Destroy(gameObject);
                        break;
                    }
                }
            }
            
        }
    }
}
