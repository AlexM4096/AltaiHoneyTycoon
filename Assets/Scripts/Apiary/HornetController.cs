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
    
    private Vector2 _targetPosition;
    private Vector3 _previousPosition;
    private Vector3 _spawnPoint;

    void Start()
    {
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
            Debug.Log(_targetPosition); 
            transform.position = Vector2.MoveTowards(
                transform.position,
                _targetPosition, 
                _speed * Time.deltaTime);
        }
        else
            _targetPosition = GetRandomPosition();
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
            other.GetComponent<BeeController>().DestroyBee();
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
