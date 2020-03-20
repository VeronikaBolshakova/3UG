using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int bulletSpeed = 500;
    public float bulletBackSpeed = 10.0f;
    public GameObject player;
    public GameObject gun;
    public GameObject firePoint;
    public float lifeTime = 3.0f;
    int ammo = 1;
    //public float bulletLifeTime = 2.0f;
    void Start()
    {
        player = GameObject.Find("Player");
        gun = GameObject.Find("Gun");
        firePoint = GameObject.Find("firepointSupport");
        this.gameObject.GetComponent<Rigidbody2D>().AddForce((this.transform.position - firePoint.transform.position).normalized * bulletSpeed);
        //Destroy(this.gameObject, bulletLifeTime);
    }

    void FixedUpdate()
    {
        this.gameObject.GetComponent<Rigidbody2D>().AddForce((player.transform.position - this.transform.position).normalized * bulletBackSpeed);
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
        {
            Destroy(this.gameObject);
            gun.SendMessage("Ammo", ammo);
        }
    }
}

