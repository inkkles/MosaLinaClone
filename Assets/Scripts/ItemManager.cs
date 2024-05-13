using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using JetBrains.Annotations;
using UnityEngine;

public class ItemManager : MonoBehaviour
{

    //public variables
    public GameObject objgravboots;
    public GameObject objspear;
    public GameObject objdelete;
    public GameObject objphaser;
    public GameObject objbutterfly;
    public GameObject objinstabox;
    public GameObject objmushroom;
    public GameObject objbox;

    public bool tutorial;
    public bool debug;




    //private variables
    int currentItemNumber; //current selcted "item number"
    Dictionary<string, int> uses; //tracks all uses
    List<string> totalObjects = new List<string>(); //tracks all objects
    //Dictionary<GameObject, string> debug;
    Vector3 direction;


    int[] currentUses; //tracks current uses of current inventory
    string[] inventory; //tracks contents of the inventory

    // Start is called before the first frame update
    void Start()
    {

        uses = new Dictionary<string, int>();
        uses.Add("gravboots", 2);
        uses.Add("spear", 4);
        uses.Add("delete", 3);
        uses.Add("phaser", 1);
        uses.Add("butterfly", 2);
        uses.Add("instabox", 2);
        uses.Add("mushroom", 2);
        uses.Add("box", 6);

      
        //use once all objects are implemented
        
        totalObjects.Add("gravboots");
        totalObjects.Add("spear");
        totalObjects.Add("mushroom");
        totalObjects.Add("box");
        totalObjects.Add("phaser");
        totalObjects.Add("butterfly");
        totalObjects.Add("delete");
        totalObjects.Add("instabox");
        


         

        currentItemNumber = 0;

            currentUses = new int[3];
            inventory = new string[3];

        if (tutorial) //tutorial item loadout is box, mushroom, spear (replacing ball)
        {
            inventory[0] = "box";
            currentUses[0] = 6;
            inventory[1] = "mushroom";
            currentUses[1] = 2;
            inventory[2] = "spear";
            currentUses[2] = 4;
        }
        else
        {
            for (int i = 0; i < 3; i++)
            {
                int randNum = Random.Range(0, totalObjects.Count - 1);
                inventory[i] = totalObjects[randNum];
                currentUses[i] = uses[totalObjects[randNum]];
                totalObjects.Remove(totalObjects[randNum]);
            }
        }



        Debug.Log(inventory[0] + ", " + inventory[1] + " " + inventory[2]);
    }

    public string[] GetInventory()
    {
        return inventory;
    }


    public string GetItem()
    {
        return inventory[currentItemNumber];
    }

    public int GetUses()
    {
        return currentUses[currentItemNumber];
    }

    // Update is called once per frame
    void Update()
    {

        //switch held object
        if (Input.GetKeyDown(KeyCode.C))
        {
            currentItemNumber++;
            if (currentItemNumber >= 3) currentItemNumber = 0;
            //if (currentUses[currentItemNumber] == 0) currentItemNumber++;
            

            Debug.Log(inventory[currentItemNumber]);

        }


        //direction variable calculates vector from player to target, is needed in multiple spawn events
        direction = Vector3.Normalize(this.gameObject.GetComponent<PlayerAiming>().targetObject.transform.position - this.transform.position);

        //spawn in object
        if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.X))
        {

            if (currentUses[currentItemNumber] > 0)
            {
                if (inventory[currentItemNumber] == "spear")
                {
                    SpawnSpear();
                    currentUses[currentItemNumber] = currentUses[currentItemNumber] - 1;
                }
                if (inventory[currentItemNumber] == "box") { 
                    SpawnBox();
                    currentUses[currentItemNumber] = currentUses[currentItemNumber] - 1;
                }
                if (inventory[currentItemNumber] == "mushroom")
                {
                    SpawnMushroom();
                    currentUses[currentItemNumber] = currentUses[currentItemNumber] - 1;
                }
                if (inventory[currentItemNumber] == "gravboots")
                {
                    //CHECK IF GROUNDED ON GRAV BOOTS
                    SpawnGravBoots();
                    currentUses[currentItemNumber] = currentUses[currentItemNumber] - 1;
                }
                if (inventory[currentItemNumber] == "phaser")
                {
                    SpawnPhaser();
                    currentUses[currentItemNumber] = currentUses[currentItemNumber] - 1;
                }
                if (inventory[currentItemNumber] == "butterfly")
                {
                    SpawnButterfly();
                    currentUses[currentItemNumber] = currentUses[currentItemNumber] - 1;
                }
                if (inventory[currentItemNumber] == "delete")
                {
                    SpawnDelete();
                    currentUses[currentItemNumber] = currentUses[currentItemNumber] - 1;
                }
                if (inventory[currentItemNumber] == "instabox")
                {
                    SpawnInstabox();
                    currentUses[currentItemNumber] = currentUses[currentItemNumber] - 1;
                }

                //THIS SHOULD ONLY RUN IF THE ITEM SUCCESSFULLY SPAWNS
                //currentUses[currentItemNumber] = currentUses[currentItemNumber] - 1;
            }


        }


    }



    private void SpawnBox()
    {
        GameObject box = Instantiate(objbox, this.transform.position, Quaternion.identity);
        box.GetComponent<BoxBehavior>().direction = direction;
    }

    private void SpawnSpear()
    {
        GameObject spear;
        if (Mathf.Abs(direction.y) > Mathf.Abs(direction.x))
        {
            spear = Instantiate(objspear, this.transform.position, Quaternion.Euler(0, 0, 90));
        } else
        {
            spear = Instantiate(objspear, this.transform.position, Quaternion.identity);
        }
            
        spear.GetComponent<SpearMovement>().direction = direction;
    }

    private void SpawnMushroom()
    {
        GameObject mushroom = Instantiate(objmushroom, this.transform.position, Quaternion.identity);
        mushroom.GetComponent<LegacyMushroomBehavior>().direction = direction;
    }

    private void SpawnGravBoots()
    {
        GameObject gravBoots = Instantiate(objgravboots, this.transform.position, Quaternion.identity);
        gravBoots.GetComponent<GravBootsBehavior>().direction = direction;
    }

    private void SpawnPhaser()
    {
        GameObject phaser = Instantiate(objphaser, this.transform.position, Quaternion.identity);
        phaser.GetComponent<PhaserBehavior>().direction = direction;
    }

    private void SpawnButterfly()
    {
        GameObject butterfly = Instantiate(objbutterfly, this.transform.position, Quaternion.identity);
        butterfly.GetComponent<ButterflyBehavior>().direction = direction;
        this.transform.position = this.gameObject.GetComponent<PlayerAiming>().targetObject.transform.position;
    }

    private void SpawnDelete()
    {
        GameObject delete = Instantiate(objdelete, this.gameObject.GetComponent<PlayerAiming>().targetObject.transform.position, Quaternion.identity);
    }

    private void SpawnInstabox()
    {
        GameObject instabox = Instantiate(objinstabox, this.gameObject.GetComponent<PlayerAiming>().targetObject.transform.position, Quaternion.identity);
    }

}
