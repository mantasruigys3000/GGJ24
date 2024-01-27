using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PukeLivesTracker : MonoBehaviour
{
    public SpriteRenderer PukeLives1;
    public SpriteRenderer PukeLives2;
    public SpriteRenderer PukeLives3;
   
    public int PukeLivesCount = 3;

    // Start is called before the first frame update
    void Start()
    {
        PukeLives1 = GetComponent<SpriteRenderer>();
        PukeLives2 = GetComponent<SpriteRenderer>();
        PukeLives3 = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PukeLivesCount == 3)
        {
            PukeLives3.enabled = false;
        }
    }
}
