using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftCircleClick : MonoBehaviour
{
    public Sprite M1Red;
    public Sprite M1Black;
    SpriteRenderer LeftClickSprite;
    [SerializeField] bool canLeftClick = false;
    public PukeLivesTracker PukeLivesTrackerRef;
    private void OnTriggerEnter2D(Collider2D col)
    {
        canLeftClick = true;
        

    }

    private void OnTriggerExit2D(Collider2D col)
    {
        canLeftClick = false;
        
    }

    void Start()
    {
        LeftClickSprite = GetComponent<SpriteRenderer>();
    }

    IEnumerator ShowLeftClick()
    {
        LeftClickSprite.sprite = M1Red;
        yield return new WaitForSeconds(0.2f);
        LeftClickSprite.sprite = M1Black;
    }

    // Update is called once per frame
    void Update()
    {
        if (!canLeftClick & Input.GetMouseButtonDown(0))
        {

            PukeLivesTrackerRef.RemoveLife();
            
        }
        
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(ShowLeftClick());
        }
    }
}
