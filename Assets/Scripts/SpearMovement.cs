using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.U2D;
using UnityEngine;

public class SpearMovement : MonoBehaviour
{
    // Start is called before the first frame update

    //public variables
    public GameObject player;
    public float speed;


    //private variables
    Vector3 playerPos;
    Vector3 targetPos;
    Vector3 direction;
    bool isStuck;


    void Start()
    {
        playerPos = player.transform.position;
        targetPos = player.GetComponent<PlayerAiming>().targetObject.transform.position;
        direction = Vector3.Normalize(targetPos - playerPos);
        isStuck = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if(!isStuck) transform.position += direction * speed * Time.fixedDeltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isStuck = true;
    }
}
