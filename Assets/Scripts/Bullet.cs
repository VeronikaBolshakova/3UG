using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int bulletSpeed = 500;
    public float bulletBackSpeed = 10.0f;
    //public float bulletLifeTime = 2.0f;
    void Start()
    {
        this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(bulletSpeed, 0));
        //Destroy(this.gameObject, bulletLifeTime);
    }

    void Update()
    {
        this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-bulletBackSpeed, 0));
    }
}
