using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public static int jump;
    public int vVector = 200;
    private Rigidbody2D player;
    public GameObject receptor;
    public int numberOfJumps = 2;
    public float drag = 3.0f;
    Vector2 hVector = new Vector2(0.2f, 0.0f);
    public float hSpeed = 0.1f;
    public int ammo = 1;
    public GameObject tridentPrefab;
    public Transform attackpoint;
    public GameObject Enemy;
    public float tridentCooldown = 1.0f;
    private float tridentCooldownCounter = 1.0f;
    public int health = 10;
    void Start()
    {
        jump = 2;
        player = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        tridentCooldownCounter -= Time.deltaTime;
        if (Input.GetKey(KeyCode.D))
        {
            player.AddForce(hVector, ForceMode2D.Impulse);
            transform.Translate(hSpeed * 0.4f, 0, 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            player.AddForce(-hVector, ForceMode2D.Impulse);
            transform.Translate(-hSpeed * 0.4f, 0, 0);
        }


        if (Input.GetKeyDown(KeyCode.W) && jump > 0)
        {
            jump--;
            player.AddForce(new Vector2(0, vVector));
        }

        if (Input.GetButtonDown("Fire1") && tridentCooldownCounter <= 0)
        {
            Attack();
            tridentCooldownCounter = tridentCooldown;
        }

        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D floor)
    {
        if (floor.gameObject.tag == "floor")
        {
            jump = numberOfJumps;
        }
    }

    void OnTriggerEnter2D(Collider2D environment)
    {
        if (environment.gameObject.tag == "water")
        {
            vVector = 300;
            drag = 3.0f;
            player.drag = drag;
            hSpeed = 0;
        }

        if (environment.gameObject.tag == "bullet")
        {
            Destroy(environment.gameObject);
            receptor.SendMessage("Ammo", ammo);
        }
    }

    void OnTriggerExit2D(Collider2D noWater)
    {
        if (noWater.gameObject.tag == "water")
        {
            vVector = 200;
            drag = 0.5f;
            player.drag = drag;
            hSpeed = 0.1f;
        }
    }

    void Attack()
    {
        Instantiate(tridentPrefab, attackpoint.GetComponent<Transform>());
    }

    void LoseHealth (int enemyDamage)
    {
        health -= enemyDamage;
    }
}