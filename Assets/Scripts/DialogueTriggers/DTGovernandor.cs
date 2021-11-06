using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DTGovernandor : DialogueTrigger
{
    public override void EndOfDialogue(int lastSentence, string NPCname)
    {
        base.EndOfDialogue(lastSentence, NPCname);
        if (lastSentence == 4)
            FindObjectOfType<DTEmpresarioRuim>().GetComponentInParent<FazerAndar>()
                .AndePara(new Vector2(-6.5f,-3));
    }
}
