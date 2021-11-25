using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    private int startSentence;
    private int finalSentence;
    private DialogueTrigger dialogueTrigger;

    //[HideInInspector]
    public int numberSentences;

    private int currentSentence = 0;
    private Dialogue dialogueData;

    private TextMeshProUGUI dialogueTextMeshPro;
    [SerializeField]
    private TypingEffect typingEffect;
    private TextBoxDialogue textBox;

    private PlayerControl playerControl;
    private bool NextSentenceFirstCall;

    private EstadoDeMundo estadoDeMundo;

    private void Awake()
    {
        NextSentenceFirstCall = true;
        typingEffect = FindObjectOfType<TypingEffect>();
        dialogueTextMeshPro = typingEffect.gameObject.GetComponent<TextMeshProUGUI>();
        textBox = FindObjectOfType<TextBoxDialogue>();

        dialogueTrigger = GetComponent<DialogueTrigger>();

        dialogueData = GetComponent<DialogueData>().dialogue;
        numberSentences = dialogueData.sentences.Length;

        playerControl = FindObjectOfType<PlayerControl>();
        estadoDeMundo = playerControl.gameObject.GetComponent<EstadoDeMundo>();

        //meh

        //NextSentenceFirstCall = true;
        typingEffect = FindObjectOfType<TypingEffect>();
        dialogueTextMeshPro = typingEffect.gameObject.GetComponent<TextMeshProUGUI>();
        textBox = FindObjectOfType<TextBoxDialogue>();

        //dialogueTrigger = GetComponent<DialogueTrigger>();

        //dialogueData = GetComponent<DialogueData>().dialogue;
        //numberSentences = dialogueData.sentences.Length;

        playerControl = FindObjectOfType<PlayerControl>();
        estadoDeMundo = playerControl.gameObject.GetComponent<EstadoDeMundo>();
    }

    private void Start()
    {
        //NextSentenceFirstCall = true;
        typingEffect = FindObjectOfType<TypingEffect>();
        dialogueTextMeshPro = typingEffect.gameObject.GetComponent<TextMeshProUGUI>();
        textBox = FindObjectOfType<TextBoxDialogue>();

        //dialogueTrigger = GetComponent<DialogueTrigger>();

        //dialogueData = GetComponent<DialogueData>().dialogue;
        //numberSentences = dialogueData.sentences.Length;

        playerControl = FindObjectOfType<PlayerControl>();
        estadoDeMundo = playerControl.gameObject.GetComponent<EstadoDeMundo>();
    }

    public void StartingDialogue(int startSentence, int finalSentence)
    {
        Debug.Log("Starting Dialogue: " + startSentence + ", " + finalSentence);
        playerControl.emDialogo = true;
        playerControl.emTrueDialogoFalando = true;
        playerControl.andando = false;
        playerControl.NPCfalando = this;
        this.startSentence = startSentence;
        this.finalSentence = finalSentence;
        currentSentence = startSentence;
        NextSentenceFirstCall = true;
        NextSentence();
    }

    public void NextSentence()
    {
        Debug.Log("Next Sentence, Current Sentence: " + currentSentence);

        typingEffect.StopAllCoroutines();
        typingEffect.StopSFX();
        
        if (NextSentenceFirstCall == true
            || dialogueTextMeshPro.text == dialogueData.sentences[currentSentence]) //-1
        {

            //altera cor da caixa
            
            textBox.box.color = dialogueData.characterColor;
            //dialogueTextMeshPro.color = dialogueData.characterColor;

            //coloca o texto na mesma posição do personagem
            //dialogueTextMeshPro.transform.position = Camera.main.WorldToScreenPoint(transform.position);

            //e então altera a posição do texto em + textPosition
            //dialogueTextMeshPro.transform.Translate(Camera.main.ViewportToScreenPoint(dialogueData.textPosition));

            //checagem se o texto está fora da tela, e correção de posição
            //TextBoxRearrange();

            textBox.nome.text = dialogueData.characterName;



            textBox.Activate();


            if (dialogueTextMeshPro.text == dialogueData.sentences[currentSentence])
            {
                currentSentence++;
            }

            if (currentSentence < numberSentences && currentSentence <= finalSentence)
            {
                Debug.Log("FirstCall: " + currentSentence + dialogueData.sentences[currentSentence]);
                typingEffect.CallTyping(dialogueData.sentences[currentSentence]);
                NextSentenceFirstCall = false;
            }
            else if (currentSentence >= numberSentences || currentSentence >= finalSentence)
            {
                Debug.Log("Fim das Sentenças desta fala, current sentence: " 
                    + currentSentence + ", Final Sentence: " + finalSentence);

                dialogueTextMeshPro.text = "";
                textBox.Deactivate();

                
                NextSentenceFirstCall = true;

                dialogueTrigger.EndOfDialogue(currentSentence, dialogueData.characterName);

                //currentSentence = 0;
            }
            
        }
        else if (dialogueTextMeshPro.text != dialogueData.sentences[currentSentence] //-1
          && NextSentenceFirstCall == false)
        {
            Debug.Log("SecondCall, Terminando Sentença: " + currentSentence + dialogueData.sentences[currentSentence]);
            dialogueTextMeshPro.text = dialogueData.sentences[currentSentence]; //-1
            NextSentenceFirstCall = true;
        }
    }

    public void TextBoxRearrange()
    {
        Vector2 textViewPortPosition = Camera.main.ScreenToViewportPoint(dialogueTextMeshPro.transform.position);
        Debug.Log(textViewPortPosition);

        if (textViewPortPosition.y > estadoDeMundo.save.textBoxBoundsY)
        {
            
            dialogueTextMeshPro.transform.position = 
                Camera.main.ViewportToScreenPoint
                (new Vector2(textViewPortPosition.x, estadoDeMundo.save.textBoxBoundsY));
            Debug.Log(textViewPortPosition);
        }

        if (textViewPortPosition.x > estadoDeMundo.save.textBoxBoundsX)
        {

            dialogueTextMeshPro.transform.position =
                Camera.main.ViewportToScreenPoint
                (new Vector2(estadoDeMundo.save.textBoxBoundsX, textViewPortPosition.y));
            Debug.Log(textViewPortPosition);
        }

        if (textViewPortPosition.x < 1-estadoDeMundo.save.textBoxBoundsX)
        {

            dialogueTextMeshPro.transform.position =
                Camera.main.ViewportToScreenPoint
                (new Vector2(1-estadoDeMundo.save.textBoxBoundsX, textViewPortPosition.y));
            Debug.Log(textViewPortPosition);
        }



    }
}