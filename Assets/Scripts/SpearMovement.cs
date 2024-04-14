using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.U2D;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class SpearMovement : MonoBehaviour
{
    // Start is called before the first frame update

    //public variables
    public GameObject player;
    public float speed;
    public Vector3 targetPos;


    //private variables
    Vector3 playerPos;
    Vector3 direction;
    bool isStuck;
    Rigidbody2D rb;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player");
        Physics2D.IgnoreCollision(player.GetComponent<BoxCollider2D>(), this.gameObject.GetComponent<BoxCollider2D>());
        rb = this.GetComponent<Rigidbody2D>();
        playerPos = player.transform.position;

        this.transform.position = new Vector3(playerPos.x, playerPos.y, playerPos.z);
        targetPos = player.GetComponent<PlayerAiming>().targetObject.transform.position;
        direction = Vector3.Normalize(targetPos - transform.position);

        if (Mathf.Abs(direction.y) > Mathf.Abs(direction.x)) { 
            transform.eulerAngles = new Vector3(0, 0, 90);
        }

        isStuck = false;
    }


    private void FixedUpdate()
    {
        if (!isStuck) transform.position += direction * speed * Time.fixedDeltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("player"))
        {
            isStuck = true;
            this.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            Physics2D.IgnoreCollision(player.GetComponent<BoxCollider2D>(), this.gameObject.GetComponent<BoxCollider2D>(), false);
        }
    }
}
