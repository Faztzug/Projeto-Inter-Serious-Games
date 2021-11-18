using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NuvemsScroll : MonoBehaviour
{
    [SerializeField]
    private Vector2 speed = new Vector2(2f,0);
    [SerializeField]
    private float width = 13;
    [SerializeField]
    private Vector2 height = new Vector2(1,5);
    [SerializeField]
    private Vector2 randomWidth = new Vector2(-4,0);
    [SerializeField]
    private Transform[] nuvems;
    private int childCount;

    private void Start()
    {
        childCount = transform.childCount;
        for (int i = 0; i < childCount; i++)
        {
            nuvems[i] = transform.GetChild(i).gameObject.transform;
        }
    }

    private void Update()
    {
        foreach (Transform nuvem in nuvems)
        {
            if(nuvem != null)
            {
                nuvem.Translate(speed * Time.deltaTime);
                if (nuvem.position.x > width)
                {
                    nuvem.position = new Vector2(-width + Random.Range(randomWidth.x, randomWidth.y), 
                        Random.Range(height.x, height.y));
                }
            }
            
        }
    }
}
