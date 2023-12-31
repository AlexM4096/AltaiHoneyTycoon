using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class HornetController : MonoBehaviour
{
    [SerializeField] private float _minX;
    [SerializeField] private float _maxX; 
    [SerializeField] private float _minY;
    [SerializeField] private float _maxY;
    [SerializeField] private float _speed = 4;
    
    public Vector2 _targetPosition;
    private Vector3 _previousPosition;
    private Vector3 _spawnPoint;
    
    private float _lerpTime = 0f;
    private float _lerpDuration = 2f; // Время, за которое объект достигнет цели
    public Vector2 _startPosition;
    

    void Start()
    {
        _startPosition = transform.position;
        _targetPosition = GetRandomPosition();
        _spawnPoint = transform.position;
        _previousPosition = transform.position;
        _targetPosition = GetRandomPosition();
    }

    private void Update()
    {
        CheckMovement();
        MoveTowardsRandomPosition();
    }

    private void MoveTowardsRandomPosition()
    {
        if ((Vector2)transform.position != _targetPosition)
        {
            _lerpTime += Time.deltaTime;
            float t = _lerpTime / _lerpDuration;
            transform.position = Vector2.Lerp(_startPosition, _targetPosition, t);
        }
        else
        {
            _startPosition = transform.position;
            _targetPosition = GetRandomPosition();
            _lerpTime = 0f;
        }
    }

    private Vector2 GetRandomPosition()
    {
        float randomX = Random.Range(_minX, _maxX);
        float randomY = Random.Range(_minY, _maxY);
        return new Vector2(randomX, randomY);
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<BeeController>())
        {
            other.GetComponent<BeeController>().DestroyBee();
            SpawnBeeMiniGame.CountLiveBees--;
        }
    }

    private void CheckMovement()
    {
        Vector3 currentPosition = transform.position;

        if (currentPosition.x > _previousPosition.x)
            FlipScaleX(-1);
        else
            FlipScaleX(1);

        _previousPosition = currentPosition;
    }

    private void FlipScaleX(int scaleX)
    {
        Vector3 theScale = transform.localScale;
        theScale.x = scaleX;
        transform.localScale = theScale;
    }

    public void SetRandomTarget() => _targetPosition = GetRandomPosition();

    public void DestroyHornet()
    {
        GetComponent<Collider2D>().enabled = false;
        _targetPosition = _spawnPoint * 4;
        Destroy(gameObject, 4f);
    }

}
