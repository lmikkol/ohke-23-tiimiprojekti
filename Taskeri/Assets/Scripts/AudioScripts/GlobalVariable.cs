using UnityEngine;

public static class GlobalVariable
{
    private static float masterVolume = 1f;

    public static float MasterVolume
    {
        get { return masterVolume; }
        set { masterVolume = Mathf.Clamp01(value); }
    }
}
