using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Rotator : MonoBehaviour
{
    private enum RotationDirection : byte
    {
        Clockwise,
        Counterclockwise,
        Both
    }

    [SerializeField] private RotationDirection rotationDirection;

    public float Angel { get; private set; }
    public float DeltaAngel { get; private set; }
    
    private Camera _mainCamera;
    private float _mouseAngel;
    
    
    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    private void OnMouseDown()
    {
        _mouseAngel = MouseAngel();
    }
    
    private void OnMouseDrag()
    {
        CalculateDeltaAngel();
        CalculateAngle();
        HandleRotation();
    }

    private void HandleRotation()
    {
        switch (rotationDirection)
        {
            case RotationDirection.Clockwise:
                if (DeltaAngel < 0)
                    Rotate();
                break;
                
            case RotationDirection.Counterclockwise:
                if (DeltaAngel > 0)
                    Rotate();
                break;
            
            case RotationDirection.Both:
                Rotate();
                break;
        }
    }
    
    private void Rotate()
    {
        transform.Rotate(Vector3.forward, DeltaAngel);
    }

    private void CalculateDeltaAngel()
    {
        float newMouseAngel = MouseAngel();
        float deltaAngel = Mathf.DeltaAngle(_mouseAngel, newMouseAngel);
        _mouseAngel = newMouseAngel;

        DeltaAngel = deltaAngel;
    }

    private void CalculateAngle()
    {
        Angel += DeltaAngel;
    }

    private Vector3 MousePosition()
    {
        Vector3 screenMousePosition = Input.mousePosition;
        Vector3 worldMousePosition = _mainCamera.ScreenToWorldPoint(screenMousePosition);
        Vector3 localMousePosition = worldMousePosition - transform.position;
        return localMousePosition;
    }

    private float MouseAngel()
    {
        Vector3 mousePosition = MousePosition();
        float mouseAngel = Mathf.Atan2(mousePosition.y, mousePosition.x);
        return mouseAngel * Mathf.Rad2Deg;
    }
}
