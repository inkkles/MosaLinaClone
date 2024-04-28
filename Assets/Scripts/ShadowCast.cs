using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShadowCast : MonoBehaviour
{
    GameObject shadow;
    SpriteRenderer shadowSprite;

    float xOffset;
    float yOffset;

    // Start is called before the first frame update
    void Start()
    {
        //Game-wide shadow offsets
        xOffset = -0.1f;
        yOffset = -0.075f;

        //Spawn in game object with a transform component (redundent, transform components are mandatory)
        shadow = new GameObject("Dropshadow", typeof(Transform));
        //Make the shadow a child of this object
        shadow.transform.parent = this.transform;
        //set the rotation of the shadow to the same rotation this object started as
        shadow.transform.rotation = this.transform.rotation;
        //match the scale
        shadow.transform.localScale = Vector3.one;
        

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
        //offset the shadow
        shadow.transform.position = this.transform.position + new Vector3(xOffset, yOffset, 1);

    }
}
