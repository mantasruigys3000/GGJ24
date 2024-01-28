using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CharacterGenerator : MonoBehaviour
{
    public GameObject alienReference;
    public GameObject bodyReference;
    public Sprite blinkSprite;
    private Sprite tempEye;
    
    private const float MAX_BLINK = 0.2f;
    [SerializeField]
    private float blinkTimer = MAX_BLINK;
    
    private const int SKIN_WHITE = 1;
    private const int SKIN_BLACK = 0;
    private const int SKIN_ASIAN = 2;

    public SpriteRenderer head;
    public SpriteRenderer left_eye;
    public SpriteRenderer right_eye;
    public SpriteRenderer left_eyeball;
    public SpriteRenderer right_eyeball;
    public SpriteRenderer mouth;
    public SpriteRenderer hair_back;
    public SpriteRenderer hair_front;
    public SpriteRenderer body;
    public SpriteRenderer left_leg;
    public SpriteRenderer right_leg;
    public SpriteRenderer right_arm;
    public SpriteRenderer left_arm;

    private SpriteMask rightEyeMask;
    private SpriteMask leftEyeMask;
    
    private int bodyIndex = 0;
    [SerializeField] public List<Sprite> bodies;

    private int hairIndex = 0;
    [SerializeField] public List<Sprite> frontHairs;
    [SerializeField] public List<Sprite> backHairs;

    private int armIndex = 0;
    [SerializeField] public List<Sprite> arms;

    private int headIndex = 0;
    [SerializeField] public List<Sprite> heads;

    private int eyeIndex = 0;
    [SerializeField] public List<Sprite> eyes;

    private int mouthIndex = 0;
    [SerializeField] public List<Sprite> mouths;

    private int legIndex = 0;
    [SerializeField] public List<Sprite> legs;

    private int eyeBallIndex = 0;
    [SerializeField] public List<Sprite> eyeballs;

    [SerializeField] public List<Sprite> black_arms;
    [SerializeField] public List<Sprite> white_arms;
    [SerializeField] public List<Sprite> asian_arms;

    
    private Camera mainCam;

    private bool dead = false;

    private bool sleeping = false;
    public Sprite z1;
    public Sprite z2;
    private int currentZSprite = 0;
    private float sleepTimer = 0;
    public SpriteRenderer zSpr;

    public void sleep()
    {
        if (sleeping && dead)
        {
            sleepTimer += Time.deltaTime;
            if (sleepTimer > 2)
            {
                zSpr.sprite = switchSleepSprite();
                sleepTimer = 0;
            }
        }
    }

    private Sprite switchSleepSprite()
    {
        if (currentZSprite == 0)
        {
            currentZSprite = 1;
            return z1;
        }

        currentZSprite = 0;
        return z2;
    }

    // Start is called before the first frame update
    void Awake()
    {
        mainCam = Camera.main;
        setMasks();
        randomize();
    }

    private void setMasks()
    {
        rightEyeMask = right_eye.gameObject.GetComponent<SpriteMask>();
        leftEyeMask = left_eye.gameObject.GetComponent<SpriteMask>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.B))
        {
            blinkTimer = 0;
            blink();
        }

        if (blinkTimer < MAX_BLINK)
        {
            blinkTimer += Time.deltaTime;
            if (blinkTimer >= MAX_BLINK)
            {
                blinkTimer = MAX_BLINK;
                unBlink();
            }
        }
        
        //LookAtPosition(mainCam.ScreenToWorldPoint(Input.mousePosition));

        if (dead)
        {
            
        }
        
        sleep();
    }

    private void blink()
    {
        tempEye = left_eye.sprite;
        left_eye.sprite = blinkSprite;
        right_eye.sprite = blinkSprite;
        
        left_eyeball.gameObject.SetActive(false);
        right_eyeball.gameObject.SetActive(false);
    }

    private void unBlink()
    {
        right_eye.sprite = tempEye;
        left_eye.sprite = tempEye;
        
        left_eyeball.gameObject.SetActive(true);
        right_eyeball.gameObject.SetActive(true);
    }

    private int getNextIndex(List<Sprite> list, int index)
    {
        return index + 1 > (list.Count - 1) ? 0 : index + 1;
    }

    private int randomIndex(List<Sprite> list)
    {
        return Random.Range(0, list.Count);
    }

    private void moveEyes(float amount)
    {
        Vector3 lLocalPos = left_eyeball.transform.localPosition;
        Vector3 rLocalPos = right_eyeball.transform.localPosition;

        right_eyeball.transform.localPosition += new Vector3(amount, 0, 0);
        left_eyeball.transform.localPosition += new Vector3(amount, 0, 0);
    }

    private void LookAtPosition(Vector2 pos)
    {
        Vector2 leftEyePos = left_eye.transform.position;
        Vector2 rightEyePos = right_eye.transform.position;

        float distance = leftEyePos.x - pos.x;

        float newPos = Mathf.Clamp(pos.x, -0.4f, 0.4f);
        Vector3 localPos = left_eyeball.transform.localPosition;
        left_eyeball.transform.localPosition = new Vector3(newPos,localPos.y,localPos.z);

    }
    
    public void randomize(){

        if (rightEyeMask == null || leftEyeMask == null)
        {
            setMasks();
        }
        
        setHeadIndex(randomIndex(heads));
        setBodyIndex(randomIndex(bodies));
        setArmIndex(randomIndex(white_arms));
        setHairIndex(randomIndex(backHairs));
        setEyeIndex(randomIndex(eyes));
        setMouthIndex(randomIndex(mouths));
        setLegIndex(randomIndex(legs));
        setEyeBallIndex(randomIndex(eyeballs));
    }

    private void setHeadIndex(int index)
    {
        headIndex = index;
        head.sprite = heads[index];
    }

    private void setBodyIndex(int index)
    {
        body.sprite = bodies[index];
    }
    
    private void setArmIndex(int index)
    {
        switch (headIndex)
        {
            case SKIN_WHITE:
                left_arm.sprite = asian_arms[index];
                right_arm.sprite = asian_arms[index];
                break;
            case SKIN_BLACK:
                left_arm.sprite = black_arms[index];
                right_arm.sprite = black_arms[index];
                break;
            case SKIN_ASIAN:
                left_arm.sprite = white_arms[index];
                right_arm.sprite = white_arms[index];
                break;
        }
    }

    private void setHairIndex(int index)
    {
        hair_front.sprite = frontHairs[index];
        hair_back.sprite = backHairs[index];
    }

    private void setEyeIndex(int index)
    {
        left_eye.sprite = eyes[index];
        right_eye.sprite = eyes[index];
        
        rightEyeMask.sprite = right_eye.sprite;
        leftEyeMask.sprite = left_eye.sprite;
    }

    private void setMouthIndex(int index)
    {
        mouth.sprite = mouths[index];
    }

    private void setLegIndex(int index)
    {
        left_leg.sprite = legs[index];
        right_leg.sprite = legs[index];
    }

    private void setEyeBallIndex(int index)
    {
        left_eyeball.sprite = eyeballs[index];
        right_eyeball.sprite = eyeballs[index];
    }

    public void copyFrom(CharacterGenerator other)
    {
        head.sprite = other.head.sprite;
        left_eye.sprite = other.left_eye.sprite;
        right_eye.sprite = other.right_eye.sprite;
        right_eyeball.sprite = other.right_eyeball.sprite;
        left_eyeball.sprite = other.left_eyeball.sprite;
        mouth.sprite = other.mouth.sprite;
        hair_back.sprite = other.hair_back.sprite;
        hair_front.sprite = other.hair_front.sprite;
        body.sprite = other.body.sprite;
        left_leg.sprite = other.left_leg.sprite;
        right_leg.sprite = other.right_leg.sprite;
        right_arm.sprite = other.right_arm.sprite;
        left_arm.sprite = other.left_arm.sprite;
        leftEyeMask.sprite = other.leftEyeMask.sprite;
        rightEyeMask.sprite = other.rightEyeMask.sprite;
    }

    public void Die(bool isAlien = true)
    {
        dead = true;
        GetComponent<CapsuleCollider2D>().enabled = false;

        if (isAlien)
        {
            alienReference.SetActive(true);
            bodyReference.SetActive(false);
            // GetComponent<Animator>().enabled = false;
            GetComponent<CharacterPathing>().enabled = false;
            alienReference.GetComponent<Alien>().somethingElse();
        }
        else
        {
            GetComponent<Animator>().SetTrigger("dead");
            GetComponent<CharacterPathing>().enabled = false;
            
            tempEye = left_eye.sprite;
            left_eye.sprite = blinkSprite;
            right_eye.sprite = blinkSprite;
        
            left_eyeball.gameObject.SetActive(false);
            right_eyeball.gameObject.SetActive(false);
            sleeping = true;
            zSpr.gameObject.SetActive(true);
            zSpr.enabled = true;
        }

        //Destroy(gameObject);        
    }

    
}
