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
    private bool jump = true;

    void Start()
    {
        player = GameObject.Find("Player");
        enemyHealthBar.SetMaxEnemyHealth(health);
    }


    void FixedUpdate()
    {
        if (player.transform.position.x <= this.transform.position.x)
        {
            if (this.transform.position.x - player.transform.position.x <= 4)
            {
                this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-3, 0));
                dir = 1;
            }
        }
        else if (player.transform.position.x >= this.transform.position.x)
        {
            if (player.transform.position.x - this.transform.position.x <= 4)
            {
                dir = 0;
                this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(3, 0));
            }
        }
        if (health <= 0)
        {
            Destroy(this.gameObject);
            FindObjectOfType<AudioManager>().Play("RobotDeath");
        }
        if (player.transform.position.y >= this.transform.position.y - 0.5f)
        {
            this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 200));
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
                this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(100, 0));
            else
                this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-100, 0));

            FindObjectOfType<AudioManager>().Play("RobotDamage");
            enemyHealthBar.SetEnemyHealth(health);
        }

        if (collider.gameObject.tag == "trident")
        {
            health -= tridentDamage;
            StartCoroutine(FlashRed());

            if (dir == 1)
                this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(400, 0));
            else
                this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-400, 0));

            FindObjectOfType<AudioManager>().Play("RobotDamage");
            enemyHealthBar.SetEnemyHealth(health);
        }

        if (collider.gameObject.tag == "player")
        {
            if (player.transform.position.y > this.transform.position.y && jump == true)
            {
                this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 100));
                jump = false;
            }
            if (player.transform.position.y <= this.transform.position.y)
            {
                jump = true;
            }
        }
        if (collider.gameObject.tag == "water")
        {
            health -= bulletDamage;
            StartCoroutine(FlashRed());
            FindObjectOfType<AudioManager>().Play("RobotDamage");
            enemyHealthBar.SetEnemyHealth(health);
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
        Color32 c = this.gameObject.GetComponent<SpriteRenderer>().color;
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.1f);
        this.gameObject.GetComponent<SpriteRenderer>().color = c;
    }
}
