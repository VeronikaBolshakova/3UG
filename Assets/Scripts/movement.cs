using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public static int jump;
    public int vVectorNoWater = 300;
    public int vVectorWater = 625;
    Vector2 hVectorNoWater = new Vector2(0.3f, 0.0f);
    Vector2 hVectorWater = new Vector2(0.2f, 0.0f);
    Vector2 vVectorWaterPropelled = new Vector2(0.0f, 0.5f);
    Vector2 vVectorNoWaterPropelled = new Vector2(0.0f, 0.8f);
    private float noWaterDrag = 1.0f;
    private float waterDrag = 2.5f;
    private float waterGravity = 1.0f;
    private float noWaterGravity = 2.5f;
    private float hSpeedNoWater = 0.1f;
    private int numberOfJumps = 1;
    int movementType = 1;
    public bool propeller;
    public int dir = 0;
    private Rigidbody2D player;
    private bool propellerSound = false;
    public GameObject gun;
    public int ammo = 1;
    public Transform attackpoint;
    public GameObject Enemy;
    public int health = 10;
    private int maxHealth = 10;
    public int bossDamage = 5;
    private int spitDamage = 2;
    private bool D = false;
    private bool A = false;
    private bool W = false;
    private float propellerFuel = 50f;
    public HealthBar healthbar;
    public PropellerBar propellerbar;
    public HealthUI healthUI;
    public Animator animator;
    public bool ismoving = false;
    private int enemyDamage = 1;
    private int fishEnemyDamage = 2;
    public bool key = false;
    public CheckpointSystem checkpointSystem;
    private bool flag;


    void Start()
    {
        jump = 1;
        player = GetComponent<Rigidbody2D>();
        healthbar.SetMaxHealth(health);
        animator.SetBool("Moving", ismoving);
        flag = false;
        health = maxHealth;
        propeller = false;

    }

    void Update()
    {
        GetKeys();

    }

    void FixedUpdate()
    {

        if (movementType == 0) // Movement outside water
        {
            NoWaterMovement(player);
        }

        if (movementType == 1) // Movement inside water
        {
            WaterMovement(player);
        }

        if (health <= 0)
        {
            FindObjectOfType<DeathScreen>().StartDeathScreen();
 
        }
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        Debug.Log(collider.gameObject.tag);
        if (collider.gameObject.tag == "floor" || collider.gameObject.tag == "platform" || collider.gameObject.tag == "thorns")
        {
            jump = numberOfJumps;
            propellerSound = true;
            propellerFuel = 50f;
            propellerbar.SetPropellerSlider(propellerFuel);
        }

        if (collider.gameObject.tag == "enemy")
        {
            health -= enemyDamage;
            StartCoroutine(FlashRed());
            healthbar.SetHealth(health);
            FindObjectOfType<AudioManager>().Play("PlayerHit");
            if (dir == 0)
                this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-100, 0));
            else
                this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(100, 0));
        }



        if (collider.gameObject.tag == "FishEnemy")
        {
            health -= fishEnemyDamage;
            StartCoroutine(FlashRed());
            healthbar.SetHealth(health);
            FindObjectOfType<AudioManager>().Play("PlayerHit");
            if (dir == 0)
                this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-100, 0));
            else
                this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(100, 0));
        }

        if (collider.gameObject.tag == "boss")
        {
            health -= bossDamage;
            StartCoroutine(FlashRed());
            healthbar.SetHealth(health);
            FindObjectOfType<AudioManager>().Play("PlayerHit");
            if (dir == 0)
                this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-100, 0));
            else
                this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(100, 0));
        }



        if (collider.gameObject.tag == "key")
        {
            Destroy(collider.gameObject);
            key = true;
        }



        if (collider.gameObject.tag == "propeller")
        {
            Destroy(collider.gameObject);
            propeller = true;
            animator.SetBool("Propeller", true);
            propellerbar.Activate();
        }



    }

    void OnTriggerEnter2D(Collider2D environment)
    {
    
        if (environment.gameObject.tag == "water")
        {
            player.drag = waterDrag;
            player.gravityScale = waterGravity;
            movementType = 1;
        }

        if (environment.gameObject.tag == "Lab")
        {
            player.drag = noWaterDrag;
            movementType = 0;
            player.gravityScale = noWaterGravity;
        }

        if (environment.gameObject.tag == "checkpoint")
        {
            checkpointSystem.SetRestartPosition(this.transform.position);
        }

        if (environment.gameObject.tag == "spit")
        {
            Destroy(environment.gameObject);
            health -= spitDamage;
            StartCoroutine(FlashRed());
            healthbar.SetHealth(health);
            FindObjectOfType<AudioManager>().Play("PlayerHit");
            if (dir == 0)
                this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-100, 0));
            else
                this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(100, 0));
        }

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
                transform.Translate(hSpeedNoWater * 0.3f, 0, 0);
               
            }
            else
            {
                D = false;
                player.AddForce(-hVectorNoWater, ForceMode2D.Impulse);
                transform.Translate(-hSpeedNoWater * 0.3f, 0, 0);
                
            }
        }

        if(D == false)
        {
            if (propeller == true)
            {
                animator.SetBool("MovingPropeller", false);
            }
            else
            {
                animator.SetBool("Moving", false);
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
                transform.Translate(-hSpeedNoWater * 0.3f, 0, 0);
                player.AddForce(hVectorNoWater, ForceMode2D.Impulse);
                
            }
            else
            {
                A = false;
                player.AddForce(-hVectorNoWater, ForceMode2D.Impulse);
                transform.Translate(hSpeedNoWater * 0.3f, 0, 0);
                
            }
        }
        if (A == false)
        {
            if (propeller == true)
            {
                animator.SetBool("MovingPropeller", false);
            }
            else
            {
                animator.SetBool("Moving", false);
            }
        }

        if (W == true && jump > 0)
        {
            jump--;
            W = false;
            player.AddForce(new Vector2(0, vVectorNoWater));
            
        }
        if (W == false)
        {
            if (propeller == true)
            {
                animator.SetBool("MovingPropeller", false);
            }
            else
            {
                animator.SetBool("Moving", false);
            }
        }
        if (Input.GetKey(KeyCode.Space) && propeller == true)
        {
            if (propellerFuel >= 40.0f)
            {
                player.AddForce(vVectorNoWaterPropelled, ForceMode2D.Impulse);
                propellerFuel--;
                propellerbar.SetPropellerSlider(propellerFuel);
                jump--;
            }
            if (propellerSound == true)
            {

                FindObjectOfType<AudioManager>().Play("Jetpack");
                propellerSound = false;
            }
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

        if (D == false)
        {
            if (propeller == true)
            {
                animator.SetBool("MovingPropeller", false);
            }
            else
            {
                animator.SetBool("Moving", false);
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
            A = false;
            player.AddForce(-hVectorWater, ForceMode2D.Impulse);
            
        }

        if (A == false)
        {
            if (propeller == true)
            {
                animator.SetBool("MovingPropeller", false);
            }
            else
            {
                animator.SetBool("Moving", false);
            }
        }

        if (W == true && jump > 0)
        {
            jump--;
            W = false;
            player.AddForce(new Vector2(0, vVectorWater));
        }

        if (W == false)
        {
            if (propeller == true)
            {
                animator.SetBool("MovingPropeller", false);
            }
            else
            {
                animator.SetBool("Moving", false);
            }
        }

        if (Input.GetKey(KeyCode.Space) && propeller == true)
        {
            if (propellerFuel >= 0f)
            {
                player.AddForce(vVectorWaterPropelled, ForceMode2D.Impulse);
                propellerFuel--;
                propellerbar.SetPropellerSlider(propellerFuel);
                jump--;
            }
            if (propellerSound == true)
            {

                FindObjectOfType<AudioManager>().Play("Jetpack");
                propellerSound = false;
            }
        }
    }


    void GetKeys()
    {
        if (Input.GetKey(KeyCode.D))
        {
            D = true;
            if(propeller == true)
            {
                animator.SetBool("MovingPropeller", true);
            }else
            { 
                animator.SetBool("Moving", true);
            }
        }
       
        if (Input.GetKey(KeyCode.A))
        {
            A = true;
            if (propeller == true)
            {
                animator.SetBool("MovingPropeller", true);
            }
            else
            {
                animator.SetBool("Moving", true);
            }
        }
       
        if (Input.GetKeyDown(KeyCode.W) && jump > 0)
        {
            W = true;
            if (propeller == true)
            {
                animator.SetBool("MovingPropeller", true);
            }
            else
            {
                animator.SetBool("Moving", true);
            }
        }
        
    }

    public void AddHealth(int cure)
    {
        health += cure;
        if(health >= maxHealth)
        {
            health = maxHealth; 
        }
        healthbar.SetHealth(health);
        FindObjectOfType<AudioManager>().Play("Healing");
    }

    public void MaxHealth()
    {
        health = maxHealth;
        healthbar.SetHealth(health);

    }
    IEnumerator FlashRed()
    {
        if (flag)
            yield return null;
        else
            flag = true;

        Color32 c = this.gameObject.GetComponent<SpriteRenderer>().color;
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.1f);
        this.gameObject.GetComponent<SpriteRenderer>().color = c;
        flag = false;
    }
    public bool GetPropellerState()
    {
        return propeller;

    }

}