using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firepoint;
    public GameObject bulletPrefab;

    void Update()
    {
        if (Input.GetButtonDown("Fire2") )
        {
            Shoot();
        }
    }

    void Shoot()
    {
        //FindObjectOfType<AudioManager>().Play("Pistol");
        Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
    }




}
