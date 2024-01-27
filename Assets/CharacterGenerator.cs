using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGenerator : MonoBehaviour
{
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

    private Camera mainCam;
    
    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;
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

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            moveEyes(0.05f);
        }
        
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            moveEyes(-0.05f);
        }
        
        //LookAtPosition(mainCam.ScreenToWorldPoint(Input.mousePosition));
    }

    private int getNextIndex(List<Sprite> list, int index)
    {
        return index + 1 > (list.Count - 1) ? 0 : index + 1;
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

}
