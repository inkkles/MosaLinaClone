using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    //inputs
    bool right;
    bool left;
    bool jump;

    //public variables
    public float maxVelocity = 2f;
    public float jumpForce = 275f;
    public float acceleration = 10000f;
    

    //private variables
    Vector3 scale;
    Rigidbody2D rb;
    BoxCollider2D bodyCollider;
    CapsuleCollider2D isGroundedCollider;
    bool isGrounded;
    int horizontalMove;



    // Start is called before the first frame update
    void Start()
    {
        right = false; left = false; jump = false;
        rb = GetComponent<Rigidbody2D>();
        bodyCollider = GetComponent<BoxCollider2D>();
        isGroundedCollider = GetComponent<CapsuleCollider2D>();
        isGrounded = false;
        horizontalMove = 0;

    }

    // Update is called once per frame
    void Update()
    {
        right = Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow);
        left = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow);
        jump = Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Y) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.J);

        horizontalMove = 0;

        if (Input.GetKey(KeyCode.A))
        {
            horizontalMove -= 1;
            scale = transform.localScale;
            scale.x = -1f;
            transform.localScale = scale;
        }
        if (Input.GetKey(KeyCode.D))
        {
            horizontalMove += 1;
            scale = transform.localScale;
            scale.x = 1f;
            transform.localScale = scale;
        }
        //Debug.Log(horizontalMove);

        //movement
        if (jump && isGrounded) Jump();

    }


    private void FixedUpdate()
    {
        //rb.velocity = new Vector2(horizontalMove * playerSpeed * Time.fixedDeltaTime, rb.velocity.y);
        Vector2 movementPlane = new Vector2(rb.velocity.x, 0);

        /*
        Debug.Log(movementPlane.magnitude);
        if (movementPlane.magnitude < maxVelocity)
        {
            rb.AddForce(new Vector2(horizontalMove * acceleration * Time.fixedDeltaTime, 0), ForceMode2D.Force);
        }
        else
        {
            rb.velocity = new Vector2(maxVelocity, 0);
            Debug.Log("terminal velocity");
        }
        */
        rb.AddForce(new Vector2(horizontalMove * acceleration * Time.fixedDeltaTime, 0), ForceMode2D.Force);

        if(movementPlane.magnitude > maxVelocity)
        {
            rb.velocity = new Vector2(maxVelocity, rb.velocity.y);
        }

        


    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isGroundedCollider) {
            if(!isGrounded) Debug.Log("grounded");
            isGrounded = true;
            
            //TODO: Apply impulse force on object jumped off of (aka `collision`)
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (isGroundedCollider)
        {
            Debug.Log("fell");
            isGrounded = false;
        }
    }

    private void Jump()
    {
        isGrounded = false;
        rb.AddForce(Vector2.up * jumpForce);
    }

    
}
