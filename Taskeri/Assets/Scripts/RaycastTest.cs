using UnityEngine;
using UnityEngine.EventSystems; // Add this line for EventSystem

public class RaycastTest : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse button click
        {
            // Check if the mouse is over a UI element using EventSystem
            if (EventSystem.current.IsPointerOverGameObject())
            {
                // Ray hit a UI element
                Debug.Log("Ray hit UI element");
            }
            else
            {
                // Ray didn't hit a UI element (empty space)
                Debug.Log("Ray not hit");
            }
        }
    }
}
