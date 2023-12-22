using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApiaryLVLManager : MonoBehaviour
{
    private SpawnerBee _have;
    
    private void Awake()
    {
        _have = FindObjectOfType<SpawnerBee>();
    }
    public void  StartMiniGame()
    {
        _have.GetComponent<SpawnerHornet>().StartSpawnHornet();
        Debug.Log("Start");
    }

    public void EndMiniGame()
    {
        Debug.Log("End");
    }
    private void OnEnable()
    {
        _have.StopMiniGame += EndMiniGame;
        _have.StartMiniGame += StartMiniGame;
    }
    private void OnDisable()
    {
        _have.StopMiniGame -= EndMiniGame;
        _have.StartMiniGame -= StartMiniGame;
    }

}
