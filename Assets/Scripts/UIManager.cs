using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    //GameObject
    public GameObject itemOne;
    public GameObject itemTwo;
    public GameObject itemThree;
    public GameObject player;

    //Sprites
    public Sprite box;
    public Sprite spear;
    public Sprite mushroom;
    public Sprite delete;
    public Sprite gravboots;
    public Sprite phaser;
    public Sprite instabox;
    public Sprite butterfly;

    //private variables
    string[] inventory;
    GameObject[] items;


    // Start is called before the first frame update
    void Start()
    {
        player = player = GameObject.FindGameObjectWithTag("player");
        inventory = player.GetComponent<ItemManager>().GetInventory();
        items = new GameObject[3];

        for(int i = 0; i < 3; i++) {

            if (inventory[i] == "box")
            {
                items[i].GetComponent<SpriteRenderer>().sprite = box;
            }
            if (inventory[i] == "spear")
            {
                items[i].GetComponent<SpriteRenderer>().sprite = spear;
            }
            if (inventory[i] == "mushroom")
            {
                items[i].GetComponent<SpriteRenderer>().sprite = mushroom;
            }
            if (inventory[i] == "delete")
            {
                items[i].GetComponent<SpriteRenderer>().sprite = delete;
            }
            if (inventory[i] == "gravboots")
            {
                items[i].GetComponent<SpriteRenderer>().sprite = gravboots;
            }
            if (inventory[i] == "phaser")
            {
                items[i].GetComponent<SpriteRenderer>().sprite = phaser;
            }
            if (inventory[i] == "instabox")
            {
                items[i].GetComponent<SpriteRenderer>().sprite = instabox;
            }
            if (inventory[i] == "butterfly")
            {
                items[i].GetComponent<SpriteRenderer>().sprite = butterfly;
            }



        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
