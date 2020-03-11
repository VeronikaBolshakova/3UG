using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    int bullet = 1;
    public Transform firepoint;
    public GameObject bulletPrefab;
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && bullet == 1)
        {
            Shoot();
            bullet--;
        }
    }
    void Shoot()
    {
        Instantiate(bulletPrefab, firepoint.GetComponent<Transform>());
    }
    void ammo (int ammo)
    {
        bullet = ammo;
    }



}
