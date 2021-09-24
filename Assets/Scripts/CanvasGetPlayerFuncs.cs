using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CanvasGetPlayerFuncs : MonoBehaviour
{
    EventTrigger eventTrigger;
    PlayerControl player;
    
    // Script deveras complicado, mas basicamente adiciona eventos por script,
    // coloquei aqui para não ter que manualmente colocar Gameobject por Gameobject e Função por Função
    // Assim temos menos preocupações na hora de montar cenas, pois o script encontra o player sozinho
    void Start()
    {
        player = FindObjectOfType<PlayerControl>();
        eventTrigger = GetComponent<EventTrigger>();

        EventTrigger.Entry pointerDown = new EventTrigger.Entry();
        pointerDown.eventID = EventTriggerType.PointerDown;
        pointerDown.callback.AddListener((playerAndar) => { player.Andar(); });
        eventTrigger.triggers.Add(pointerDown);

        EventTrigger.Entry pointerDrag = new EventTrigger.Entry();
        pointerDrag.eventID = EventTriggerType.Drag;
        pointerDrag.callback.AddListener((playerAndar) => { player.Andar(); });
        eventTrigger.triggers.Add(pointerDrag);

        EventTrigger.Entry pointerUp = new EventTrigger.Entry();
        pointerUp.eventID = EventTriggerType.PointerUp;
        pointerUp.callback.AddListener((playerContinueDialogue) => { player.ContinueDialogue(); });
        eventTrigger.triggers.Add(pointerUp);
    }

    

    
}
