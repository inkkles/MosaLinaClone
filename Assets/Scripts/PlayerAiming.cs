using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAiming : MonoBehaviour
{

    //public variables
    public bool targetVisible;
    public int targetDisplacement = 5;
    public float upDist = 2;
    public float downDist = 1;
    public float heightBuffer = 0.5f;
    public GameObject targetObject;

    //private variables
    Vector3 target;
    int yFacing;
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //yFacing = 0;
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) {

            target = new Vector3(this.transform.position.x + (downDist * transform.localScale.x), this.transform.position.y + (targetDisplacement * -1) + heightBuffer, -1);

        }
        else if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) {

            target = new Vector3(this.transform.position.x + (upDist * transform.localScale.x), this.transform.position.y + (targetDisplacement), -1);
            
        } else
        {
            target = new Vector3(this.transform.position.x + (targetDisplacement * transform.localScale.x), this.transform.position.y + heightBuffer, -1);
        }

        //Debug.Log(yFacing);

        
        targetObject.transform.position = target;

        Debug.DrawLine(transform.position, target);
    }



}
