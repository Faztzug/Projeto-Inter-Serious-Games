using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPosicaoZ : MonoBehaviour
{
    Ray ray;
    RaycastHit raycastHit;
    // Start is called before the first frame update
    void Start()
    {
        AtualizarPosicaoZ();
        /*Ray ray = Camera.main.ScreenPointToRay(transform.position);
        RaycastHit raycastHit;
        if (Physics.Raycast(ray, out raycastHit))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y , raycastHit.point.z) ;
        }*/
    }

    private void AtualizarPosicaoZ()
    {
        //ray = Camera.main.ScreenPointToRay(transform.position);
        Physics.Raycast(transform.position,
            new Vector3(transform.position.x, transform.position.y, transform.position.z + 100), out raycastHit);
        transform.position = new Vector3(transform.position.x, transform.position.y, raycastHit.point.z);


        /*if (Physics.Raycast(ray, out raycastHit))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, raycastHit.point.z);
        }*/
    }


}
