using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorScript : MonoBehaviour
{
    public Texture2D cursorArrow;
    public Texture2D cursorArrowUpdate;

    private Camera _cam;

    public AudioSource source;
    
    public GameObject gunTable;
    
    // Start is called before the first frame update
    void Start()
    {
        gunTable = GameObject.Find("gunTable");
        
        Cursor.SetCursor(cursorArrow, Vector2.zero, CursorMode.ForceSoftware);
        _cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            source.Play(0);
            Cursor.SetCursor(cursorArrowUpdate, Vector2.zero, CursorMode.ForceSoftware);
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            Cursor.SetCursor(cursorArrow, Vector2.zero, CursorMode.ForceSoftware);
        }
    }
}
