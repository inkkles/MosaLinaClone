using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField]
    public GameObject deathIcon;
    public AudioSource deathSound;

    private bool dead = false;

    // Update is called once per frame
    void Update()
    {
        if (
           transform.position.x > 16 || transform.position.x < -12 ||
           transform.position.y > 6 || transform.position.y < -7)
        {
            StartCoroutine(Die());
        }

        if (Input.GetKeyDown(KeyCode.R)){
            StartCoroutine(Die());
        }
    }

    IEnumerator Die()
    {
        if (dead) yield break;

        dead = true;
        deathSound.Play();

        //hide player
        GetComponent<Rigidbody2D>().Sleep();
        GetComponent<SpriteRenderer>().enabled = false;
        foreach(SpriteRenderer childSprite in GetComponentsInChildren<SpriteRenderer>())
        {
            childSprite.enabled = false;
        }

        //spawn red X
        GameObject X = Instantiate(deathIcon, transform.position, Quaternion.identity);
        if (
           transform.position.x > 16 || transform.position.x < -12 ||
           transform.position.y > 6 || transform.position.y < -7)
        {
            X.transform.position = Vector3.MoveTowards(transform.position, Vector3.zero, 3);
        }

        //pause
        yield return new WaitForSeconds(0.5f);
        //respawn player
        if (GetComponent<ItemManager>().tutorial)
        {
            SceneManager.LoadScene("tutorial", LoadSceneMode.Single);
        }
        else GameObject.FindWithTag("Manager").GetComponent<LevelManager>().changeLevel();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("spike"))
        {
            Die();
        }
    }

}
