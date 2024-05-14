using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerAiming : MonoBehaviour
{
    // animator
    public Animator animator;

    //public variables
    public float targetDisplacement = 5;
    public float upDist = 2;
    public float downDist = 1;
    public float heightBuffer = 0.5f;
    public GameObject targetObject;

    public LayerMask layerMask;

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
        string currentItem = GetComponent<ItemManager>().GetItem();
        //Debug.Log("Test GetItem method:" + currentItem);

        //list of items that show the target; if it is not these items, hide target sprite
        if (currentItem == "delete" || currentItem == "butterfly" || currentItem == "instabox")
        {
            targetObject.GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            targetObject.GetComponent<SpriteRenderer>().enabled = false;
        }
        //Debug.Log("Target Visible: " + targetObject.GetComponent<SpriteRenderer>().enabled);

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {

            target = new Vector3(this.transform.position.x + (downDist * transform.localScale.x), this.transform.position.y + (targetDisplacement * -1) + heightBuffer, -1);
            animator.SetBool("Down", true);
            animator.SetBool("Up", false);

        }
        else if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {

            target = new Vector3(this.transform.position.x + (upDist * transform.localScale.x), this.transform.position.y + (targetDisplacement), -1);
            animator.SetBool("Down", false);
            animator.SetBool("Up", true);
        }
        else
        {
            target = new Vector3(this.transform.position.x + (targetDisplacement * transform.localScale.x), this.transform.position.y + heightBuffer, -1);
            animator.SetBool("Down", false);
            animator.SetBool("Up", false);
        }

        if(currentItem == "butterfly" || currentItem == "instabox")
        {

            //target = GetTargetRaycastHitPosition();

            RaycastHit2D hitPoint = Physics2D.Raycast(new Vector2(this.transform.position.x, this.transform.position.y), target - this.transform.position, Vector3.Distance(transform.position, target), layerMask);
            if(hitPoint.collider != null)
            {
                target = hitPoint.point;
            }
        }
        //Debug.Log(yFacing);

        targetObject.transform.position = target;

        Debug.DrawLine(transform.position, target);
    }


    



    private Vector3 GetTargetRaycastHitPosition()
    {
        RaycastHit[] allHits;
        allHits = Physics.RaycastAll(this.transform.position, target, Vector3.Distance(transform.position, target));
        foreach (var hit in allHits)
        {
            if (!hit.transform.tag.Equals("player") && !hit.transform.tag.Equals("portal"))
            {
                return new Vector3(hit.point.x, hit.point.y, -1); ;
            }
        }
        return target;
    }



}
