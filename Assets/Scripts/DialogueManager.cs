using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    private int startSentence;
    private int finalSentence;
    private DialogueTrigger dialogueTrigger;

    [HideInInspector]
    public int numberSentences;

    private int currentSentence = 0;
    private Dialogue dialogueData;

    private TextMeshProUGUI dialogueTextMeshPro;
    private TypingEffect typingEffect;

    private PlayerControl playerControl;
    private bool NextSentenceFirstCall;

    private void Start()
    {
        NextSentenceFirstCall = true;
        typingEffect = FindObjectOfType<TypingEffect>();
        dialogueTextMeshPro = typingEffect.gameObject.GetComponent<TextMeshProUGUI>();

        dialogueTrigger = GetComponent<DialogueTrigger>();

        dialogueData = GetComponent<DialogueData>().dialogue;
        numberSentences = dialogueData.sentences.Length;

        playerControl = FindObjectOfType<PlayerControl>();
    }

    public void StartingDialogue(int startSentence, int finalSentence)
    {
        playerControl.emDialogo = true;
        playerControl.NPCfalando = this;
        this.startSentence = startSentence;
        this.finalSentence = finalSentence;
        currentSentence = startSentence;
        NextSentence();
    }

    public void NextSentence()
    {
        typingEffect.StopAllCoroutines();
        Debug.Log("Call: " + currentSentence + dialogueData.sentences[currentSentence]);
        if (NextSentenceFirstCall == true
            || dialogueTextMeshPro.text == dialogueData.sentences[currentSentence]) //-1
        {
            Debug.Log("FirstCall: " + currentSentence + dialogueData.sentences[currentSentence]);

            dialogueTextMeshPro.color = dialogueData.textColor;

            //coloca o texto na mesma posição do personagem
            dialogueTextMeshPro.transform.position = Camera.main.WorldToScreenPoint(transform.position);

            //e então altera a posição do texto em + textPosition
            dialogueTextMeshPro.transform.Translate(Camera.main.ViewportToScreenPoint(dialogueData.textPosition));
            
            Debug.Log("COMPARAR: \n" + dialogueTextMeshPro.text + "\n" + dialogueData.sentences[currentSentence]);
            if (dialogueTextMeshPro.text == dialogueData.sentences[currentSentence])
            {
                Debug.Log("CurrentSentence++");
                currentSentence++;
            }

            if (currentSentence < numberSentences && currentSentence <= finalSentence)
            {
                //dialogueTextMeshPro.text = dialogueData.sentences[currentSentence];
                typingEffect.CallTyping(dialogueData.sentences[currentSentence]);
                
                

                NextSentenceFirstCall = false;
                Debug.Log("FirstCall: "+ currentSentence + dialogueData.sentences[currentSentence]);
            }
            else if (currentSentence >= numberSentences || currentSentence >= finalSentence)
            {
                dialogueTrigger.EndOfDialogue(currentSentence, dialogueData.characterName);

                dialogueTextMeshPro.text = "";

                currentSentence = 0;
                NextSentenceFirstCall = true;
            }
            
        }
        else if (dialogueTextMeshPro.text != dialogueData.sentences[currentSentence] //-1
          && NextSentenceFirstCall == false)
        {
            Debug.Log("SecondCall: " + currentSentence + dialogueData.sentences[currentSentence]);
            dialogueTextMeshPro.text = dialogueData.sentences[currentSentence]; //-1
            NextSentenceFirstCall = true;
        }
    }
}