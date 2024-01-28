using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scope : MonoBehaviour
{


    private AudioSource sound;
    private Camera mainCam;

    private bool movingUp = true;
    private Vector3 upperPoint;
    private Vector3 lowerPoint;
    private float recoilSpeed = 10f;
    private float recoilDistance = 1.5f;
    
    private const float MAX_SHOOT_TIMER = 1.5f;
    private float shooterTimer = MAX_SHOOT_TIMER;

    private float breathTimer = 0;

    private const float DEFAULT_SWAY_SPEED = 1f;
    private const float DEFAULT_SWAY_ROTATION_DELTA = 0.2f;
    
    private Vector3 swayDir = Vector3.up;
    private float swaySpeed = DEFAULT_SWAY_SPEED;
    private float swayRotationDelta = DEFAULT_SWAY_ROTATION_DELTA;

    public int wrongHits = 0;

    private void OnEnable()
    {
        breathTimer = 0;
        swaySpeed = DEFAULT_SWAY_SPEED;
        swayRotationDelta = DEFAULT_SWAY_ROTATION_DELTA;
    }

    public AudioClip reloadClip;

    private void Awake()
    {
        sound = GetComponent<AudioSource>();
    }

    public bool canShoot()
    {
        return shooterTimer == MAX_SHOOT_TIMER;
    }

    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;
    }

    public float getMaxSwaySpeed()
    {
        switch (SniperSceneManager.instance.drunkState)
        {
            case 0: return 2f;
            case 1: return 4f;
            case 2: return 6f;
            case 3: return 8f;
            case 4: return 10f;
        }

        return 10f;
    }

    // Update is called once per frame
    void Update()
    {
        breathTimer += Time.deltaTime;
        swaySpeed = Mathf.Min(swaySpeed + breathTimer * 0.001f,getMaxSwaySpeed());
        swayRotationDelta = Mathf.Min(swayRotationDelta + breathTimer * 0.0005f,2f);
        // Simple mouse follow for now
        if (canShoot())
        {
            moveTowardsMouse();
            sway();
            
        }
        if (!canShoot())
        {
            recoilSpeed = Mathf.Max(8f,recoilSpeed - 0.02f);
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
                recoilSpeed = 10f;
                movingUp = true;
                sound.PlayOneShot(reloadClip);
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

                CharacterGenerator hitCharacter = hit.collider.gameObject.GetComponent<CharacterGenerator>();
                if (SniperSceneManager.instance.targetCharacter == hitCharacter )
                {
                    SniperSceneManager.spawnOne(true);
                    SniperSceneManager.addScore();
                    
                }
                else
                {
                    wrongHits++;

                    if (wrongHits >= 3)
                    {
                        Debug.Log("You lose");
                    }
                    
                    SniperSceneManager.spawnOne(false);
                }
                
                hitCharacter.Die();                

                
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

    private void sway()
    {
        transform.position += (swayDir * swaySpeed * Time.deltaTime);
        swayDir = rotate(swayDir, swayRotationDelta * Mathf.Deg2Rad);
    }
    
    public static Vector2 rotate(Vector2 v, float delta) {
        return new Vector2(
            v.x * Mathf.Cos(delta) - v.y * Mathf.Sin(delta),
            v.x * Mathf.Sin(delta) + v.y * Mathf.Cos(delta)
        );
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
