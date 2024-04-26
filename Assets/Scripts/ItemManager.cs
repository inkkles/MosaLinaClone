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
    public GameObject objcamera;
    public GameObject objmushroom;
    public GameObject objbox;

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
        uses.Add("camera", 1);
        uses.Add("mushroom", 2);
        uses.Add("box", 6);

      
        //use once all objects are implemented

        totalObjects.Add("gravboots");
        totalObjects.Add("spear");
        totalObjects.Add("mushroom");
        totalObjects.Add("box");
        totalObjects.Add("phaser");

        /*
        totalObjects.Add("objdelete");
        totalObjects.Add("butterfly");
        totalObjects.Add("camera");


         */

        currentItemNumber = 0;

            currentUses = new int[3];
            inventory = new string[3];

            for (int i = 0; i < 3; i++)
            {
                int randNum = Random.Range(0, totalObjects.Count - 1);
                inventory[i] = totalObjects[randNum];
                currentUses[i] = uses[totalObjects[randNum]];
                totalObjects.Remove(totalObjects[randNum]);


            }



        if(debug) Debug.Log(inventory[0] + ", " + inventory[1] + " " + inventory[2]);
    }

    // Update is called once per frame
    void Update()
    {

        //switch held object
        if (Input.GetKeyDown(KeyCode.C))
        {
            currentItemNumber++;
            if (currentItemNumber >= 3) currentItemNumber = 0;
            if (currentUses[currentItemNumber] == 0) currentItemNumber++;
            

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
                    spawnSpear();
                    currentUses[currentItemNumber] = currentUses[currentItemNumber] - 1;
                }
                if (inventory[currentItemNumber] == "box") { 
                    spawnBox();
                    currentUses[currentItemNumber] = currentUses[currentItemNumber] - 1;
                }
                if (inventory[currentItemNumber] == "mushroom")
                {
                    spawnMushroom();
                    currentUses[currentItemNumber] = currentUses[currentItemNumber] - 1;
                }
                if (inventory[currentItemNumber] == "gravboots")
                {
                    //CHECK IF GROUNDED ON GRAV BOOTS
                    spawnGravBoots();
                    currentUses[currentItemNumber] = currentUses[currentItemNumber] - 1;
                }
                if (inventory[currentItemNumber] == "phaser")
                {
                    spawnPhaser();
                    currentUses[currentItemNumber] = currentUses[currentItemNumber] - 1;
                }

                //THIS SHOULD ONLY RUN IF THE ITEM SUCCESSFULLY SPAWNS
                //currentUses[currentItemNumber] = currentUses[currentItemNumber] - 1;
            }


        }


    }



    private void spawnBox()
    {
        GameObject box = Instantiate(objbox, this.transform.position, Quaternion.identity);
        box.GetComponent<BoxBehavior>().direction = direction;
    }

    private void spawnSpear()
    {
        GameObject spear = Instantiate(objspear, this.transform.position, Quaternion.identity);
        spear.GetComponent<SpearMovement>().direction = direction;
    }

    private void spawnMushroom()
    {
        GameObject mushroom = Instantiate(objmushroom, this.transform.position, Quaternion.identity);
        mushroom.GetComponent<MushroomBehavior>().direction = direction;
    }

    private void spawnGravBoots()
    {
        GameObject gravBoots = Instantiate(objgravboots, this.transform.position, Quaternion.identity);
        gravBoots.GetComponent<GravBootsBehavior>().direction = direction;
    }

    private void spawnPhaser()
    {
        GameObject phaser = Instantiate(objphaser, this.transform.position, Quaternion.identity);
        phaser.GetComponent<PhaserBehavior>().direction = direction;
    }

}
