using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 20f;
    public Rigidbody2D rb;
    void Start()
    {
        rb.velocity = transform.right * bulletSpeed;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log(collider.name);
        if (collider.gameObject.tag != "water" && collider.name != "Player") {
            Destroy(this.gameObject);
        }
    }
}

