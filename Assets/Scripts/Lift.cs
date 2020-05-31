using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lift : MonoBehaviour
{
    public Animator animator;
    public GameObject player;

    void Update()
    {
        
        if (this.transform.position.y < player.transform.position.y && player.transform.position.x - this.transform.position.x < 5)
        {
            animator.SetBool("UpLift", true);
        }
        


    }

}
