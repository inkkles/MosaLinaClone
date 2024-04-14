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
    public GameObject objbouncer;
    public GameObject objbox;

    public bool isPlaytest;




    //private variables
    int currentItemNumber; //current selcted "item number"
    Dictionary<GameObject, int> uses; //tracks all uses
    List<GameObject> totalObjects = new List<GameObject>(); //tracks all objects
    Dictionary<GameObject, string> debug;


    int[] currentUses; //tracks current uses of current inventory
    GameObject[] inventory; //tracks contents of the inventory

    // Start is called before the first frame update
    void Start()
    {
        
        uses = new Dictionary<GameObject, int>();
        uses.Add(objgravboots, 2);
        uses.Add(objspear, 4);
        uses.Add(objdelete, 3);
        uses.Add(objphaser, 1);
        uses.Add(objbutterfly, 2);
        uses.Add(objcamera, 1);
        uses.Add(objbouncer, 2);
        uses.Add(objbox, 6);

        currentItemNumber = 0;

        currentUses = new int[3];
        inventory = new GameObject[3];





        //testing for monday

        if(isPlaytest)
        {
            inventory[0] = objspear;
            currentUses[0] = uses[objspear];
        } else
        {
            //use once all objects are implemented

            totalObjects.Add(objgravboots);
            totalObjects.Add(objspear);
            totalObjects.Add(objdelete);
            totalObjects.Add(objphaser);
            totalObjects.Add(objbutterfly);
            totalObjects.Add(objcamera);
            totalObjects.Add(objbouncer);
            totalObjects.Add(objbox);

            currentItemNumber = 0;

            currentUses = new int[3];
            inventory = new GameObject[3];

            for (int i = 0; i < 3; i++)
            {
                int randNum = Random.Range(0, totalObjects.Count - 1);
                inventory[i] = totalObjects[randNum];
                currentUses[i] = uses[totalObjects[randNum]];
                totalObjects.Remove(totalObjects[randNum]);


            }

        }








        //use debugger to print out names of objects
        /*
        debug = new Dictionary<GameObject, string>();
        debug.Add(objgravboots, "gravboots");
        debug.Add(objspear, "spear");
        debug.Add(objdelete, "delete");
        debug.Add(objphaser, "phaser");
        debug.Add(objbutterfly, "butterfly");
        debug.Add(objcamera, "camera");
        debug.Add(objbouncer, "bouncer");
        debug.Add(objbox, "box");


        Debug.Log(debug[inventory[0]] + ", " + debug[inventory[1]] + " " + debug[inventory[2]]);
        */
    }

    // Update is called once per frame
    void Update()
    {
        //switch held object
        /*
        if (Input.GetKeyDown(KeyCode.C))
        {
            currentItemNumber++;
            if (currentUses[currentItemNumber] == 0) currentItemNumber++;
            if (currentItemNumber <= 3) currentItemNumber = 0;
        }
        */
        
        //spawn in object
        if(Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.X))
        {
            Instantiate(inventory[currentItemNumber]);
        }
       
        
    }
}
