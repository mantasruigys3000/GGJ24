using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PukeClickRight : MonoBehaviour
{

    [SerializeField] ParticleSystem RightParticle = null;
    [SerializeField] ParticleSystem RightSplatParticle = null;
    public PukeLivesTracker PukeLivesTrackerRef;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "ClickCircle")
        {

            
            gameObject.tag = "Clickable";
        }
        if (col.gameObject.tag == "Border")
        {

            RightSplatParticle.Play();
            Destroy(gameObject);
            PukeLivesTrackerRef.RemoveLife();
        }
    }

    

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "ClickCircle")
        {

            
            gameObject.tag = "PukeCircle";
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag == "Clickable" && Input.GetMouseButtonDown(1))
        {
            Destroy(gameObject);
            RightParticle.Play();
        }
       

    }
}
