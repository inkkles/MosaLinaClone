using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MushroomBehavior : MonoBehaviour
{
    //public variables
    public Vector3 direction;
    public GameObject cap;


    //private variables
    bool grow;
    bool isSmall;
    float growAmount;
    float startingForce;
    GameObject player;

    Vector3 mushroomStartScale;


    void Start()
    {
        startingForce = 5;
        mushroomStartScale = transform.localScale;


        //ignore player collision when spawning
        player = GameObject.FindGameObjectWithTag("player");
        //Physics2D.IgnoreCollision(player.GetComponent<BoxCollider2D>(), this.gameObject.GetComponent<BoxCollider2D>());
        Physics2D.IgnoreCollision(player.GetComponent<BoxCollider2D>(), this.gameObject.GetComponentInParent<BoxCollider2D>());

        //scale box down
        //transform.localScale = mushroomStartScale * 0.5f;


        //add initial force
        this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(direction.x, direction.y) * startingForce, ForceMode2D.Impulse);


        grow = false;
        isSmall = true;

    }


    void Update()
    {
        //scale box up
        if (grow)
        {
            growAmount += 0.125f;

            transform.localScale = new Vector3(mushroomStartScale.x + growAmount, mushroomStartScale.y + growAmount, 0);
            if (growAmount >= 0.25f)
            {
                grow = false;
                growAmount = 0;
            }
        }
        //else if(transform.localScale.x > mushroomStartScale.x)
        //{
        //    growAmount += 0.125f;
        //    transform.localScale = new Vector3(mushroomStartScale.x - growAmount, mushroomStartScale.y - growAmount, 0);
        //    if (transform.localScale.x <= mushroomStartScale.x)
        //    {
        //        transform.localScale = mushroomStartScale;
        //        growAmount = 0;
        //        isSmall = true;
        //    }
        //}

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("player"))
        {
            Physics2D.IgnoreCollision(player.GetComponent<BoxCollider2D>(), this.gameObject.GetComponent<BoxCollider2D>(), false);
            Physics2D.IgnoreCollision(player.GetComponent<BoxCollider2D>(), this.gameObject.GetComponentInParent<BoxCollider2D>(), false);
            if(isSmall)
            {
                grow = true;
                isSmall = false;
            }
        }
        //if (isSmall && !collision.gameObject.CompareTag("player"))
        ////if(isSmall)
        //{
        //    grow = true;
        //    isSmall = false;
        //    Physics2D.IgnoreCollision(player.GetComponent<BoxCollider2D>(), this.gameObject.GetComponent<BoxCollider2D>(), false);
        //    Physics2D.IgnoreCollision(player.GetComponent<BoxCollider2D>(), this.gameObject.GetComponentInParent<BoxCollider2D>(), false);

        //}
    }
}
