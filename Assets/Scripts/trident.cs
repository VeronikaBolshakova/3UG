using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trident : MonoBehaviour
{

    public int damage = 2;
    public int tridentSpeed = 20;
    public Transform attackPoint;
    public GameObject tridentPrefab;
    private float tridentCooldown = 5.0f;
    private float currentTime = 0f;
    private float counterTime = 0f;

    void Update()
    {
        currentTime = (float)(Time.time % 60f);
        if (Input.GetButtonDown("Fire1") && currentTime - counterTime > tridentCooldown)
        {
            Attack();
            counterTime = currentTime;
        }
    }

    void Attack()
    {
        FindObjectOfType<AudioManager>().Play("Trident");
        Instantiate(tridentPrefab, attackPoint.position, attackPoint.rotation);
    }
}
