using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PukeLivesTracker : MonoBehaviour
{
    public Text LivesText;
    public Text PukeTimer;
    public int PukeLivesCount = 5;
    public int countdownValue = 30;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartCountdown());
    }

    IEnumerator StartCountdown()
    {
        

        while (countdownValue > 0)
        {
            
            yield return new WaitForSeconds(1f);
            countdownValue--;
        }
    }

    public void RemoveLife()
    {
        PukeLivesCount -= 1;
        if (PukeLivesCount <= 0)
        {
            PukeLivesCount = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        LivesText.text = "Lives: " + PukeLivesCount.ToString();
        PukeTimer.text = "Time: " + countdownValue.ToString();
    }
}
