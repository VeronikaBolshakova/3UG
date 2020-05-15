using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tridentPefab : MonoBehaviour
{
    public float tridentLifeTime = 0.2f;
    public int tridentSpeed = 20;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, tridentLifeTime);

    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(tridentSpeed, 0));
    }
}
