using UnityEngine;

public class TaskPanelResize : MonoBehaviour
{
    private bool isResizing = false;
    private Vector3 initialMousePos;
    private Vector2 initialPanelSize;

    private RectTransform resizeHandleRectTransform;
    private RectTransform panelRectTransform;



    void Start()
    {
        // Get the RectTransform of the resizing handle.
        resizeHandleRectTransform = GetComponent<RectTransform>();

        // Get the RectTransform of the parent task panel.
        panelRectTransform = transform.parent.GetComponent<RectTransform>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && IsMouseOverHandle())
        {
            StartResizing();
        }

        if (isResizing && Input.GetMouseButton(0))
        {
            ResizePanel();
        }

        if (Input.GetMouseButtonUp(0))
        {
            StopResizing();
        }
    }

    private bool IsMouseOverHandle()
    {
        RectTransform handleRectTransform = GetComponent<RectTransform>(); // Get the RectTransform of the resizing handle.
        Vector2 mousePos = Input.mousePosition; // Get the mouse position in screen space.

        // Check if the mouse position is within the bounds of the handle's RectTransform.
        return RectTransformUtility.RectangleContainsScreenPoint(handleRectTransform, mousePos);
    }


    private void StartResizing()
    {
        isResizing = true;
        initialMousePos = Input.mousePosition;
        initialPanelSize = transform.parent.GetComponent<RectTransform>().sizeDelta;
    }

    private void ResizePanel()
    {
        Vector3 offset = Input.mousePosition - initialMousePos;
        Vector2 newSize = initialPanelSize + new Vector2(offset.x, -offset.y);

        // Clamp the new size to ensure it doesn't become too small or negative.
        newSize.x = Mathf.Max(newSize.x, 0f);
        newSize.y = Mathf.Max(newSize.y, 0f);

        // Set the size of the parent task panel.
        panelRectTransform.sizeDelta = newSize;

        // Set the position of the resizing handle to the lower-right corner of the panel.
        Vector3 handlePosition = new Vector3(panelRectTransform.sizeDelta.x, -panelRectTransform.sizeDelta.y, 0f);
        resizeHandleRectTransform.localPosition = handlePosition;
    }

    private void StopResizing()
    {
        isResizing = false;
    }
}
