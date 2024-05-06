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
        if (fruitCounter == 2)
        {
            isUnlocked = true;
            GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("player") && isUnlocked)
        {
            Debug.Log("Level beat");
            GameObject.FindWithTag("Manager").GetComponent<LevelManager>().changeLevel();
        }
        
    }
}
