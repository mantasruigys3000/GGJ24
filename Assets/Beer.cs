using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beer : MonoBehaviour
{
    public int state = 0;
    private SpriteRenderer spr;
    
    [SerializeField] public List<Sprite> states;

    // Start is called before the first frame update
    void Start()
    {
        spr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Drink();
    }

    public void Drink()
    {
        if (state + 1 > states.Count - 1)
        {
            return;
        }
        
        state++;
        ChangeSprite();
    }

    private void ChangeSprite()
    {
        spr.sprite = states[state];
    }
}
