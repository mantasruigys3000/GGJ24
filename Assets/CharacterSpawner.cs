using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
    public GameObject CharacterReference;
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = -4; i < 4; i++)
        {
            SpawnCharacter(new Vector3(i * 1,0,0));
        }
    }

    public void SpawnCharacter(Vector3 position)
    {
     
        GameObject person = Instantiate(CharacterReference, position, Quaternion.identity);
        CharacterGenerator generator = person.GetComponent<CharacterGenerator>();
        generator.randomize();
        
        // Scale
        person.transform.localScale /= 4;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
