using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ErrorNotificator : MonoBehaviour
{
    public TMP_Text errorMsg;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowNotification(string msg)
    {
        errorMsg.text = msg;
        StartCoroutine(CountDown());
    }

    public IEnumerator CountDown()
    {
       errorMsg.gameObject.SetActive(true);
       yield return new WaitForSeconds (5);
       errorMsg.gameObject.SetActive(false);
    }
}
