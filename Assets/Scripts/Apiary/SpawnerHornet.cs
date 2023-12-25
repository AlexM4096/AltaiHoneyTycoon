using System;
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
    private List<HornetController> _hornets = new List<HornetController>();

    void Start()
    {
        _hornetPrefab = Resources.Load<GameObject>("Prefabs/Apiary/Hornet");
    }
    public void StartSpawnHornet() => StartCoroutine(SpawnHornet());
    
    public IEnumerator SpawnHornet()
    {
        yield return new WaitForSeconds(_spawnTime);
        GameObject hornet = Instantiate(_hornetPrefab, _spaawnPoint, Quaternion.identity);
        _hornets.Add(hornet.GetComponent<HornetController>());
        
        _currentHornetCount++;
        if (_currentHornetCount < _maxHornetCount)
            StartCoroutine(SpawnHornet());
    }

    public void DestroyHornets()
    {
        _hornets.ForEach(obj => obj.DestroyHornet());
        _hornets.Clear();
    }
    
}
