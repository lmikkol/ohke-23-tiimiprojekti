using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotDestroy : MonoBehaviour
{
    private void Awake()
    {
        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("GameMusic");
        if ( musicObj.Length > 1 )
        {
            Destroy(this.gameObject);
            Debug.Log ("Tuhoudu");
        }
        DontDestroyOnLoad(this.gameObject);
        Debug.Log ("älä tuhoudu");
    }
}