using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ErrorNotificator : MonoBehaviour
{
    public TMP_Text errorMsg;
    public GameObject errorMessageBox;


    public void ShowNotification(string msg)
    {
        errorMsg.text = msg;
        StartCoroutine(CountDown());
    }

    public IEnumerator CountDown()
    {
        errorMsg.gameObject.SetActive(true);
        errorMessageBox.gameObject.SetActive(true);
        yield return new WaitForSeconds(5);
        errorMsg.gameObject.SetActive(false);
        errorMessageBox.gameObject.SetActive(false);
    }
}
