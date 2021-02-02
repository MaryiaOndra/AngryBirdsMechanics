using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BirdController : MonoBehaviour
{
    [SerializeField] GameObject birdPrefab;
    Bird bird;

    public event Action CreateNewBird;

    void Start()
    {
        ShootBird();
    }

    void Update()
    {
        if (bird.IsBirdDragEnd) 
        {            
            ShootBird();        
        }
    }

    void PrepareBird() 
    {
          GameObject _activeBird = Instantiate(birdPrefab, gameObject.transform);
          bird = _activeBird.GetComponent<Bird>();
    }

    void ShootBird() 
    {

    }
}
