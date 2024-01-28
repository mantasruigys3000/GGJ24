using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beer : MonoBehaviour
{
    public GameObject beerDrinkReference;
    private SpriteRenderer beerDrinkSpr;
    private float drinkAlarm = 0;
    
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
        beerDrinkSpr = beerDrinkReference.GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if (drinkAlarm > 0)
        {
            drinkAlarm -= Time.deltaTime;
            if (drinkAlarm <= 0)
            {
                drinkAlarm = 0;
                spr.enabled = true;
                beerDrinkSpr.enabled = false;
            }
        }
    }

    private void OnMouseDown()
    {
        if (drinkAlarm > 0)
        {
            return;
        }
        
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

        beerDrinkSpr.enabled = true;
        spr.enabled = false;
        drinkAlarm = 1f;
        
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
