using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Animator animator;
    public GameObject player;
    public movement playerScript;
    void Update()
    {
        if(playerScript.key == true) { 
            player = GameObject.Find("Player");
            if (this.transform.position.x - player.transform.position.x <= 4)
            {
                animator.SetBool("OpenDoor", true);
            }
        }
    }
}
