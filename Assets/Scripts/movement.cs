using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public static int jump;
    public int vVectorNoWater = 200;
    public int vVectorWater = 300;
    Vector2 hVectorNoWater = new Vector2(0.2f, 0.0f);
    Vector2 hVectorWater = new Vector2(0.2f, 0.0f);
    Vector2 vVectorWaterPropelled = new Vector2(0.0f, 0.5f);
    public float noWaterDrag = 1.0f;
    public float waterDrag = 3.0f;
    public float hSpeedNoWater = 0.1f;
    public int numberOfJumps = 2;
    int movementType = 0;
    bool propeller = false;

    private Rigidbody2D player;
    public GameObject gun;
    public int ammo = 1;
    public GameObject tridentPrefab;
    public Transform attackpoint;
    public GameObject Enemy;
    public float tridentCooldown = 1.0f;
    private float tridentCooldownCounter = 1.0f;
    public int health = 10;
    public int enemyDamage = 1;

    void Start()
    {
        jump = 2;
        player = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        tridentCooldownCounter -= Time.deltaTime;

        if (movementType == 0) // Movement outside water
        {
            NoWaterMovement(player); 
        }

        if (movementType == 1) // Movement inside water
        {
            WaterMovement(player);
        }

        if (movementType == 2) // Movement inside water + propeller
        {
            WaterPropelledMovement(player);
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

    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "floor")
        {
            jump = numberOfJumps;
        }

        if (collider.gameObject.tag == "enemy")
        {
            health -= enemyDamage;
        }

        if (collider.gameObject.tag == "propeller")
        {
            Destroy(collider.gameObject);
            propeller = true;
        }
    }

    void OnTriggerEnter2D(Collider2D environment)
    {
        if (environment.gameObject.tag == "water")
        {
            player.drag = waterDrag;
            if (propeller == false)
            {
                movementType = 1;
            }

            if (propeller == true)
            {
                movementType = 2;
            }
        }

        if (environment.gameObject.tag == "bullet")
        {
            Destroy(environment.gameObject);
            gun.SendMessage("Ammo", ammo);
        }

        if (environment.gameObject.tag == "propeller")
        {
            Destroy(environment.gameObject);
            propeller = true;
        }
    }

    void OnTriggerExit2D(Collider2D noWater)
    {
        if (noWater.gameObject.tag == "water")
        {
            player.drag = noWaterDrag;
            movementType = 0;
        }
    }

    void Attack()
    {
        Instantiate(tridentPrefab, attackpoint.GetComponent<Transform>());
    }

    void NoWaterMovement(Rigidbody2D player)
    {
        if (Input.GetKey(KeyCode.D))
        {
            player.AddForce(hVectorNoWater, ForceMode2D.Impulse);
            transform.Translate(hSpeedNoWater * 0.4f, 0, 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            player.AddForce(-hVectorNoWater, ForceMode2D.Impulse);
            transform.Translate(-hSpeedNoWater * 0.4f, 0, 0);
        }


        if (Input.GetKeyDown(KeyCode.W) && jump > 0)
        {
            jump--;
            player.AddForce(new Vector2(0, vVectorNoWater));
        }
    }

    void WaterMovement(Rigidbody2D player)
    {
        if (Input.GetKey(KeyCode.D))
        {
            player.AddForce(hVectorWater, ForceMode2D.Impulse);
        }

        if (Input.GetKey(KeyCode.A))
        {
            player.AddForce(-hVectorWater, ForceMode2D.Impulse);
        }


        if (Input.GetKeyDown(KeyCode.W) && jump > 0)
        {
            jump--;
            player.AddForce(new Vector2(0, vVectorWater));
        }
    }

    void WaterPropelledMovement(Rigidbody2D player)
    {
        if (Input.GetKey(KeyCode.D))
        {
            player.AddForce(hVectorWater, ForceMode2D.Impulse);
        }

        if (Input.GetKey(KeyCode.A))
        {
            player.AddForce(-hVectorWater, ForceMode2D.Impulse);
        }

        if (Input.GetKey(KeyCode.W))
        {
            player.AddForce(vVectorWaterPropelled, ForceMode2D.Impulse);
        }
    }
}