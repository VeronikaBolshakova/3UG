using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_2 : MonoBehaviour
{
    public Animator animator;
    public GameObject player;

    void Update()
    {
        //player = GameObject.Find("Player");
        if (player.transform.position.x - this.transform.position.x >= 66)
        {
            animator.SetBool("OpenDoor", true);
        }
    }
}
