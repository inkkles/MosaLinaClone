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
    BoxCollider2D bx;
    GameObject player;

    Vector3 mushroomStartScale;
    Vector3 capStartScale;


    void Start()
    {
        startingForce = 5;
        mushroomStartScale = transform.localScale;
        capStartScale = cap.transform.localScale;


        //ignore player collision when spawning
        player = GameObject.FindGameObjectWithTag("player");
        Physics2D.IgnoreCollision(player.GetComponent<BoxCollider2D>(), this.gameObject.GetComponent<BoxCollider2D>());
        Physics2D.IgnoreCollision(player.GetComponent<BoxCollider2D>(), cap.gameObject.GetComponent<PolygonCollider2D>());
        bx = GetComponent<BoxCollider2D>();

        //scale box down
        //transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        //cap.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        transform.localScale = mushroomStartScale * 0.5f;
        cap.transform.localScale = capStartScale * 0.5f;


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
            growAmount += 0.25f;

            transform.localScale = new Vector3(mushroomStartScale.x + growAmount, mushroomStartScale.y + growAmount, mushroomStartScale.z + growAmount);
            cap.transform.localScale = new Vector3(capStartScale.x + growAmount, capStartScale.y + growAmount, capStartScale.z + growAmount);
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
            Physics2D.IgnoreCollision(player.GetComponent<BoxCollider2D>(), cap.GetComponent<PolygonCollider2D>(), false);
        }
    }
}
