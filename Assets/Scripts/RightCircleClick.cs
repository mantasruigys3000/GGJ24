using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightCircleClick : MonoBehaviour
{
    public Sprite M2Red;
    public Sprite M2Black;
    SpriteRenderer RightClickSprite;
    [SerializeField] bool canRightClick = false;
    public PukeLivesTracker PukeLivesTrackerRef;
    public GameObject WrongTimingRight;
    private void OnTriggerEnter2D(Collider2D col)
    {
        canRightClick = true;
        

    }

    private void OnTriggerExit2D(Collider2D col)
    {
        canRightClick = false;
        
    }

    void Start()
    {
        RightClickSprite = GetComponent<SpriteRenderer>();
    }

    IEnumerator RightWarning()
    {
        WrongTimingRight.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        WrongTimingRight.SetActive(false);
    }

    IEnumerator ShowRightClick()
    {
        RightClickSprite.sprite = M2Red;
        yield return new WaitForSeconds(0.2f);
        RightClickSprite.sprite = M2Black;
    }

    // Update is called once per frame
    void Update()
    {
        if (!canRightClick & Input.GetMouseButtonDown(1))
        {
            StartCoroutine(RightWarning());
            PukeLivesTrackerRef.RemoveLife();

        }
        if (Input.GetMouseButtonDown(1))
        {
            StartCoroutine(ShowRightClick());
        }
    }
}
