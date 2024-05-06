using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TallyMarkBehavior : MonoBehaviour
{
    [Range(0,10)]
    public int count;

    [SerializeField]
    private Sprite[] spriteArray;

    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = spriteArray[count];
    }

    private void Update()
    {
        GetComponent<SpriteRenderer>().sprite = spriteArray[count];
        
        if(count == 0) GetComponent<SpriteRenderer>().color = Color.gray;
        else GetComponent<SpriteRenderer>().color = Color.white;
    }

    public void subtract()
    {
        if(count == 0) return;
        count--;
    }


}
