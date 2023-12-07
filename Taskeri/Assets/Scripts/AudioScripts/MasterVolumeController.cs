using UnityEngine;

public class MasterVolumeController : MonoBehaviour
{
    private AudioListener audioListener;

    private void Awake()
    {
        audioListener = Camera.main.GetComponent<AudioListener>();

        // Set the master volume based on the global variable
        SetMasterVolume(GlobalVariable.MasterVolume);
    }

    public void ToggleMasterVolume()
    {
        GlobalVariable.MasterVolume = GlobalVariable.MasterVolume == 0f ? 1f : 0f;
        SetMasterVolume(GlobalVariable.MasterVolume);
    }

    private void SetMasterVolume(float volume)
    {
        if (audioListener != null)
        {
            AudioListener.volume = volume;
        }
    }
}
