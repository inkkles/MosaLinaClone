using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflyBehavior : MonoBehaviour
{
    //public variables
    public Vector3 direction;
    public float startingForce;
    public Sprite butterfly;
    public Sprite whiteButterfly;

    //private
    GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player");
        Physics2D.IgnoreCollision(player.GetComponent<BoxCollider2D>(), this.gameObject.GetComponent<PolygonCollider2D>());



        Invoke("TeleportPlayer", 3.5f);
        Invoke("WhiteOut", 2f);
        Invoke("Revert", 2.25f);
        Invoke("WhiteOut", 2.75f);
        
        this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-direction.x, direction.y) * startingForce, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void TeleportPlayer()
    {
        player.transform.position = this.transform.position;
        Destroy(this.gameObject);
    }

    public void WhiteOut()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = whiteButterfly;
    }

    public void Revert()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = butterfly;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Physics2D.IgnoreCollision(player.GetComponent<BoxCollider2D>(), this.gameObject.GetComponent<PolygonCollider2D>(), false);
    }
}
