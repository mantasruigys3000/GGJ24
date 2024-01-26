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

        Vector3 mousepos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        transform.position = new Vector3(
            mousepos.x,
            mousepos.y,
            0
        );
    }
}
