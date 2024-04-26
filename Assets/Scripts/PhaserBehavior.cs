using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaserBehavior : MonoBehaviour
{
    //public variables
    public Vector3 direction;
    public float speed;

    //private variables
    GameObject player;
    bool isStopped;



    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player");
        Physics2D.IgnoreCollision(player.GetComponent<BoxCollider2D>(), this.gameObject.GetComponent<BoxCollider2D>());
    }

    // Update is called once per frame
    void Update()
    {
        if(!isStopped) transform.position += direction * speed * Time.deltaTime;
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!isStopped) isStopped = true;
        Invoke("DestroyAndTeleport", 0.5f);
    }

    public void DestroyAndTeleport()
    {
        player.transform.position = this.transform.position;
        Destroy(this.gameObject);
    }
}
