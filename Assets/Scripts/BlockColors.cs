using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class BlockColors : MonoBehaviour
{
    private Color color;
    // Start is called before the first frame update
    void Awake()
    {
        if (!GetComponent<SpriteRenderer>().color.Equals(Color.gray)) return;


        char sceneColor = SceneManager.GetActiveScene().name.ToCharArray()[0];
        switch (sceneColor)
        {
            case 'B':
                GetComponent<SpriteRenderer>().color = new Color(Random.Range(70, 110) / 255f, Random.Range(80, 110) / 255f, Random.Range(110, 140) / 255f);
                GameObject.FindWithTag("MainCamera").GetComponent<Camera>().backgroundColor = new Color(21 / 255f, 52 / 255f, 92 / 255f);
                break;
            case 'G':
                GetComponent<SpriteRenderer>().color = new Color(Random.Range(90, 130) / 255f, Random.Range(120, 135) / 255f, Random.Range(80, 100) / 255f);
                GameObject.FindWithTag("MainCamera").GetComponent<Camera>().backgroundColor = new Color(36 / 255f, 49 / 255f, 27 / 255f);
                break;
            default:
                GetComponent<SpriteRenderer>().color = new Color(Random.Range(70, 120) / 255f, Random.Range(70, 90) / 255f, Random.Range(100, 130) / 255f);
                GameObject.FindWithTag("MainCamera").GetComponent<Camera>().backgroundColor = new Color(34/255f, 35/255f, 40/255f);
                break;
        }
    }

}
