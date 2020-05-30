using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    public int health = 10;
    public int bulletDamage = 1;
    public int tridentDamage = 5;
    public float Speed = 4.0f;
    public GameObject player;
    public int enemyDamage = 1;
    private int dir = 0;
    public EnemyHealthBar enemyHealthBar;


    void Start()
    {
        player = GameObject.Find("Player");
        enemyHealthBar.SetMaxEnemyHealth(health);
    }


    void FixedUpdate()
    {
            this.gameObject.GetComponent<Rigidbody2D>().AddForce((player.transform.position - this.transform.position).normalized * Speed);


        if (player.transform.position.x <= this.transform.position.x) {
            this.gameObject.transform.Rotate(0, 0, 0);
            dir = 1;
        }
        else if (player.transform.position.x >= this.transform.position.x) { 
            dir = 0;
            this.gameObject.transform.Rotate(0, 180, 0);
        }
        if (health <= 0)
        {
            Destroy(this.gameObject);
            FindObjectOfType<AudioManager>().Play("ZombieDeath");
        }

    }



    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "bullet")
        {
            health -= bulletDamage;

            if (dir == 1)
                this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(50, 0));
            else
                this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-50, 0));

            FindObjectOfType<AudioManager>().Play("ZombieHit");
            enemyHealthBar.SetEnemyHealth(health);
        }

        if (collider.gameObject.tag == "trident")
        {
            health -= tridentDamage;

            if (dir == 1)
                this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2 (400,0));
            else
                this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-400, 0));

            FindObjectOfType<AudioManager>().Play("ZombieHit");
            enemyHealthBar.SetEnemyHealth(health);
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
        if (collider.gameObject.tag == "thorns")
        {
            Speed = 4.5f;
        }
    }


}

