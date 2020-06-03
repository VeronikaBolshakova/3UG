using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lift : MonoBehaviour
{
    public Animator animator;
    public GameObject player;
    private float timer = 0.0f;
    private int seconds = 0;
    private float counter = 0.0f;
    private int currentSeconds = 0;
    public float liftCooldown = 5.0f;
    private bool liftUp = false;

    void Update()
    {
        currentSeconds = seconds;
        timer += Time.deltaTime;
        seconds = (int)timer % 60;
        if (currentSeconds != seconds)
        {
            counter++;
        }

        if (counter >= liftCooldown && liftUp == false)
        {
            liftUp = true;
            counter = 0;
            animator.SetBool("UpLift", true);

        }

        if (counter >= liftCooldown && liftUp == true)
        {
            liftUp = false;
            counter = 0;
            animator.SetBool("UpLift", false);

        }


    }
}
