using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravUI : MonoBehaviour
{
    public Sprite upSprite;
    public Sprite downSprite;
    public Sprite leftSprite;
    public Sprite rightSprite;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Physics2D.gravity.x != 0)
        {
            if(Physics2D.gravity.x > 0)
            {
                this.GetComponent<SpriteRenderer>().sprite = rightSprite;
            } else
            {
                this.GetComponent<SpriteRenderer>().sprite = leftSprite;
            }
        } else
        {
            if (Physics2D.gravity.y > 0)
            {
                this.GetComponent<SpriteRenderer>().sprite = upSprite;
            }
            else
            {
                this.GetComponent<SpriteRenderer>().sprite = downSprite;
            }
        }
    }
}
