using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class HornetController : MonoBehaviour
{
    [SerializeField] 
    private float _minX;
    [SerializeField]
    private float _maxX;
    [SerializeField] 
    private float _minY;
    [SerializeField]
    private float _maxY;

    private Vector2 _targetPosition;
    private float _speed = 5;


    private void Start()
    {
        _targetPosition = GetRandomPosition();
    }

    private void Update()
    {
        if ((Vector2)transform.position != _targetPosition)
            transform.position = Vector2.MoveTowards(
                transform.position,
                _targetPosition, 
                _speed * Time.deltaTime);
        else
            _targetPosition = GetRandomPosition();
    }

    public Vector2 GetRandomPosition()
    {
        float randomX = Random.Range(_minX, _maxX);
        float randomY = Random.Range(_minY, _maxY);
        return new Vector2(randomX, randomY);
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<BeeController>())
        {
            Destroy(other.gameObject);
        }
    }
    
}
