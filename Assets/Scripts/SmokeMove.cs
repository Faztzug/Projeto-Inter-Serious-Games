using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeMove : MonoBehaviour
{
    [SerializeField]
    Vector2 speed;
    [SerializeField]
    Vector2 horizontalJittering;
    /*[SerializeField]
    float spawnTime;
    [SerializeField]
    Vector2 spawnTimeRandomize;*/
    [SerializeField]
    float destroyTime;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, destroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime);
        transform.Translate(new Vector2(Random.Range(horizontalJittering.x, horizontalJittering.y), 0)
            * Time.deltaTime);
    }
}
