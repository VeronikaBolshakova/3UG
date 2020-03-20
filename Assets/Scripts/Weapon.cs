using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    int bullet = 1;
    public Transform firepoint;
    public GameObject bulletPrefab;
    private float bulletCooldownCounter = 2.0f;
    public float bulletCooldown = 2.0f;
    private bool lClick = false;

    void Update()
    {
        GetKey();
    }

    void FixedUpdate()
    {
        bulletCooldownCounter -= Time.deltaTime;
        if (lClick == true && bullet == 1 && bulletCooldownCounter <= 0)
        {
            Shoot();
            bullet--;
            lClick = false;
            bulletCooldownCounter = bulletCooldown;
        }
    }
    void Shoot()
    {
        Instantiate(bulletPrefab, firepoint.GetComponent<Transform>());
    }
    void Ammo (int ammo)
    {
        bullet = ammo;
    }

    void GetKey()
    {
        if (Input.GetButtonDown("Fire2") && bulletCooldownCounter <= 0)
        {
            lClick = true;
        }
    }

}
