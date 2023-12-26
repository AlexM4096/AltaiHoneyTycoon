using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragAndDrop : MonoBehaviour
{
    private bool isDragging = false;
    private Vector2 offset;

    private void OnMouseDown()
    {
        isDragging = true;
        offset = (Vector2)transform.position - GetMouseWorldPos();
    }

    private void OnMouseUp()
    {
        isDragging = false;
    }

    private void Update()
    {
        if (isDragging && GetComponent<Collider2D>().enabled)
        {
            Vector2 mousePos = GetMouseWorldPos();
            transform.position = new Vector3(mousePos.x + offset.x, mousePos.y + offset.y, transform.position.z);
        }
    }

    private Vector2 GetMouseWorldPos()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        return new Vector2(mousePos.x, mousePos.y);
    }
}
