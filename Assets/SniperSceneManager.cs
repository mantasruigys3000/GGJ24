using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperSceneManager : MonoBehaviour
{
    public GameObject fogOfWar;
    
    // Start is called before the first frame update
    void Start()
    {
        if (fogOfWar)
        {
            fogOfWar.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
