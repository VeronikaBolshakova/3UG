using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour
{
    private float timer = 0.0f;
    public HealthUI healthUI;
    private int seconds = 0;
    private float counter = 0.0f;
    private int currentSeconds = 0;
    public float healthPackCooldown = 10.0f;
    public movement player;
    public int recoverHealth = 2;

    void Start()
    {
        counter = healthPackCooldown;
    }


    void Update()
    {
        healthUI.SetTransparency(counter);
        currentSeconds = seconds;
        timer += Time.deltaTime;
        seconds = (int)timer % 60;
        if (currentSeconds != seconds)
        {
            counter++;
        }
        if (counter >= healthPackCooldown)
        {
            counter = healthPackCooldown;
        }

        if (Input.GetKey(KeyCode.E) && counter >= healthPackCooldown)
        {
            player.AddHealth(recoverHealth);
            counter = 0;
        }

    }

}
