using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBee : MonoBehaviour
{
    [SerializeField]
    private GameObject _beePrefab;
    [SerializeField]
    private GameObject Flower;
    
    private int _maxBeesWithHoney = 5;
    private int _currentBeesWithHoney = 0;
    private bool _isStartedMiniGame;
    
    public void OnMouseDown()
    {
        if(_isStartedMiniGame)
            return;
        _isStartedMiniGame = true;
        StartCoroutine(SpawnBees());
    }

    public IEnumerator SpawnBees()
    {
        yield return new WaitForSeconds(3);
        GameObject bee =  Instantiate(_beePrefab, transform.position, Quaternion.identity);
        bee.GetComponent<BeeController>().targetFlowers = Flower.transform.position;
        bee.GetComponent<BeeController>().spawnPoint = transform.position;

        if (_currentBeesWithHoney != _maxBeesWithHoney)
            StartCoroutine(SpawnBees());
    }
   
}
