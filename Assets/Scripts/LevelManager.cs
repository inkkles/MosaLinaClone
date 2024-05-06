using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class IListExtensions
{
    /// <summary>
    /// Shuffles the element order of the specified list.
    /// </summary>
    public static void Shuffle<T>(this IList<T> ts)
    {
        var count = ts.Count;
        var last = count - 1;
        for (var i = 0; i < last; ++i)
        {
            var r = UnityEngine.Random.Range(i, count);
            var tmp = ts[i];
            ts[i] = ts[r];
            ts[r] = tmp;
        }
    }
}
public class LevelManager : MonoBehaviour
{
    //list of level names storied in the hierarchy of the tutorial level
    [SerializeField]
    public List<string> levelList = new List<string>();
    private void Awake()
    {
        //makes this item persistant throughout scenes
        DontDestroyOnLoad(this.gameObject);

        //shuffles a list of levels once the tutorial loads to be used for the rest of the game
        levelList.Shuffle(); 
    }

    public void changeLevel()
    {
        changeLevel(levelList[Random.Range(0, levelList.Count)]);
    }

    public void changeLevel(string level)
    {
        completeLevel(level);
        SceneManager.LoadScene(level, LoadSceneMode.Single);
    }
    public void completeLevel(string completed_level)
    {
        levelList.Remove(completed_level);
        changeLevel();
    }
}
