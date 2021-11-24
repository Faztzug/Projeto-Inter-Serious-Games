using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAnimation : MonoBehaviour
{
    private Animator anim;
    private FazerAndar fazerAndar;
    //private Rigidbody2D rgbd;

    private void Start()
    {
        anim = GetComponent<Animator>();
        fazerAndar = GetComponent<FazerAndar>();
        //rgbd = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (fazerAndar.andando == true)
        {
            anim.SetBool("Andando", true);
        }
        else
        {
            anim.SetBool("Andando", false);
        }

        anim.SetBool("WalkFrente", false);
        anim.SetBool("WalkCostas", false);
        anim.SetBool("WalkEsquerda", false);
        anim.SetBool("WalkDireita", false);

        //frente
        if (fazerAndar.distanceY < -0.1 &&
            fazerAndar.distanceY < Mathf.Abs(fazerAndar.distanceX) * -1)
            anim.SetBool("WalkFrente", true);
        //costas
        else if (fazerAndar.distanceY > 0.1 &&
            fazerAndar.distanceY > Mathf.Abs(fazerAndar.distanceX))
            anim.SetBool("WalkCostas", true);
        //esquerda
        else if (fazerAndar.distanceX < -0.1 &&
            fazerAndar.distanceX < Mathf.Abs(fazerAndar.distanceY) * -1)
            anim.SetBool("WalkDireita", true);
        //direita
        else if (fazerAndar.distanceX > 0.1 &&
            fazerAndar.distanceX > Mathf.Abs(fazerAndar.distanceY))
            anim.SetBool("WalkEsquerda", true);


        anim.SetFloat("DistanceX", fazerAndar.distanceX);
        anim.SetFloat("DistanceY", fazerAndar.distanceY);

    }
}
