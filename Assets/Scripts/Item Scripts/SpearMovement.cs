using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class SpearMovement : MonoBehaviour
{
    // Start is called before the first frame update

    //public variables
    public GameObject player;
    public float speed;
    public Vector3 targetPos;
    public Vector3 direction;

    public AudioSource shootAudio;
    public AudioSource stickAudio;


    //private variables
    Vector3 playerPos;
    bool isStuck;
    Rigidbody2D rb;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player");
        Physics2D.IgnoreCollision(player.GetComponent<BoxCollider2D>(), this.gameObject.GetComponent<BoxCollider2D>());
        rb = this.GetComponent<Rigidbody2D>();
        shootAudio.Play();

        if (Mathf.Abs(direction.y) > Mathf.Abs(direction.x)) {

            //instead of :
            Debug.Log("SPIN");
            //this.transform.Rotate(Vector3.forward * 90);

            if (direction.y < 0) this.GetComponent<SpriteRenderer>().flipY = true;

        } else
        {
            if(direction.x < 0) this.GetComponent<SpriteRenderer>().flipX = true;
        }

        isStuck = false;
    }


    private void FixedUpdate()
    {
        if (!isStuck) transform.position += direction * speed * Time.fixedDeltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("player") && !isStuck)
        {
            stickAudio.Play();
            isStuck = true;
            //this.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            Physics2D.IgnoreCollision(player.GetComponent<BoxCollider2D>(), this.gameObject.GetComponent<BoxCollider2D>(), false);
            this.gameObject.GetComponent<FixedJoint2D>().connectedBody = collision.gameObject.GetComponent<Rigidbody2D>();
            this.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0.25f;
        }
    }
}
