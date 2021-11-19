using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChamasAnimation : MonoBehaviour
{
    [SerializeField]
    float valor;
    [SerializeField]
    Transform[] fogos = new Transform[20];
    public bool apagar = false;

    private void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            fogos[i] = transform.GetChild(i).gameObject.transform;
        }
    }

    private void Update()
    {
        if(apagar == true)
        {
            for (int i = 0; i < fogos.Length; i++)
            {
                if(fogos[i] != null)
                {
                    fogos[i].localScale = new Vector2
                        (fogos[i].localScale.x - valor * Time.deltaTime,
                        fogos[i].localScale.y - valor * Time.deltaTime);

                    if (fogos[i].localScale.x < 0.0001)
                        Destroy(this.gameObject);
                }
                
            }
        }
    }
}
