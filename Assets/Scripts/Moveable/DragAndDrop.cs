using System;
using UnityEngine;

namespace Moveable
{
    [RequireComponent(typeof(Collider2D))]
    public class DragAndDrop : MonoBehaviour
    {
        private Camera _mainCamera;
        private Vector3 _delta;

        private void Awake()
        {
            _mainCamera = Camera.main;
        }

        private void OnMouseDown()
        {
            _delta = MousePosition() - transform.position;
        }

        private void OnMouseDrag()
        {
            transform.position = MousePosition() + _delta;
        }

        private Vector3 MousePosition()
        {
            Vector3 screenMousePosition = Input.mousePosition;
            Vector3 worldMousePosition = _mainCamera.ScreenToWorldPoint(screenMousePosition);
            return worldMousePosition;
        }
    }
}