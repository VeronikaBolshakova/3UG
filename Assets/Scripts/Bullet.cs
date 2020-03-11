using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int bulletSpeed = 500;
    public float bulletBackSpeed = 50.0f;
    public GameObject player;
    public GameObject gun;
    public float lifeTime = 3.0f;
    int ammo = 1;
    //public float bulletLifeTime = 2.0f;
    void Start()
    {
        player = GameObject.Find("Player");
        gun = GameObject.Find("Gun");
        this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(bulletSpeed, 0));
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

