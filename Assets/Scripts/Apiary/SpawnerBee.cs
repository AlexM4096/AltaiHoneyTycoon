using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnerBee : MonoBehaviour
{
    [SerializeField]
    private GameObject _beePrefab;
    [SerializeField] 
    private List<GameObject> _flowers;
    [SerializeField]
    private List<GameObject> _spawnPoints;

    private int _maxBeesWithHoney = 50;
    private int _currentBeesWithHoney = 0;
    private bool _isStartedMiniGame;
    private BeeController _beeController;

    public void OnMouseDown()
    {
        if(_isStartedMiniGame)
            return;
        _isStartedMiniGame = true;
        StartCoroutine(SpawnBees());
    }

    public IEnumerator SpawnBees()
    {
        yield return new WaitForSeconds(0.2f);
        
        var position = _spawnPoints[Random.Range(0,_spawnPoints.Count)].transform.position;
        GameObject bee = Instantiate(_beePrefab, position, Quaternion.identity);
        BeeController beeController = bee.GetComponent<BeeController>();
        beeController.targetFlowers = _flowers[Random.Range(0,_flowers.Count)].transform.position;
        beeController.spawnPoint = position;
        
        if (_currentBeesWithHoney >= _maxBeesWithHoney)
            _currentBeesWithHoney = 0;
        else
            StartCoroutine(SpawnBees());
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<BeeController>() && other.GetComponent<BeeController>().IsHaveHoney)
        {
            Destroy(other.gameObject, 1f);
            _currentBeesWithHoney++;
            Debug.Log(_currentBeesWithHoney);
        }
    }
}
