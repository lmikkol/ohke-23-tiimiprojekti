using UnityEngine;

public class TaskPanelDrag : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 initialMousePos;
    private Vector3 initialPanelPos;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && IsMouseOverPanel())
        {
            // Left mouse button down and cursor over the panel.
            StartDragging();
        }

        if (isDragging && Input.GetMouseButton(0))
        {
            // Continue dragging.
            DragPanel();
        }

        if (Input.GetMouseButtonUp(0))
        {
            // Left mouse button released.
            StopDragging();
        }
    }

    private bool IsMouseOverPanel()
    {
        RectTransform panelRectTransform = GetComponent<RectTransform>(); // Get the RectTransform of the panel.
        Vector2 mousePos = Input.mousePosition; // Get the mouse position in screen space.

        // Check if the mouse position is within the bounds of the panel's RectTransform.
        return RectTransformUtility.RectangleContainsScreenPoint(panelRectTransform, mousePos);
    }


    private void StartDragging()
    {
        isDragging = true;
        initialMousePos = Input.mousePosition;
        initialPanelPos = transform.position;
    }

    private void DragPanel()
    {
        Vector3 offset = Input.mousePosition - initialMousePos;
        transform.position = initialPanelPos + offset;
    }

    private void StopDragging()
    {
        isDragging = false;
    }
}
