using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ErrorNotificator : MonoBehaviour
{
    public TMP_Text errorMsg;
    public GameObject errorMessageBox;


    public void ShowNotification(string msg, int time)
    {
        errorMsg.text = msg;
        StartCoroutine(CountDown(time));
    }

    public IEnumerator CountDown(int time)
    {
        errorMsg.gameObject.SetActive(true);
        errorMessageBox.gameObject.SetActive(true);
        yield return new WaitForSeconds(time);
        errorMsg.gameObject.SetActive(false);
        errorMessageBox.gameObject.SetActive(false);
    }
}
