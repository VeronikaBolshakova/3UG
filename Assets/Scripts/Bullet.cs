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
        if (collider.gameObject.tag != "water" && collider.name != "Player" && collider.gameObject.tag != "Lab" && collider.gameObject.tag != "checkpoint") {
            Destroy(this.gameObject);
        }
    }
}

