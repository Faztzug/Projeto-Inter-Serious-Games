using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchBall : MonoBehaviour
{
    private Animator anim;
    private Canvas canvas;

    private void Start()
    {
        anim = GetComponent<Animator>();
        canvas = transform.root.gameObject.GetComponent<Canvas>();
    }
    public void Touch(bool drag)
    {
        transform.position = Input.mousePosition;

        if(canvas.renderMode == RenderMode.ScreenSpaceCamera)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }
        

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
