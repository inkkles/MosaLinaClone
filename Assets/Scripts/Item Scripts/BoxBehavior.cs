using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxBehavior : MonoBehaviour
{

    //public variables
    public Vector3 direction;


    //private variables
    bool grow;
    bool isSmall;
    float growAmount;
    float startingForce;
    BoxCollider2D bx;
    GameObject player;


    void Start()
    {
        startingForce = 5;



        //ignore player collision when spawning
        player = GameObject.FindGameObjectWithTag("player");
        Physics2D.IgnoreCollision(player.GetComponent<BoxCollider2D>(), this.gameObject.GetComponent<BoxCollider2D>());
        bx = GetComponent<BoxCollider2D>();

        //scale box down
        transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);


        //add initial force
        this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(direction.x, direction.y) * startingForce, ForceMode2D.Impulse);

        
        grow = false;
        isSmall = true;
        


        

    }


    void Update()
    {   
        //scale box up
        if(grow)
        {
            growAmount += 0.25f;
            
            transform.localScale = new Vector3(0.5f + growAmount, 0.5f + growAmount, 0.5f + growAmount);
            if (growAmount >= 0.5f) grow = false;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isSmall && !collision.gameObject.CompareTag("player"))
        {
            grow = true;
            isSmall = false;
            Physics2D.IgnoreCollision(player.GetComponent<BoxCollider2D>(), this.gameObject.GetComponent<BoxCollider2D>(), false);
        }
    }
}
