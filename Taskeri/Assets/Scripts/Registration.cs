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
    if(CheckMatchingPasswords(passwordField.text, passwordAgainField.text ))
    {
      errorMessenger.ShowNotification("SAMAT");
      string passwordHash = HashingPassword(passwordField.text);
      int id = userData.AddUser(nameField.text, passwordHash);
      if(id>0)
      {
        Debug.Log("Hello " + nameField.text + " " + passwordHash + " " + passwordAgainField.text);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
      }
      else
      {
        errorMessenger.ShowNotification("käyttis käytössä");
      }
       
       
      //  errorMessenger.ShowNotification("User already exists.");
    }
    else
    {
      errorMessenger.ShowNotification("Passwords do not match");
    }
    
    // 
  }

  public bool CheckMatchingPasswords(string password, string passwordAgain)
  {
    return password.Equals(passwordAgain);
  }

  public string HashingPassword(string password)
  {
    //Hashing the password
    string passwordHash = BCrypt.Net.BCrypt.HashPassword(password);
    return passwordHash;
  }

}
