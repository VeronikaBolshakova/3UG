using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tridentPefab : MonoBehaviour
{
    public float tridentLifeTime = 0.2f;
    public int tridentSpeed = 20;
    void Start()
    {
        Destroy(this.gameObject, tridentLifeTime);

    }


    void Update()
    {
            this.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.right * tridentSpeed);
    }
}
