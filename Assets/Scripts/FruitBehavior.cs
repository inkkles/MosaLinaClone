using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleBehavior : MonoBehaviour
{

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
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("player") && !isTouched)
        {
            isTouched = true;
            portal.GetComponent<PortalBehavior>().fruitCounter++;

        }
    }
}
