using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPathing : MonoBehaviour
{
    private bool shouldMove = false;
    private Vector3 moveTo = Vector3.zero;
    private const float spd = 1f;

    private Path ?currentPath = null;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldMove)
        {
            Vector3 tempPosition = Vector3.MoveTowards(transform.position, moveTo, spd * Time.deltaTime);
            transform.position = new Vector3(tempPosition.x, tempPosition.y, transform.position.z);
            if (Vector2.Distance(transform.position, moveTo) < 0.5f)
            {
                if (currentPath.isAtEnd())
                {
                    currentPath = SniperSceneManager.getRandomPath();
                    moveTo = currentPath.getCurrentNode();
                    transform.position = currentPath.getCurrentNode();
                    
                }
                else
                {
                    moveTo = currentPath.nextNode();
                }
                
                //shouldMove = false;
            }
        }
    }

    public void setMoveTo(Path _path)
    {
        shouldMove = true;
        currentPath = _path;
        moveTo = currentPath.getCurrentNode();
    }
}

public class Path
{
    private List<Vector3> positions;
    private int currentIndex;

    public Path(LineRenderer lr,bool reverse = false)
    {
        List<Vector3> _positions = new List<Vector3>();
        for (int i = 0; i < lr.positionCount; i++)
        {
            _positions.Add(lr.GetPosition(i));
        }

        if (reverse)
        {
            _positions.Reverse();
        }
        
        this.positions = _positions;
        currentIndex = 0;
    }

    public Vector3 getCurrentNode()
    {
        return positions[currentIndex];
    }

    public Vector3 nextNode()
    {
        Debug.Log("Get next node");
        
        if (currentIndex + 1 > positions.Count - 1)
        {
            return getCurrentNode();
        }

        currentIndex++;
        return getCurrentNode();
    }

    public bool isAtEnd()
    {
        return currentIndex == positions.Count - 1;
    }
}
