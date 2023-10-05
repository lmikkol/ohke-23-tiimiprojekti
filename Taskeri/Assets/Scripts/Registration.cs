using BCrypt.Net;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Windows;
using System;
using System.Collections.Generic;
using System.Text;

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
  Regex passwordRegex = new Regex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{5,}$");
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
            PasswordRequires(passwordField.text);
            errorMessenger.ShowNotification("Password doesn't meet regulations. Missing the following: " + PasswordRequires(passwordField.text));
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
    Debug.Log(passwordRegex.IsMatch(password) +" match regex");
    return passwordRegex.IsMatch(password);
  }


   public string PasswordRequires(string password)
   {
      
       StringBuilder sb = new StringBuilder("");

       while (true)
       {
            if (!Regex.IsMatch(password, @"[a-z]"))
           {
               sb.Append("\r\n-Lowercase character");
           }
           if(!Regex.IsMatch(password, @"[A-Z]"))
           {
               sb.Append("\r\n-Uppercase letter.");
           }
           if(!Regex.IsMatch(password, @"\d"))
           {
              sb.Append("\r\n-Number.");
           }
           if(!Regex.IsMatch(password, @"[@#]"))
           {
              sb.Append("\r\n-Special character (@ or #).");
           }
            break;
       }
        return sb.ToString();
    }

}
