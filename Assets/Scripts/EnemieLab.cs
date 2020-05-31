using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieLab : MonoBehaviour
{
    private int health = 10;
    private int bulletDamage = 1;
    private int tridentDamage = 5;
    public float Speed = 4.0f;
    public GameObject player;
    private int dir = 0;
    public EnemyHealthBar enemyHealthBar;
    private int oldDir = 1;

    void Start()
    {
        player = GameObject.Find("Player");
        enemyHealthBar.SetMaxEnemyHealth(health);
    }


    void FixedUpdate()
    {
        if (player.transform.position.x <= this.transform.position.x)
        {
            if (this.transform.position.x - player.transform.position.x <= 8)
            {
                this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-3, 0));
                dir = 1;
            }
        }
        else if (player.transform.position.x >= this.transform.position.x)
        {
            if (player.transform.position.x - this.transform.position.x <= 8)
            {
                dir = 0;
                this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(3, 0));
            }
        }
        if (health <= 0)
        {
            Destroy(this.gameObject);
            FindObjectOfType<AudioManager>().Play("ZombieDeath");
        }
        if (player.transform.position.y >= this.transform.position.y)
        {
            this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 350));
        }

            FlipSprite();


    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "bullet")
        {
            health -= bulletDamage;

            if (dir == 1)
                this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(100, 0));
            else
                this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-100, 0));

            FindObjectOfType<AudioManager>().Play("ZombieHit");
            enemyHealthBar.SetEnemyHealth(health);
        }

        if (collider.gameObject.tag == "trident")
        {
            health -= tridentDamage;

            if (dir == 1)
                this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(400, 0));
            else
                this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-400, 0));

            FindObjectOfType<AudioManager>().Play("ZombieHit");
            enemyHealthBar.SetEnemyHealth(health);
        }

        if (collider.gameObject.tag == "player")
        {
            if (player.transform.position.y >= this.transform.position.y)
            {
                this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 100));
            }
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
}
