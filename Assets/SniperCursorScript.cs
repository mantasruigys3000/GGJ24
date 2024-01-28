using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SniperCursorScript : MonoBehaviour
{
    public GameObject bench;
    public SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {       
        if (bench.activeSelf == false) 
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            mousePos.z = -3f;
            
            Color newColor = sr.color;
            newColor.a = 1;
            sr.color = newColor;
            transform.position = mousePos;
        }
        else
        {
            Color newColor = sr.color;
            newColor.a = 0;
            sr.color = newColor;
        }

    }
}
