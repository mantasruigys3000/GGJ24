using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PukeClickLeft : MonoBehaviour
{

    [SerializeField] ParticleSystem LeftParticle = null;
    [SerializeField] ParticleSystem LeftSplatParticle = null;
    public AudioSource LeftGag;
    

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "ClickCircle")
        {
            
            
            gameObject.tag = "Clickable";
        }
        if (col.gameObject.tag == "Border")
        {

            LeftSplatParticle.Play();
            Destroy(gameObject);
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
        if (gameObject.tag == "Clickable" && Input.GetMouseButtonDown(0))
        {
            LeftGag.Play();
            Destroy(gameObject);
            LeftParticle.Play();
           
        }
    }
}
