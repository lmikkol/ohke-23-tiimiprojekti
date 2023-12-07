using UnityEngine;
using UnityEngine.UI;

public class ImageOpacityToggle : MonoBehaviour
{
    public Image myImage; // Drag and drop your Image component here in the Inspector

    private void Start()
    {
        // Make sure myImage is assigned
        if (myImage == null)
        {
            Debug.LogError("Image component not assigned!");
            return;
        }

        // Set the initial state (visible or invisible)
        // Set the initial state (visible or invisible)
        SetImageVisibility(GlobalVariable.MasterVolume > 0f);
    }

    public void ToggleImageVisibility()
    {
        // Toggle the visibility when the button is pressed
        SetImageVisibility(!myImage.enabled);
    }

    private void SetImageVisibility(bool isVisible)
    {
        // Set the image alpha based on visibility
        Color imageColor = myImage.color;
        imageColor.a = isVisible ? 1f : 0f;
        myImage.color = imageColor;

        // Optionally, you can also toggle the Image component itself
        myImage.enabled = isVisible;
    }
}
