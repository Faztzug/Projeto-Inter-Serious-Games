using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespostaDestroyer : MonoBehaviour
{
    public void DestroyThis()
    {
        Destroy(this.gameObject);
    }
}
