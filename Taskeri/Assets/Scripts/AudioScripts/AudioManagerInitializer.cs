using UnityEngine;

public class AudioManagerInitializer : MonoBehaviour
{
    public GameObject audioSourcePrefab;
    public GameObject muteButtonPrefab;

    void Start()
    {
        // Instantiate Audio Source
        GameObject audioSourceGO = Instantiate(audioSourcePrefab, Vector3.zero, Quaternion.identity);
        // You can do further setup if needed

        // Instantiate Mute Button
        GameObject muteButtonGO = Instantiate(muteButtonPrefab, Vector3.zero, Quaternion.identity);
        // You can do further setup if needed
    }
}
