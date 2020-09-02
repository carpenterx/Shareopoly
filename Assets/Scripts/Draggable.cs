using UnityEngine;

public class Draggable : MonoBehaviour
{
    private bool isBeingDragged = false;
    private Vector3 previousMousePosition;

    private void OnMouseDown()
    {
        isBeingDragged = true;
        previousMousePosition = GetWorldMousePosition();
    }

    private void OnMouseUp()
    {
        isBeingDragged = false;
    }

    private void OnMouseDrag()
    {
        if (isBeingDragged)
        {
            Vector3 currentMousePosition = GetWorldMousePosition();
            transform.position += currentMousePosition - previousMousePosition;
            previousMousePosition = currentMousePosition;
        }
    }

    private Vector3 GetWorldMousePosition()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 9;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
        return worldPosition;
    }
}
