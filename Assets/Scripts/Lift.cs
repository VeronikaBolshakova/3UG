using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lift : MonoBehaviour
{
    public Animator animator;
    public GameObject player;

    void OnCollisionEnter2D(Collision2D collider)
    {
        //player = GameObject.Find("Player");
        if (collider.gameObject.tag == "Player")
        {
            animator.SetBool("UpLift", true);
        }
    }
}
