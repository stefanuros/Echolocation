using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlledMovement : MonoBehaviour
{
    [HideInInspector]public Rigidbody2D rigidBody;
    public float thrust;
    [HideInInspector]public bool grounded;
    public float speed;
    [HideInInspector]public int objectCount = 0;

    // Use this for initialization
    void Start()
    {
        grounded = true;

        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rigidBody.velocity = new Vector2(0, rigidBody.velocity.y);

        //Jumping
        if (Input.GetKey(KeyCode.UpArrow) && grounded)
        {
            grounded = false;

            rigidBody.velocity = new Vector2(rigidBody.velocity.x, 0);

            rigidBody.AddForce(transform.up * thrust);
        }
        //Moving Right
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rigidBody.AddForce(transform.right * speed);
        }
        //Jumping Left
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rigidBody.AddForce(-transform.right * speed);
        }
    }

    //Trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Platform" || other.tag == "Block")
        {
            transform.parent = other.transform;
            objectCount++;
        }
        grounded = (objectCount > 0);
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Platform" || other.tag == "Block")
        {
            transform.parent = null;
            objectCount--;
        }
        grounded = (objectCount > 0);
    }
}
