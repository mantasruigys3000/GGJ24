using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverScore : MonoBehaviour
{

    public TextMeshProUGUI text;
    
    // Start is called before the first frame update
    void Start()
    {
        text.text = "Score: "+  SniperSceneManager.instance.score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
