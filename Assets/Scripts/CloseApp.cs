using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseApp : MonoBehaviour
{
    public void Exit()
    {
        Application.Quit();
        Debug.Log("Fechar Aplicação");
    }
}
