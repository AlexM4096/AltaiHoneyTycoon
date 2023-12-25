using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeController : MonoBehaviour
{
    public bool IsHaveHoney;
    
    [SerializeField] private float _speed = 5f;
    public Vector3 targetFlowers;
    public Vector3 spawnPoint;

    void Update()
    { 
        MoveToTarget();
    }
    
    void MoveToTarget() {
        Vector3 targetPosition = GetTargetPosition();
        float step = _speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

        if (transform.position == targetPosition) {
            StartCoroutine(TakingHoney());
        }
    }

    Vector3 GetTargetPosition() {
        return IsHaveHoney ? spawnPoint : targetFlowers;
    }
    
    public IEnumerator TakingHoney()
    {
        yield return new WaitForSeconds(1);
        IsHaveHoney = true;
        gameObject.GetComponent<SpriteRenderer>().flipX = IsHaveHoney;
    }

    public void DestroyBee()
    {
        GetComponent<SpriteRenderer>().flipY = true;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        Destroy(gameObject, 3f);
        _speed = 0;
    }
    
}
