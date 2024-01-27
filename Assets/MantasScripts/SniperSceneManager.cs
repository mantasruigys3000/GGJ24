using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperSceneManager : MonoBehaviour
{
    public CharacterGenerator target;
    public CharacterSpawner Spawner;
    public GameObject fogOfWar;

    private bool showTable = true;
    public GameObject scope;
    public GameObject table;
    
    public GameObject spawnPositions;
    private List<Path> pathList;

    public LineRenderer testPath;
    
    // Start is called before the first frame update
    void Start()
    {
        pathList = new List<Path>();
        if (fogOfWar)
        {
            fogOfWar.SetActive(true);
        }
        
        setTableValues();

        foreach (LineRenderer child in spawnPositions.transform.GetComponentsInChildren<LineRenderer>())
        {
            pathList.Add(new Path(child));
        }

        CharacterGenerator targetCharacter = null;
        foreach (Path path in pathList)
        {
            CharacterPathing pather = Spawner.SpawnCharacter(path.getCurrentNode()).GetComponent<CharacterPathing>();
            //pather.setMoveTo(Helper.ChooseFromList(spawnList)); 
            
            pather.setMoveTo(new Path(testPath));
            targetCharacter = pather.gameObject.GetComponent<CharacterGenerator>();
        }

        if (targetCharacter)
        {
            target.copyFrom(targetCharacter);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            toggleTable();
        }
    }

    private void toggleTable()
    {
        showTable = !showTable;
        setTableValues();
    }

    private void setTableValues()
    {
        if (showTable)
        {
            scope.SetActive(false);
            table.SetActive(true);
            return;
        }
        scope.SetActive(true);
        table.SetActive(false);
        
    }
}
