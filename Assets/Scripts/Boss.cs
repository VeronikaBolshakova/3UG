﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private int health = 100;
    private int bulletDamage = 5;
    private int tridentDamage = 10;
    public float Speed = 6.0f;
    public GameObject player;
    private int dir = 0;
    public EnemyHealthBar bossHealthBar;
    private int oldDir = 1;
    public bool death = false;
    private bool flag;

    public Animator animator;

    void Start()
    {
        player = GameObject.Find("Player");
        bossHealthBar.SetMaxEnemyHealth(health);
        flag = false;
    }

    void FixedUpdate()
    {
        if (player.transform.position.x <= this.transform.position.x)
        {
            if (this.transform.position.x - player.transform.position.x <= 8)
            {
                this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-5, 0));
                dir = 1;
                FindObjectOfType<AudioManager>().Play("MonsterGrowl");
            }
        }
        else if (player.transform.position.x >= this.transform.position.x)
        {
            if (player.transform.position.x - this.transform.position.x <= 8)
            {
                dir = 0;
                this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(5, 0));

            }
        }
        if (health <= 0)
        {
            Destroy(this.gameObject);
            FindObjectOfType<AudioManager>().Play("MonsterDeath");
            death = true;
        }
        FlipSprite();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "bullet")
        {
            health -= bulletDamage;
            StartCoroutine(FlashRed());

            if (dir == 1)
                this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(50, 0));
            else
                this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-50, 0));

            FindObjectOfType<AudioManager>().Play("MonsterHit");
            bossHealthBar.SetEnemyHealth(health);
        }

        if (collider.gameObject.tag == "trident")
        {
            health -= tridentDamage;
            StartCoroutine(FlashRed());

            if (dir == 1)
                this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(400, 0));
            else
                this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-400, 0));

            FindObjectOfType<AudioManager>().Play("MonsterHit");
            bossHealthBar.SetEnemyHealth(health);
        }

        if (collider.gameObject.tag == "platform")
        {
            this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 400));
        }
    }
    void FlipSprite()
    {
        if (dir != oldDir)
        {
            this.gameObject.transform.Rotate(0, 180, 0);
            oldDir = dir;

        }
    }

    IEnumerator FlashRed()
    {
        if (flag)
            yield return new WaitForSeconds(0.01f);
        else
            flag = true;

        Color32 c = this.gameObject.GetComponent<SpriteRenderer>().color;
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.1f);
        this.gameObject.GetComponent<SpriteRenderer>().color = c;

        flag = false;
    }
}
