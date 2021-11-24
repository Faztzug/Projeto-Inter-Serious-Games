using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoltarAoMenuInicial : MonoBehaviour
{
    public void GoTittleScreen()
    {
        CrossfadeLoadEffect crossfade = FindObjectOfType<CrossfadeLoadEffect>();

        crossfade.ChamarCrossfade(crossfade.tittleScreenCena, 
            GameObject.FindGameObjectWithTag("Player").transform.position);
    }
}
