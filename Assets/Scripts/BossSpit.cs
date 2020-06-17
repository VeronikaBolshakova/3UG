using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpit : MonoBehaviour
{
    private float spitSpeed = 10f;
    public GameObject player;
    public Rigidbody2D rb;

    void Start()
    {
        rb.velocity = (player.transform.position - transform.position).normalized * spitSpeed;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag != "boss" && collider.gameObject.tag != "Lab" && collider.gameObject.tag != "bullet" && collider.gameObject.tag != "player")
        {
                Destroy(gameObject);
        }

        //Debug.Log(collider);
    }
}
