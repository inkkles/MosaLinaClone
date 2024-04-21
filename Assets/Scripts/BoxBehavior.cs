using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxBehavior : MonoBehaviour
{

    bool grow;
    bool isSmall;
    float growAmount;
    BoxCollider2D bx;

    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        grow = false;
        isSmall = true;
        bx = GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if(grow)
        {
            growAmount += 0.25f;
            
            transform.localScale = new Vector3(0.5f + growAmount, 0.5f + growAmount, 0.5f + growAmount);
            if (growAmount >= 0.5f) grow = false;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isSmall)
        {
            grow = true;
            isSmall = false;
        }
    }
}
