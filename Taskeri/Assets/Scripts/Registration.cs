using BCrypt.Net;
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
  UserData userData;
  private void Awake()
  {
    userData = GetComponent<UserData>();
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
    string passwordHash = HashingPassword(passwordField.text);
    Debug.Log("Hello " + nameField.text + " " + passwordHash + " " + passwordAgainField.text);
    errorMessenger.ShowNotification("User already exists.");
    // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);

  }

  public string HashingPassword(string password)
  {
    //Hashing the password
    string passwordHash = BCrypt.Net.BCrypt.HashPassword(password);
    return passwordHash;
  }

}
