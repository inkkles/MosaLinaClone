using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaserBehavior : MonoBehaviour
{
    //public variables
    public Vector3 direction;
    public float speed;
    public Sprite phaserFullSprite;
    public AudioSource teleportAudio;

    //private variables
    GameObject player;
    bool isStopped;
    bool isInside;
    bool waitingToTeleport;



    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player");
        Physics2D.IgnoreCollision(player.GetComponent<BoxCollider2D>(), this.gameObject.GetComponent<BoxCollider2D>());
        Physics2D.IgnoreCollision(player.GetComponent<CapsuleCollider2D>(), this.gameObject.GetComponent<BoxCollider2D>());
        isInside = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isStopped) transform.position += direction * speed * Time.deltaTime;


        //Screen Wrapping

        float xpos = transform.position.x;
        float ypos = transform.position.y;
        float zpos = transform.position.z;

        if (xpos < -9) xpos = 9;
        if (xpos > 9) xpos = -9;
        if (ypos < -5) ypos = 5;
        if (ypos > 5) ypos = -5;

        transform.position = new Vector3(xpos, ypos, zpos);

        if(waitingToTeleport && !isInside) GetReadyToTeleport();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        waitingToTeleport = true;
        isInside = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        isInside = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isInside = false;
    }

    public void DestroyAndTeleport()
    {
        player.transform.position = this.transform.position;
        Destroy(this.gameObject);
    }

    private void GetReadyToTeleport()
    {
        //if (collision.CompareTag("player")) return;
        if (!isStopped) isStopped = true;
        this.gameObject.GetComponent<SpriteRenderer>().sprite = phaserFullSprite;
        Invoke("DestroyAndTeleport", 0.5f);
        teleportAudio.Play();
    }
}
