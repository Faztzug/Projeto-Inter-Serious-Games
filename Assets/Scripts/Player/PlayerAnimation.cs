using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;
    private PlayerControl playerControl;
    //private Rigidbody2D rgbd;

    private void Start()
    {
        anim = GetComponent<Animator>();
        playerControl = GetComponent<PlayerControl>();
        //rgbd = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(playerControl.andando == true)
        {
            anim.SetBool("Andando", true);
        }
        else
        {
            anim.SetBool("Andando", false);
        }

        anim.SetBool("WalkFrente", false);
        anim.SetBool("WalkEsquerda", false);
        anim.SetBool("WalkDireita", false);
        anim.SetBool("WalkCostas", false);

        if (playerControl.distanceY < -0.1 && 
            playerControl.distanceY < Mathf.Abs(playerControl.distanceX) * -1)
            anim.SetBool("WalkFrente", true);
        else if (playerControl.distanceY > 0.1 &&
            playerControl.distanceY > Mathf.Abs(playerControl.distanceX))
            anim.SetBool("WalkCostas", true);
        else if (playerControl.distanceX < -0.1 &&
            playerControl.distanceX < Mathf.Abs(playerControl.distanceY) * -1)
            anim.SetBool("WalkEsquerda", true);
        else if (playerControl.distanceX > 0.1 &&
            playerControl.distanceX > Mathf.Abs(playerControl.distanceY))
            anim.SetBool("WalkDireita", true);


        anim.SetFloat("DistanceX", playerControl.distanceX);
        anim.SetFloat("DistanceY", playerControl.distanceY);

    }
}
