using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AnswerManager : MonoBehaviour
{

    [SerializeField] private GameObject respostaPrefab;
    private DialogueTriggerPlayer triggerPlayer;
    private PlayerControl playerControl;

    private void Start()
    {
        ClearResponses();
        triggerPlayer = FindObjectOfType<DialogueTriggerPlayer>();
        playerControl = triggerPlayer.gameObject.GetComponent<PlayerControl>();
    }


    public void GerarRespostas(string text)
    {
        playerControl.emDialogo = true;
        playerControl.andando = false;
        playerControl.emResposdendo = true;
        
        respostaPrefab.GetComponentInChildren<TextMeshProUGUI>().text = text;
        
        Instantiate(respostaPrefab, this.transform)
            .GetComponentInChildren<Button>().onClick.AddListener(() => OnPickedResponse(text));
        

    }

    private void OnPickedResponse(string text)
    {
        Debug.Log("pickou: " + text);
        ClearResponses();
        triggerPlayer.RespostaSelecionada(text);
        playerControl.emResposdendo = false;
    }

    private void ClearResponses()
    {

        foreach (RespostaDestroyer rd in FindObjectsOfType<RespostaDestroyer>())
        {
            rd.DestroyThis();
        }
          
    }
}
