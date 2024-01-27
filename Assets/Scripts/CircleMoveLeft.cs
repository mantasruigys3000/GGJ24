using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMoveLeft : MonoBehaviour
{
    public GameObject PukePrefab;
    //public float pukepushForce = 2f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnNotesLeft());
    }

    // Update is called once per frame
    void Update()
    {
        

    }
   

    IEnumerator SpawnNotesLeft()
    {
        while (true)
        {
            float SpawnTime = Random.Range(1.0f, 1.5f);

            float PukePushForce = Random.Range(12.0f, 16.0f);

            Vector3 PukeSpawnPos = new Vector3(-1.5f, 4.7f, 0.0f);

            GameObject PukeCircle = Instantiate(PukePrefab, PukeSpawnPos, Quaternion.identity);

            Rigidbody2D pukeRB = PukeCircle.GetComponent<Rigidbody2D>();

            pukeRB.AddForce(Vector2.down * PukePushForce, ForceMode2D.Impulse);

            

           

            yield return new WaitForSeconds(SpawnTime);
        }
    }
}
