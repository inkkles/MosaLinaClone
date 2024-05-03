using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteBehavior : MonoBehaviour
{
    GameObject collidedObject;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroySelf", 0.5f);
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collidedObject = collision.gameObject;
    }
    



    public void DestroySelf()
    {
        Destroy(collidedObject);
        Destroy(this.gameObject);
    }

  }
