using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scope : MonoBehaviour
{


    private AudioSource sound;
    private Camera mainCam;

    private bool movingUp = true;
    private Vector3 upperPoint;
    private Vector3 lowerPoint;
    private float recoilSpeed = 2f;
    private float recoilDistance = 5f;
    
    private const float MAX_SHOOT_TIMER = 5f;
    private float shooterTimer = MAX_SHOOT_TIMER;

    private void Awake()
    {
        sound = GetComponent<AudioSource>();
    }

    private bool canShoot()
    {
        return shooterTimer == MAX_SHOOT_TIMER;
    }

    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        // Simple mouse follow for now
        if (canShoot())
        {
            moveTowardsMouse();
            
        }
        if (!canShoot())
        {
            recoilSpeed = Mathf.Max(0,recoilSpeed - 0.02f);
            if (movingUp)
            {
                transform.position += Vector3.up * recoilSpeed * Time.deltaTime;
                if (transform.position.y > upperPoint.y)
                {
                    movingUp = false;
                }
            }
            else
            {
                transform.position -= Vector3.up * recoilSpeed * Time.deltaTime;
                if (transform.position.y < lowerPoint.y)
                {
                    movingUp = true;
                }
            }
        }
        

        if (shooterTimer < MAX_SHOOT_TIMER)
        {
            shooterTimer += Time.deltaTime;

            if (shooterTimer >= MAX_SHOOT_TIMER)
            {
                shooterTimer = MAX_SHOOT_TIMER;
                recoilSpeed = 2f;
            }
        }

        if (Input.GetMouseButtonDown(0) && canShoot())
        {
            shooterTimer = 0;
            
            Debug.Log("Clicked");

            upperPoint = transform.position + (Vector3.up * recoilDistance);
            lowerPoint = transform.position - (Vector3.up * recoilDistance);
            
            // Raycast the shot
            //RaycastHit hit = new RaycastHit();
            
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.zero);
            sound.Play();
            if (hit.collider != null)
            {
                Debug.Log("Hit" + hit.collider.gameObject.name);
                Destroy(hit.collider.gameObject);
            }
        }
        
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
