using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    void Awake()
    {
        for (int i = 0; i < Object.FindObjectsOfType<DontDestroy>().Length; i++)
        {
            if(Object.FindObjectsOfType<DontDestroy>()[i] != this)
            {
                if(Object.FindObjectsOfType<DontDestroy>()[i].gameObject.name == gameObject.name)
                {
                    //DestroyImmediate(this.gameObject);
                    gameObject.SetActive(false);
                    Destroy(this.gameObject);
                }

            }
        }

        
        DontDestroyOnLoad(gameObject);
    }

    

    
}
