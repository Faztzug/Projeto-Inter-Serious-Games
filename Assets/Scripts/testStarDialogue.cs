using UnityEngine;

public class testStarDialogue : MonoBehaviour
{
    [SerializeField] private DialogueTrigger dialogueTrigger;
    [SerializeField] private bool playAll;
    [SerializeField] private int start;
    [SerializeField] private int end;

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (playAll)
            dialogueTrigger.StartDialogue();
        else
            dialogueTrigger.StartDialogue(start, end);
    }
}