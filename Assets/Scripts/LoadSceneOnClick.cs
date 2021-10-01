using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour
{
    private CrossfadeLoadEffect crossfade;

    private void Start()
    {
        

    }

    public void LoadScene(string sceneName)
    {
        crossfade = FindObjectOfType<CrossfadeLoadEffect>();
        crossfade.ChamarCrossfade(sceneName, Vector2.zero);
    }


}
