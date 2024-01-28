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
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
    public GameObject heart4;
    public GameObject heart5;
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
        LivesText.text = "Lives:";
        PukeTimer.text = "Timer: " + countdownValue.ToString();

        if (PukeLivesCount <= 4)
        {
            heart5.SetActive(false);
        }
        if (PukeLivesCount <= 3)
        {
            heart4.SetActive(false);
        }
        if (PukeLivesCount <= 2)
        {
            heart3.SetActive(false);
        }
        if (PukeLivesCount <= 1)
        {
            heart2.SetActive(false);
        }
        if (PukeLivesCount <= 0)
        {
            heart1.SetActive(false);
        }
    }
}
