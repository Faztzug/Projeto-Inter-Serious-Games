using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System.Collections;

public class EstadoDeMundo : MonoBehaviour
{
    public Save save;

    public ItemsDatabase itemsDatabase;

    private MusicPlayer musicPlayer;

    private SFXPlayer sfxPlayer;

    private TypingEffect typingEffect;

    [HideInInspector]
    public AtualizarAvancoProjeto atualizarAvancoProjeto;

    private string savePath = "/Save.sav";

    private void Awake()
    {
        //LoadGame();
        //cenaAtual = this.gameObject.scene.name;
        //novaPosicao = transform.position;
    }

    private void Start()
    {
        if (FindObjectOfType<MusicPlayer>() != null)
            musicPlayer = FindObjectOfType<MusicPlayer>();

        if (FindObjectOfType<SFXPlayer>() != null)
            sfxPlayer = FindObjectOfType<SFXPlayer>();

        if (FindObjectOfType<TypingEffect>() != null)
            typingEffect = FindObjectOfType<TypingEffect>();

        if (typingEffect != null || musicPlayer != null || sfxPlayer != null)
            UpdateSettings();

        if (GameObject.FindGameObjectWithTag("Avanço Projeto") != null)
            atualizarAvancoProjeto = GameObject.FindGameObjectWithTag("Avanço Projeto")
                .GetComponent<AtualizarAvancoProjeto>();

        if (atualizarAvancoProjeto != null)
            atualizarAvancoProjeto.Atualizar();

    }

    public void UpdateSettings()
    {
        Application.targetFrameRate = save.frameRate;
        if(musicPlayer != null)
        {
            musicPlayer.overallVolume = save.musicVolume;
            musicPlayer.UpdateVolume();
        }
        if (sfxPlayer != null)
        {
            sfxPlayer.overallVolume = save.musicVolume;
            sfxPlayer.UpdateVolume();
        }
        if (typingEffect != null)
        typingEffect.textTypingSpeed = save.textTypingSpeed;
    }

    public void SaveGame()
    {
        GameObject slotsManagerGO = GetComponent<Inventory>().slotsManager.gameObject;
        slotsManagerGO.SetActive(true);

        Slot[] slots = FindObjectsOfType<Slot>();

        for (int i = 0; i < slots.Length; i++)
        {
            save.inventarioData[i].SlotID = slots[i].i;

            if (slots[i].gameObject.transform.childCount > 0)
            {
                save.inventarioData[i].itemChildName =
                    slots[i].transform.GetChild(0).GetComponent<Item>().itemName;
            }
            else
            {
                save.inventarioData[i].itemChildName = null;
            }
        }

        slotsManagerGO.SetActive(false);

        if (atualizarAvancoProjeto != null)
            atualizarAvancoProjeto.Atualizar();

        FileStream file = File.Create(Application.persistentDataPath + savePath);
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(file, save);
        file.Close();
    }

    public void LoadGame()
    {
        if (ChecarSeSaveExiste())
        {
            DontDestroyOnLoad(this.gameObject);

            FileStream file = File.Open(Application.persistentDataPath + savePath, FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            Save loadedSave = (Save)bf.Deserialize(file);

            save = loadedSave;

            CrossfadeLoadEffect crossfade = FindObjectOfType<CrossfadeLoadEffect>();
            crossfade.ChamarCrossfade(save.cenaAtual, save.novaPosicao);

            file.Close();

            LoadGetPlayerAndDestroy();


        }
    }

    public bool ChecarSeSaveExiste()
    {

        if (File.Exists(Application.persistentDataPath + savePath))
            return true;
        else
            return false;

    }

    private void LoadGetPlayerAndDestroy()
    {
        //GameObject player = null;

        

        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            EstadoDeMundo playerEstado =
                GameObject.FindGameObjectWithTag("Player").GetComponent<EstadoDeMundo>();

            playerEstado.save = this.save;

            playerEstado.AtualizarInventario();

            Destroy(this.gameObject);
            this.gameObject.SetActive(false);
        }
        else
        {
            StartCoroutine(LoadGetPlayerAndDestroyCourotine());
            
        }
    }

    IEnumerator LoadGetPlayerAndDestroyCourotine()
    {
        yield return new WaitForEndOfFrame();
        LoadGetPlayerAndDestroy();
    }

    public void AtualizarInventario()
    {
        Inventory inventario = GetComponent<Inventory>();
        

        foreach (ItemSlotData item in save.inventarioData)
        {
            if(item.itemChildName != null)
            {

                
                foreach (GameObject inDatabase in itemsDatabase.database)
                {
                    if (item.itemChildName == inDatabase.GetComponent<Item>().itemName)
                    {
                        Instantiate(inDatabase, inventario.slotsGameObject[item.SlotID].transform);
                    }
                    
                }
                
                
            }
        }
    }


}