using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public class EstadoDeMundo : MonoBehaviour
{
    public Save save;

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
        FileStream file = File.Create(Application.persistentDataPath + "/Save.sav");
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(file, save);
        file.Close();
    }

    public void LoadGame()
    {

    }



    
}
