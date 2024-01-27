using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightCircleClick : MonoBehaviour
{
    public Sprite M2Red;
    public Sprite M2Black;
    SpriteRenderer RightClickSprite;
    [SerializeField] bool canRightClick = false;
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
            Debug.Log("FUCKED IT");
        }
        if (Input.GetMouseButtonDown(1))
        {
            StartCoroutine(ShowRightClick());
        }
    }
}
