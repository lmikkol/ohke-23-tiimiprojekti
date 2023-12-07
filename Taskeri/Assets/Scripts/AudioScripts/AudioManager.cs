using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    [Header("References")]

    [Space(4)]
    [Header("Sources")]
    public AudioSource audioSource;

    void Start() {
        audioSource.Play();
    }
//        public void ToggleMute()
//    {
//        audioSource.mute = !audioSource.mute;
//    }


}
