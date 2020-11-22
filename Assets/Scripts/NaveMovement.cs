using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D bx;
    public float speed = 5f;
    private float currentSpeed;
    private int state = 0;
    public float clusterPower;
    void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
        bx = transform.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        scMovement();
    }

    private void scMovement()
    {
        switch (state)
        {
            case 0:
                currentSpeed = speed;
                break;
            case 1:
                currentSpeed = -speed;
                break;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, clusterPower);
        }


        rb.velocity = new Vector2(currentSpeed, rb.velocity.y);
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag== "Pared1")
        {
            state = 1;
            Debug.Log("State = " + state);
        }else if (col.gameObject.tag == "Pared0")
        {
            state = 0;
            Debug.Log("State = " + state);
        }
        
    }
}
