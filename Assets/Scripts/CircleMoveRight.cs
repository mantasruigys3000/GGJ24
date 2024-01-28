using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMoveRight : MonoBehaviour
{
    public GameObject PukePrefab;
    //public float pukepushForce = 2f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnNotesRight());
    }

    // Update is called once per frame
    void Update()
    {
        

    }
   

    IEnumerator SpawnNotesRight()
    {
        while (true)
        {
            float SpawnTime = Random.Range(1.0f, 1.5f);

            float PukePushForce = Random.Range(8.0f, 16.0f);

            Vector3 PukeSpawnPos = new Vector3(1.58f, 4.7f, 0.0f);

            GameObject PukeCircle = Instantiate(PukePrefab, PukeSpawnPos, Quaternion.identity);

            Rigidbody2D pukeRB = PukeCircle.GetComponent<Rigidbody2D>();

            pukeRB.AddForce(Vector2.down * PukePushForce, ForceMode2D.Impulse);

            

            

            yield return new WaitForSeconds(SpawnTime);
        }
    }
}
