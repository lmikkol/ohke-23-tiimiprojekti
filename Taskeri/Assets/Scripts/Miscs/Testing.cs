using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class Testing : MonoBehaviour
{

    public TMP_Text displayText;
    string monthVar = System.DateTime.Now.ToString("dd:MM:yyyy");
    
    // Start is called before the first frame update
    void Start()
    {
        displayText.text = "Here is the time now : " + monthVar;
        
        Debug.Log(monthVar);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
