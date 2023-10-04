using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class Registration : MonoBehaviour
{
#region InputFields
  public TMP_InputField nameField;
  public TMP_InputField passwordField;
  public TMP_InputField passwordAgainField;
#endregion
 
 #region Buttons
  public Button submitButton;
  public Button backButton;
  #endregion

  ErrorNotificator errorMessenger;
  private void Awake()
  {
    errorMessenger = GetComponent<ErrorNotificator>();
    submitButton.interactable = false;
  }

  public void Checking(string input)
  {
    if(string.IsNullOrWhiteSpace(nameField.text) || string.IsNullOrWhiteSpace(passwordField.text) || string.IsNullOrWhiteSpace(passwordAgainField.text))
    {
        submitButton.interactable = false;
    }
    else
    {
        submitButton.interactable = true;
    }
  }
  public void RegisterUser()
  {

    Debug.Log("Hello " + nameField.text + " " + passwordField.text + " " + passwordAgainField.text);
    errorMessenger.ShowNotification("Fuck you "+ nameField.text);
    // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);

  }

}
