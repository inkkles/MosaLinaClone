using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalBehavior : MonoBehaviour
{
    public AudioSource unlockSound;
    public AudioSource portalSound;
    public GameObject greenCheck;

    bool isUnlocked;
    public int fruitCounter;

    private int numOfFruit;

    private void Start()
    {
        isUnlocked = false;
        numOfFruit = GameObject.FindGameObjectsWithTag("fruit").Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isUnlocked && (fruitCounter == numOfFruit))
        {
            isUnlocked = true;
            GetComponent<SpriteRenderer>().color = Color.white;
            unlockSound.Play();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("player") && isUnlocked)
        {
            Debug.Log("Level beat");
            StartCoroutine(teleport());
        }
        
    }

    IEnumerator teleport()
    {
        portalSound.Play();
        GameObject player = GameObject.FindWithTag("player");

        for (int i = 0; i < 10; i++)
        {
            player.transform.position = Vector3.MoveTowards(player.transform.position, transform.position, 0.1f);
            player.transform.localScale = Vector3.MoveTowards(player.transform.localScale, Vector3.zero, 0.1f);
            yield return new WaitForSeconds(0.1f);
        }
        player.SetActive(false);
        Instantiate(greenCheck, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1f);
        GameObject.FindWithTag("Manager").GetComponent<LevelManager>().completeLevel(SceneManager.GetActiveScene().name);
    }
}
