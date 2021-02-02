using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject[] levelPrefabs;
    int levelIndx = 0;

    void Start()
    {
        CreateLevel();
    }


    void Update()
    {
        
    }

    void CreateLevel() 
    {
        Instantiate(levelPrefabs[levelIndx], gameObject.transform);
        levelIndx++;
        if (levelIndx == 3)
            levelIndx = 0;
    }
}
