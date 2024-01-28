using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class AmbienceScript : MonoBehaviour
{
    public AudioSource scopeFx;
    public AudioSource benchFx;

    public GameObject bench;

    // Start is called before the first frame update
    void Start()
    {
        benchFx.Play(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (bench.activeSelf == false) 
        {
            benchFx.Pause();
            if (scopeFx.isPlaying == false)
            {
                scopeFx.Play();
            }

            else
            {
                scopeFx.UnPause();
            }
            
        }
        else
        {
            scopeFx.Pause();
            benchFx.UnPause();
        }
    }
}
