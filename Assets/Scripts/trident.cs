using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trident : MonoBehaviour
{

    public int damage = 2;
    public int tridentSpeed = 20;
    public Transform attackPoint;
    public GameObject tridentPrefab;
    private float timer = 0.0f;
    public TridentUI tridentUI;
    private int seconds = 0;
    private float counter = 0.0f;
    private int currentSeconds = 0;
    public float tridentCooldown = 5.0f;

    void Start()
    {
        counter = tridentCooldown;
    }


    void Update()
    {
        tridentUI.SetTransparency(counter);
        currentSeconds = seconds;
        timer += Time.deltaTime;
        seconds = (int)timer % 60;
        if(currentSeconds != seconds)
        {
            counter++;
        }
        if (counter >= tridentCooldown)
        {
            counter = tridentCooldown;
        }
 
        if (Input.GetButtonDown("Fire1") && counter >= tridentCooldown)
        {
            Attack();
            counter = 0;
        }

    }

    void Attack()
    {
        FindObjectOfType<AudioManager>().Play("Trident");
        Instantiate(tridentPrefab, attackPoint.position, attackPoint.rotation);
    }
}
