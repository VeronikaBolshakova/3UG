using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trident : MonoBehaviour
{
    public float tridentLifeTime = 0.2f;
    public int damage = 2;
    public int tridentSpeed = 20;
    int direction = 0;
    public GameObject attackPoint;
    void Start()
    {
        attackPoint = GameObject.Find("attackpointSupport");
        Destroy(this.gameObject, tridentLifeTime);
    }


    void FixedUpdate()
    {
        this.gameObject.GetComponent<Rigidbody2D>().AddForce((this.transform.position - attackPoint.transform.position).normalized * tridentSpeed);
    }
}
