using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class GravBootsBehavior : MonoBehaviour
{
    //public variables
    public float speed;
    public Vector3 targetPos;
    public Vector3 direction;

    float dir;
    float g = 9.8f;
    

    //private variables
    Vector3 playerPos;
    bool isStuck;
    Rigidbody2D rb;

    public static Vector2 gravity;
    public GameObject player;

    enum GravityDirection { Down, Left, Up, Right };
    GravityDirection gravDir = GravityDirection.Down;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("start");
        player = GameObject.FindGameObjectWithTag("player");

        targetPos = player.GetComponent<PlayerAiming>().targetObject.transform.position;


        if(Mathf.Abs(direction.y) > Mathf.Abs(direction.x))
        {
            if (direction.y > 0)
            {
                gravDir = GravityDirection.Up;
            }
            else
            {
                gravDir = GravityDirection.Down;
            }
        } else
        {
            if (direction.x > 0)
            {
                gravDir = GravityDirection.Right;
            }
            else
            {
                gravDir = GravityDirection.Left;
            }
        }


        /*
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            gravDir = GravityDirection.Down;
        }

        else if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            gravDir= GravityDirection.Up;
        }
        else
        {
            if (player.transform.localScale.x < 0)
            {
                gravDir = GravityDirection.Right; 
            }
            else
            {
                gravDir = GravityDirection.Left;
            }
        }
        */

    }

    // Update is called once per frame
    void Update()
    {
        

        //if (!player.GetComponent<PlayerMovement>().isGrounded)

       
   
      switch (gravDir)
        {
            case GravityDirection.Down:
                Physics2D.gravity = new Vector2(0, -g);
                transform.rotation = Quaternion.Euler(0, 0, 0);
            break; 
            case GravityDirection.Left:
                Physics2D.gravity = new Vector2(-g, 0);
                transform.rotation = Quaternion.Euler(0, 0, 270);
                break;
            case GravityDirection.Right:
                Physics2D.gravity= new Vector2(g, 0);
                transform.rotation = Quaternion.Euler(0, 0, 90);
                break;
            case GravityDirection.Up:
                Physics2D.gravity= new Vector2(0, g);
                transform.rotation = Quaternion.Euler(0, 0, 180);
                break;

        }
    }
}
