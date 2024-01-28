using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beer : MonoBehaviour
{
    public int state = 0;
    private SpriteRenderer spr;
    private AudioSource sound;

    private string hoverHex = "FBC970";
    
    [SerializeField] public List<Sprite> states;

    // Start is called before the first frame update
    void Start()
    {
        spr = GetComponent<SpriteRenderer>();
        sound = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Drink();
    }

    private void OnMouseOver()
    {
        spr.color = new Color32(0xFF, 0xDC, 0x8c,0xFF);
    }

    private void OnMouseExit()
    {
        spr.color = Color.white;
    }

    public void Drink()
    {
        if (state + 1 > states.Count - 1)
        {
            return;
        }
        
        state++;
        ChangeSprite();
        SniperSceneManager.setDrunkState(state);
        sound.Play();
    }

    private void ChangeSprite()
    {
        spr.sprite = states[state];
    }
}
