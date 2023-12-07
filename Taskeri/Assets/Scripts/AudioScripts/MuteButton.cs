using UnityEngine;

public class MuteButton : MonoBehaviour
{
    private AudioManager audioManager;

    void Start()
    {
        // Find the AudioManager in the scene
        audioManager = FindObjectOfType<AudioManager>();

        if (audioManager == null)
        {
            Debug.LogError("AudioManager not found in the scene!");
        }
    }

    // This method is called when the mute button is clicked
    public void OnMuteButtonClick()
    {
        if (audioManager != null)
        {
            audioManager.ToggleMute();
        }
    }
}
