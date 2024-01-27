using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scope : MonoBehaviour
{
    private Camera mainCam;
    
    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        // Simple mouse follow for now
        moveTowardsMouse();
        
    }

    private void moveTowardsMouse()
    {
        float spd = 0.08f;
        Vector3 mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        if (Vector3.Distance(transform.position, mousePos) > 0.9f)
        {
            Vector3 direction = (  mousePos - transform.position).normalized;
            transform.position += new Vector3(direction.x * spd,direction.y * spd,0) ;   
        }
    }

    private void setToMouse()
    {
        Vector3 mousepos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        transform.position = new Vector3(
            mousepos.x,
            mousepos.y,
            0
        );
    }
}
