using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalBehavior : MonoBehaviour
{
    public int sceneBuildIndex;
    bool isUnlocked;
    public int fruitCounter;

    private void Start()
    {
        isUnlocked = false;
    }

    // Update is called once per frame
    void Update()
    {

        //RESET BUTTON
        if(Input.GetKey(KeyCode.R))
        {
            //PUT X SPRITE HERE @ ALESHA
            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
        }

        if (fruitCounter == 2) isUnlocked = true;


        //CHECKS IF PLAYER FELL TO DEATH
        //PUT X SPRITE HERE @ ALESHA
        if(GameObject.FindGameObjectWithTag("player").transform.position.y < -5) SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);



    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("player") && isUnlocked)
        {
            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
        }
        
    }
}
