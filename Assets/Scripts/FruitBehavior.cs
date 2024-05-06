using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleBehavior : MonoBehaviour
{
    public AudioSource collectSound;
    bool isTouched;
    GameObject portal;

    // Start is called before the first frame update
    void Start()
    {
        isTouched = false;
        portal = GameObject.FindGameObjectWithTag("portal");
    }

    // Update is called once per frame
    void Update()
    {
        if (isTouched) this.gameObject.GetComponent<SpriteRenderer>().color = Color.gray;

        if(transform.position.x > 16 || transform.position.x < -12 ||
           transform.position.y > 6  || transform.position.y < -7 )
        {
            collect();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("player") && !isTouched)
        {
            collect();
        }
    }
    private void OnDestroy()
    {
        if(!isTouched)
        {
            portal.GetComponent<PortalBehavior>().fruitCounter++;
            collectSound.Play();
        }
    }

    private void collect()
    {
        if (isTouched) return;
        isTouched = true;
        collectSound.Play();
        portal.GetComponent<PortalBehavior>().fruitCounter++;
    }
}
