using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using JetBrains.Annotations;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    //private variables
    ArrayList[] inventory;
    int currentItemNumber;

    // Start is called before the first frame update
    void Start()
    {
        Dictionary<string, int> objects = new Dictionary<string, int>();
        objects.Add("gravboots", 2);
        objects.Add("spear", 4);
        objects.Add("delete", 3);
        objects.Add("phaser", 1);
        objects.Add("butterfly", 2);
        objects.Add("camera", 1);
        objects.Add("bouncer", 2);
        objects.Add("box", 6);

        List<string> names = new List<string>();
        names.Add("gravboots");
        names.Add("spear");
        names.Add("delete");
        names.Add("phaser");
        names.Add("butterfly");
        names.Add("camera");
        names.Add("bouncer");
        names.Add("box");

        inventory = new ArrayList[3];

        for (int i = 0; i < inventory.Length; i++)
        {
            ArrayList currentList = new ArrayList();
            int randNum = Random.Range(0, names.Count - 1);
            currentList.Add(names[randNum]);
            currentList.Add(objects[names[randNum]]);
            names.Remove(names[randNum]);

            inventory[i] = currentList;
        }

        Debug.Log(inventory[0][0] + " " + inventory[1][0] + " " + inventory[2][0]);

        currentItemNumber = 0;



    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            currentItemNumber++;
            if (currentItemNumber == 3) currentItemNumber = 0;
        }
    }
}
