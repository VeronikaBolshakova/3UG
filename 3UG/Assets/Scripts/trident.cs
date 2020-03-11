using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trident : MonoBehaviour
{
    public float tridentLifeTime = 0.2f;
    public GameObject receptorEnemy;
    public int damage = 2;
    public int tridentSpeed = 50;
    void Start()
    {
        receptorEnemy = GameObject.Find("Enemy");
        Destroy(this.gameObject, tridentLifeTime);
    }


    void Update()
    {
        this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(tridentSpeed, 0));
    }
}
