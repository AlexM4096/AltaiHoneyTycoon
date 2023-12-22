using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerHornet : MonoBehaviour
{
    [SerializeField] private int _maxHornetCount = 3;
    [SerializeField] private Vector3  _spaawnPoint = new Vector3(10, 9, 0);
    [SerializeField] private float _spawnTime = 1f;
    private int _currentHornetCount = 0;
    
    private GameObject _hornetPrefab;
    
    void Start()
    {
        _hornetPrefab = Resources.Load<GameObject>("Prefabs/Apiary/Hornet");
    }
    
    public void StartSpawnHornet() => StartCoroutine(SpawnHornet());
    
    public IEnumerator SpawnHornet()
    {
        yield return new WaitForSeconds(_spawnTime);
        GameObject hornet = Instantiate(_hornetPrefab, _spaawnPoint, Quaternion.identity);
        
        _currentHornetCount++;
        if (_currentHornetCount < _maxHornetCount)
            StartCoroutine(SpawnHornet());
    }
    
}
