using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchBall : MonoBehaviour
{
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void Touch(bool drag)
    {
        transform.position = Input.mousePosition;

        if (drag == true)
        {
            
            anim.SetBool("drag", true);
            anim.SetTrigger("dragTrigger");
        }
        else
        {
            anim.SetBool("drag", false);
            anim.SetTrigger("Start");
        }
        
    }
}
