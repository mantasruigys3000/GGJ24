using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGenerator : MonoBehaviour
{
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
        if (Input.GetKeyDown(KeyCode.Return))
        {
            bodyIndex = bodyIndex + 1 > (bodies.Count - 1) ? 0 : bodyIndex + 1;
            body.sprite = bodies[bodyIndex];
        }

        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            hairIndex = hairIndex + 1 > (frontHairs.Count - 1) ? 0 : hairIndex + 1;
            hair_front.sprite = frontHairs[hairIndex];
            hair_back.sprite = backHairs[hairIndex];
        }
        
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            armIndex = getNextIndex(arms, armIndex);
            left_arm.sprite = arms[armIndex];
            right_arm.sprite = arms[armIndex];
        }

        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            headIndex = getNextIndex(heads, headIndex);
            head.sprite = heads[headIndex];
        }
        
        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            eyeIndex = getNextIndex(eyes, eyeIndex);
            left_eye.sprite = eyes[eyeIndex];
            right_eye.sprite = eyes[eyeIndex];

            rightEyeMask.sprite = right_eye.sprite;
            leftEyeMask.sprite = left_eye.sprite;
        }
        
        if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            mouthIndex = getNextIndex(mouths, mouthIndex);
            mouth.sprite = mouths[mouthIndex];
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            moveEyes(0.05f);
        }
        
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            moveEyes(-0.05f);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            randomize();
        }

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

}
