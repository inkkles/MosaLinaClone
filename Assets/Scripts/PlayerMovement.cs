using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    // sprites 
    public SpriteRenderer spriteLeft;
    public SpriteRenderer spriteRight;
    public SpriteRenderer downLeft; 
    public SpriteRenderer downRight; 

    //inputs
    bool right;
    bool left;
    bool jump;

    //public variables
    public float playerSpeed = 2f;
    public float jumpForce = 4000f;
    

    //private variables
    Vector3 scale;
    Rigidbody2D rb;
    BoxCollider2D bodyCollider;
    CapsuleCollider2D isGroundedCollider;
    bool isGrounded;



    // Start is called before the first frame update
    void Start()
    {
        right = false; left = false; jump = false;
        rb = GetComponent<Rigidbody2D>();
        bodyCollider = GetComponent<BoxCollider2D>();
        isGroundedCollider = GetComponent<CapsuleCollider2D>();
        isGrounded = false;

    }

    // Update is called once per frame
    void Update()
    {
        right = Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow);
        left = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow);
        jump = Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Y) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.J);

        int horizontalMove = 0;

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

        //movement
        if (isGrounded)
        {
            //grounded movement is dragless
            this.transform.position += new Vector3(horizontalMove * playerSpeed * Time.deltaTime, 0, 0);
            if (jump) Jump();
        }
        else
        {
            //same as grounded movement, should change to deal with momentum like in game
            this.transform.position += new Vector3(horizontalMove * playerSpeed * Time.deltaTime, 0, 0);
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
