using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public static int jump;
    public int vVectorNoWater = 300;
    public int vVectorWater = 400;
    Vector2 hVectorNoWater = new Vector2(0.2f, 0.0f);
    Vector2 hVectorWater = new Vector2(0.2f, 0.0f);
    Vector2 vVectorWaterPropelled = new Vector2(0.0f, 0.5f);
    public float noWaterDrag = 1.0f;
    public float waterDrag = 3.0f;
    public float hSpeedNoWater = 0.1f;
    public int numberOfJumps = 1;
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
    private int dir = 0;
    private bool D = false;
    private bool A = false;
    private bool W = false;
    private bool rClick = false;

    void Start()
    {
        jump = 1;
        player = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        GetKeys();
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

        if (rClick == true && tridentCooldownCounter <= 0)
        {
            rClick = false;
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
        if (collider.gameObject.tag == "floor" || collider.gameObject.tag == "platform")
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
        if (D == true)
        {
            if (dir == 1)
            {
                dir = 0;
                transform.Rotate(0, 180, 0);
            }
        }

        if (D == true)
        {
            
            if (dir == 0)
            {
                D = false;
                player.AddForce(hVectorNoWater, ForceMode2D.Impulse);
                transform.Translate(hSpeedNoWater * 0.4f, 0, 0);
            }
            else
            {
                D = false;
                player.AddForce(-hVectorNoWater, ForceMode2D.Impulse);
                transform.Translate(-hSpeedNoWater * 0.4f, 0, 0);
            }
        }

        if (A == true)
        {
            if (dir == 0)
            {
                dir = 1;
                transform.Rotate(0, 180, 0);
            }
        }

        if (A == true)
        {

            if (dir == 0)
            {
                A = false;
                player.AddForce(hVectorNoWater, ForceMode2D.Impulse);
                transform.Translate(-hSpeedNoWater * 0.4f, 0, 0);
            }
            else
            {
                A = false;
                player.AddForce(-hVectorNoWater, ForceMode2D.Impulse);
                transform.Translate(hSpeedNoWater * 0.4f, 0, 0);
            }
        }

        if (W == true && jump > 0)
        {
            jump--;
            W = false;
            player.AddForce(new Vector2(0, vVectorNoWater));
        }
    }

    void WaterMovement(Rigidbody2D player)
    {
        if (D == true)
        {
            if (dir == 1)
            {
                dir = 0;
                transform.Rotate(0, 180, 0);
            }
        }

        if (D == true)
        {
            D = false;
            player.AddForce(hVectorWater, ForceMode2D.Impulse);
        }

        if (A == true)
        {
            if (dir == 0)
            {
                dir = 1;
                transform.Rotate(0, 180, 0);
            }
        }

        if (A == true)
        {
            A = false;
            player.AddForce(-hVectorWater, ForceMode2D.Impulse);
        }


        if (W == true && jump > 0)
        {
            jump--;
            W = false;
            player.AddForce(new Vector2(0, vVectorWater));
        }
    }

    void WaterPropelledMovement(Rigidbody2D player)
    {
        if (D == true)
        {
            if (dir == 1)
            {
                dir = 0;
                transform.Rotate(0, 180, 0);
            }
        }

        if (D == true)
        {
            D = false;
            player.AddForce(hVectorWater, ForceMode2D.Impulse);
        }

        if (A == true)
        {
            if (dir == 0)
            {
                dir = 1;
                transform.Rotate(0, 180, 0);
            }
        }

        if (A == true)
        {
            A = false;
            player.AddForce(-hVectorWater, ForceMode2D.Impulse);
        }

        if (Input.GetKey(KeyCode.W))
        {
            player.AddForce(vVectorWaterPropelled, ForceMode2D.Impulse);

        }
    }

    void GetKeys()
    {
        if (Input.GetKey(KeyCode.D))
        {
            D = true;
        }

        if (Input.GetKey(KeyCode.A))
        {
            A = true;
        }

        if (Input.GetKeyDown(KeyCode.W) && jump > 0)
        {
            W = true;
        }

        if (Input.GetButtonDown("Fire1") && tridentCooldownCounter <= 0)
        {
            rClick = true;
        }
    }
}