using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PukeScoreTracker : MonoBehaviour
{
    SpriteRenderer PukeLivesSprite;
    public Sprite[] PukeHeartSheet;
    public int PukeLives = 3;

    // Start is called before the first frame update
    void Start()
    {
        PukeLivesSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
