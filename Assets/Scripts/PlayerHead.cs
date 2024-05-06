using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHead : MonoBehaviour
{
    public List<Sprite> sprites = new List<Sprite>();
    private string itemName;
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        itemName = GetComponentInParent<ItemManager>().GetItem();
        
        switch (itemName)
        {
            case "gravboots":
                spriteRenderer.sprite = sprites[0];
                break;
            case "spear":
                spriteRenderer.sprite = sprites[1];
                break;
            case "mushroom":
                spriteRenderer.sprite = sprites[2];
                break;
            case "box":
                spriteRenderer.sprite = sprites[3];
                break;
            case "phaser":
                spriteRenderer.sprite = sprites[4];
                break;
            case "butterfly":
                spriteRenderer.sprite = sprites[5];
                break;
            case "delete":
                spriteRenderer.sprite = sprites[6];
                break;
            case "instabox":
                spriteRenderer.sprite = sprites[7];
                break;
            default:
                break;
        }
    }
}
