using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnBeeMiniGame : MonoBehaviour
{
    private GameObject _beePrefab;
    private GameObject _beesBuffer;
    private float _spawnTime = 0.2f;
    [SerializeField] 
    private List<GameObject> _spawnPoints;
    [SerializeField] 
    private List<GameObject> _flowers;
    private int _currentBeesWithHoney = 0;
    private int _beesInHive = 100;
    public void Start()
    {
        _beesBuffer = new GameObject("BeesBuffer");
        _beePrefab = Resources.Load<GameObject>("Prefabs/Apiary/Bee");
        StartCoroutine(SpawnBees());
    } 
    public IEnumerator SpawnBees()
    {
        yield return new WaitForSeconds(_spawnTime);

        if (_beesInHive > 0)
        {
            var position = _spawnPoints[Random.Range(0,_spawnPoints.Count)].transform.position;
            GameObject bee = Instantiate(_beePrefab, position, Quaternion.identity,_beesBuffer.transform);
            BeeController beeController = bee.GetComponent<BeeController>();
            beeController.targetFlowers = _flowers[Random.Range(0,_flowers.Count)].transform.position;
            beeController.spawnPoint = position;
            _beesInHive--;
        }
        StartCoroutine(SpawnBees());
        
    }
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<BeeController>() && other.GetComponent<BeeController>().IsHaveHoney)
        {
            StartCoroutine(TimerToDestroy(other, 0.3f));
        }
    }

    public IEnumerator TimerToDestroy(Collider2D other, float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(other.gameObject);
        _beesInHive++;
    }

}
