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
    void FixedUpdate()
    {
        bulletCooldownCounter -= Time.deltaTime;
        if (Input.GetButtonDown("Fire2") && bullet == 1 && bulletCooldownCounter <= 0)
        {
            Shoot();
            bullet--;
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



}
