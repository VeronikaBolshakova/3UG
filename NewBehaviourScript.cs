using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Animator animator;
    public static int jump;
    private int vVector = 300;
    float hVector = 7.0f;
    int hVectorSprint = 9;
    int numberOfJumps = 2;
    int waterJumps = 1;
    // Start is called before the first frame update
    void Start()
    {
        jump = 0;
    }

    // Update is called once per frame

    void FixedUpdate()
    {



        animator.SetFloat("hVector", Mathf.Abs(hVector));
        if (Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(hVectorSprint, 0));
            }
            else
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(hVector, 0));
            }
        }

        if (Input.GetKey(KeyCode.A))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(-hVectorSprint, 0));
            }
            else
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(-hVector, 0));
            }
        }


        if (Input.GetKeyDown(KeyCode.Space) && jump > 0)
        {
            jump--;
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, vVector));
        }

    }

    void OnCollisionEnter2D(Collision2D floor)
    {
        if (floor.gameObject.tag == "floor")
        {
            NewBehaviourScript.jump = numberOfJumps;
        }
    }
}



