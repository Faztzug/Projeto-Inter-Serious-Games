using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeInstantiator : MonoBehaviour
{
    [SerializeField]
    GameObject Smoke;
    [SerializeField]
    float spawnTime;
    [SerializeField]
    Vector2 spawnTimeRandomize;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SmokeSpawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SmokeSpawn()
    {
        yield return new WaitForSeconds
            (spawnTime + Random.Range(spawnTimeRandomize.x, spawnTimeRandomize.y));

        Instantiate(Smoke, transform.position, Quaternion.Euler(0,0,0));

        StartCoroutine(SmokeSpawn());

    }
}
