using UnityEngine;

public class Rotator : MonoBehaviour
{
    private Camera _main;
    private float _baseAngle = 0;

    private void Awake()
    {
        _main = Camera.main;
    }

    private void OnMouseDown()
    {
        Vector3 position = _main.WorldToScreenPoint(transform.position);
        position = Input.mousePosition - position;
        _baseAngle = Mathf.Atan2(position.y, position.x) * Mathf.Rad2Deg;
        _baseAngle -= Mathf.Atan2(transform.right.y, transform.right.x) * Mathf.Rad2Deg;
    }

    private void OnMouseDrag()
    {
        Vector3 position = _main.WorldToScreenPoint(transform.position);
        position = Input.mousePosition - position;
        float angel = Mathf.Atan2(position.y, position.x) * Mathf.Rad2Deg - _baseAngle;
        transform.rotation = Quaternion.AngleAxis(angel, Vector3.forward);
    }
}
