using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    public Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Agafem input (com ja vau veure)
        bool walk = Input.GetButton("Horizontal");
        bool stop = Input.GetButtonDown("Fire2");
        bool shoot = Input.GetButtonDown("Fire3");
        bool jump = Input.GetButtonDown("Jump");
        // Activem triggers segons input previ
        //if (walk)
        //    animator.SetTrigger("Walk");
        animator.SetBool("walk", walk);
        //if (stop)
            //animator.SetTrigger("Stop");
        animator.SetBool("stop", stop);
        animator.SetBool("shoot", shoot);
        animator.SetBool("jump", jump);
    }
}
