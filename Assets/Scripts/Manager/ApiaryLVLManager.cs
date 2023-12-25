using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApiaryLVLManager : MonoBehaviour
{
    private SpawnerBee _have;
    private void Awake() =>_have = FindObjectOfType<SpawnerBee>();
    public void  StartMiniGame()
    {
        _have.GetComponent<SpawnerHornet>().StartSpawnHornet();
    }

    public void EndMiniGame()
    {
        _have.GetComponent<SpawnerHornet>().DestroyHornets();
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
