﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 10;
    public int bulletDamage = 1;
    public int tridentDamage = 2;
    public GameObject gun;
    private int ammo = 1;
    public float Speed = 4.0f;
    public GameObject player;
    public int enemyDamage = 1;

    void Start()
    {
        gun = GameObject.Find("Gun");
        player = GameObject.Find("Player");
    }


    void FixedUpdate()
    {
        this.gameObject.GetComponent<Rigidbody2D>().AddForce((player.transform.position - this.transform.position).normalized * Speed);
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "bullet")
        {
            health -= bulletDamage;
            Destroy(collider.gameObject);
            gun.SendMessage("Ammo", ammo);

        }

        if (collider.gameObject.tag == "trident")
        {
            health -= tridentDamage;
        }

        if (collider.gameObject.tag == "platform")
        {
            this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 300));
        }
    }

    void OnCollisionExit2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "floor")
        {
            Speed = 2.0f;
        }
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "floor")
        {
            Speed = 4.5f;
        }
    }
}

