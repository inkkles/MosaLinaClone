using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShadowCast : MonoBehaviour
{
    GameObject shadow;
    SpriteRenderer shadowSprite;

    public float xOffset = -0.1f;
    public float yOffset = -0.075f;

    // Start is called before the first frame update
    void Start()
    {
        //Spawn in game object with a transform component (redundent, transform components are mandatory)
        shadow = new GameObject("Dropshadow", typeof(Transform));
        //Make the transform of the shadow dependent on the transform of whatever object this script is connected to
        shadow.transform.parent = this.transform;
        //Move shadow by public offset, with the Z at 1 to have it render behind everything else
        shadow.transform.localPosition = new Vector3(xOffset, yOffset, 4);
        //make scale identical
        shadow.transform.localScale = this.transform.localScale;

        //Add sprite renderer
        shadowSprite = shadow.AddComponent<SpriteRenderer>();
        shadowSprite.enabled = true;
        //Make the sprites the same, but make it black
        shadowSprite.sprite = this.GetComponent<SpriteRenderer>().sprite;
        shadowSprite.color = Color.black;     
    }

    // Update is called once per frame
    void Update()
    {
        //Update the shadow's sprite to keep up with potential animation
        shadowSprite.sprite = this.GetComponent<SpriteRenderer>().sprite;
        shadow.transform.localPosition = new Vector3(xOffset, yOffset, 1);

    }
}
