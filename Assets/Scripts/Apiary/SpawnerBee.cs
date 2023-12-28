using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    [SerializeField]
    private float _spawnTime = 0.2f;

    private int _maxBeesWithHoney = 50;
    private int _currentBeesWithHoney = 0;
    private bool _isStartedMiniGame;
    //private List<BeeController> _bees = new List<BeeController>();
    private GameObject _beesBuffer;

    public Action StopMiniGame;
    public Action StartMiniGame;

    public void Start()
    {
        _beesBuffer = new GameObject("BeesBuffer");
        _beePrefab = Resources.Load<GameObject>("Prefabs/Apiary/Bee");
    } 

    public void OnMouseDown()
    {
        if(_isStartedMiniGame)
            return;
        _isStartedMiniGame = true;
        StartMiniGame.Invoke();
        StartCoroutine(SpawnBees());
    }

    public IEnumerator SpawnBees()
    {
        yield return new WaitForSeconds(_spawnTime);
        
        var position = _spawnPoints[Random.Range(0,_spawnPoints.Count)].transform.position;
        GameObject bee = Instantiate(_beePrefab, position, Quaternion.identity,_beesBuffer.transform);
        BeeController beeController = bee.GetComponent<BeeController>();
        beeController.targetFlowers = _flowers[Random.Range(0,_flowers.Count)].transform.position;
        beeController.spawnPoint = position;
        
        if (_currentBeesWithHoney >= _maxBeesWithHoney)
            ResetMiniGame();
        else
            StartCoroutine(SpawnBees());
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<BeeController>() && other.GetComponent<BeeController>().IsHaveHoney)
        {
            Destroy(other.gameObject, 0.3f);
            _currentBeesWithHoney++;
            Debug.Log(_currentBeesWithHoney);
        }
    }

    public void ResetMiniGame()
    {
        _beesBuffer.GetComponentsInChildren<BeeController>().ToList().
            ForEach(obj => obj.DestroyBee());
            //ForEach(obj => StartCoroutine(obj.TakingHoney()));
        
        _currentBeesWithHoney = 0;
        _isStartedMiniGame = false;
        StopMiniGame?.Invoke();
    }
}
