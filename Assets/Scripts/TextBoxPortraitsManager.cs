using UnityEngine;
using UnityEngine.UI;

public class TextBoxPortraitsManager : MonoBehaviour
{
    private Image image;

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject Assistente;
    [SerializeField] private GameObject Governador;
    [SerializeField] private GameObject EmpresarioRuim;
    [SerializeField] private GameObject EmpresarioBom;
    [SerializeField] private GameObject Fazendeiro;
    [SerializeField] private GameObject VozDoPovo;

    [SerializeField] private string playerName;
    [SerializeField] private string AssistenteName;
    [SerializeField] private string GovernadorName;
    [SerializeField] private string EmpresarioRuimName;
    [SerializeField] private string EmpresarioBomName;
    [SerializeField] private string FazendeiroName;
    [SerializeField] private string VozDoPovoName;

    [SerializeField] private Sprite playerSprite;
    [SerializeField] private Sprite AssistenteSprite;
    [SerializeField] private Sprite GovernadorSprite;
    [SerializeField] private Sprite EmpresarioRuimSprite;
    [SerializeField] private Sprite EmpresarioBomSprite;
    [SerializeField] private Sprite FazendeiroSprite;
    [SerializeField] private Sprite VozDoPovoSprite;

    private void Start()
    {
        image = GetComponent<Image>();
        TirarImagem();
        
        if(player != null)
        playerName = player.GetComponent<DialogueData>().dialogue.characterName;

        if (Assistente != null)
            AssistenteName = Assistente.GetComponentInChildren<DialogueData>().dialogue.characterName;

        if (Governador != null)
            GovernadorName = Governador.GetComponentInChildren<DialogueData>().dialogue.characterName;

        if (EmpresarioRuim != null)
            EmpresarioRuimName = EmpresarioRuim.GetComponentInChildren<DialogueData>().dialogue.characterName;

        if (EmpresarioBom != null)
            EmpresarioBomName = EmpresarioBom.GetComponentInChildren<DialogueData>().dialogue.characterName;

        if (Fazendeiro != null)
            FazendeiroName = Fazendeiro.GetComponentInChildren<DialogueData>().dialogue.characterName;

        if (VozDoPovo != null)
            VozDoPovoName = VozDoPovo.GetComponentInChildren<DialogueData>().dialogue.characterName;

    }

    public void TirarImagem()
    {
        if(image != null)
        {
            image.sprite = null;
            image.color = new Color(1, 1, 1, 0);
        }
    }

    public void TrocarSprite(string characterName)
    {
        if (image != null)
        {
            
            image.color = new Color(1, 1, 1, 1);

            if (characterName == playerName)
                image.sprite = playerSprite;
            else
            if (characterName == AssistenteName)
                image.sprite = AssistenteSprite;
            else
            if (characterName == GovernadorName)
                image.sprite = GovernadorSprite;
            else
            if (characterName == EmpresarioRuimName)
                image.sprite = EmpresarioRuimSprite;
            else
            if (characterName == EmpresarioBomName)
                image.sprite = EmpresarioBomSprite;
            else
            if (characterName == FazendeiroName)
                image.sprite = FazendeiroSprite;
            else
            if (characterName == VozDoPovoName)
                image.sprite = VozDoPovoSprite;
            else
            {
                image.sprite = null;
                image.color = new Color(1, 1, 1, 0);
            }
                


        }
    }

}