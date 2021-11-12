using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public class EstadoDeMundo : MonoBehaviour
{
    public Save save;

    public ItemsDatabase itemsDatabase;

    private void Awake()
    {
        LoadGame();
        //cenaAtual = this.gameObject.scene.name;
        //novaPosicao = transform.position;
    }


    private void Start()
    {
        
    }


    public void SaveGame()
    {
        GetComponent<Inventory>().slotsManager.gameObject.SetActive(true);

        Slot[] slots = FindObjectsOfType<Slot>();

        for (int i = 0; i < slots.Length; i++)
        {
            save.inventarioData[i].SlotID = slots[i].i;

            if (slots[i].transform.childCount > 0)
                save.inventarioData[i].itemChildName = 
                    slots[i].transform.GetChild(0).GetComponent<Item>().itemName;
            else
                save.inventarioData[i].itemChildName = null;
        }

        
        


        FileStream file = File.Create(Application.persistentDataPath + "/Save.sav");
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(file, save);
        file.Close();
    }

    public void LoadGame()
    {

    }



    
}
