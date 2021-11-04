using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPosicaoZ : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Ray ray = Camera.main.ScreenPointToRay(transform.position);
        RaycastHit raycastHit;
        if (Physics.Raycast(ray, out raycastHit))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y , raycastHit.point.z) ;
        }
    }

    
}
