using BCrypt.Net;
using System.Text.RegularExpressions;
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
        // UNCOMMENT LATER!!!!
        if (CheckMatchingPasswords(passwordField.text, passwordAgainField.text) && PasswordRegularExpression(passwordField.text))
        {
            string passwordHash = HashingPassword(passwordField.text);
            int id = userData.AddUser(nameField.text, passwordHash);
            if (id > 0)
            {
                Debug.Log("Hello " + nameField.text + " " + passwordHash + " " + passwordAgainField.text);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            }
            else
            {
                errorMessenger.ShowNotification("User already exists.");
                // errorMessenger.ShowNotification("käyttis käytössä");
            }
        }
        if (!CheckMatchingPasswords(passwordField.text, passwordAgainField.text))
        {
            errorMessenger.ShowNotification("Passwords don't match!");
        }
        if (!PasswordRegularExpression(passwordField.text))
        {
            errorMessenger.ShowNotification("Password doesn't meet regulations.");
        }

    }

  public bool CheckMatchingPasswords(string password, string passwordAgain)
  {
    Debug.Log(password.Equals(passwordAgain) + " match");
    return password.Equals(passwordAgain);
  }

  public string HashingPassword(string password)
  {
    //Hashing the password
    string passwordHash = BCrypt.Net.BCrypt.HashPassword(password);
    return passwordHash;
  }

  public bool PasswordRegularExpression(string password)
  {
    Regex passwordRegex = new Regex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{5,}$");
        Debug.Log(passwordRegex.IsMatch(password) +" match regex");

    return passwordRegex.IsMatch(password);
  }

}
