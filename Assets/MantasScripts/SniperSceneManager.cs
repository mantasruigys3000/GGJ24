using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SniperSceneManager : MonoBehaviour
{

    public static SniperSceneManager instance;

    public CharacterGenerator target;
    public CharacterSpawner Spawner;
    public GameObject fogOfWar;

    private bool showTable = true;
    public GameObject scope;
    public GameObject table;
    
    public GameObject spawnPositions;
    private List<LineRenderer> lines;

    public LineRenderer testPath;
    public Scope scopeComp;

    private AudioSource sound;
    [SerializeField] public List<AudioClip> zoomInSounds;
    [SerializeField] public List<AudioClip> zoomOutSounds;
    
    CharacterGenerator targetCharacter;


    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
            return;
        }

        instance = this;
        sound = GetComponent<AudioSource>();

    }

    // Start is called before the first frame update
    void Start()
    {
        lines = new List<LineRenderer>();
        
        if (fogOfWar)
        {
            fogOfWar.SetActive(true);
        }
        
        setTableValues();

        foreach (LineRenderer child in spawnPositions.transform.GetComponentsInChildren<LineRenderer>())
        {
            lines.Add(child);
        }

        foreach (LineRenderer lr in lines)
        {
            Path _path = new Path(lr, true);
            spawnCharAndSetPath(_path);
            lr.gameObject.SetActive(false);

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
        setTableValues(true);
    }

    private void setTableValues(bool playSound = false)
    {
        if (showTable)
        {
            scope.SetActive(false);
            table.SetActive(true);

            if (playSound)
            {
                //unzoom
                sound.PlayOneShot(Helper.ChooseFromList(zoomOutSounds));

            }
            
            return;
        }
        scope.SetActive(true);
        table.SetActive(false);
        if (playSound)
        {
            sound.PlayOneShot(Helper.ChooseFromList(zoomInSounds));
        }
    }

    public static Path getRandomPath()
    {
        return new Path(Helper.ChooseFromList(instance.lines));
    }

    private void spawnCharAndSetPath(Path _path)
    {
        CharacterPathing pather = Spawner.SpawnCharacter(_path.getCurrentNode()).GetComponent<CharacterPathing>();
        //pather.setMoveTo(Helper.ChooseFromList(spawnList)); 
            
        pather.setMoveTo(_path);
        targetCharacter = pather.gameObject.GetComponent<CharacterGenerator>();
        
        if (targetCharacter)
        {
            target.copyFrom(targetCharacter);
        }
    }
    
    public static void  spawnOne()
    {
        instance.spawnCharAndSetPath(new Path(Helper.ChooseFromList(instance.lines)));
    }
}
