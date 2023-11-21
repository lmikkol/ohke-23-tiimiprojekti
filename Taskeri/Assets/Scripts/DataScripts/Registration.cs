using System.Text.RegularExpressions;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Text;

public class Registration : MonoBehaviour
{
    #region InputFields
    public TMP_InputField nameField;
    public TMP_InputField loginNameField;

    public TMP_InputField loginPasswordField;
    public TMP_InputField passwordField;
    public TMP_InputField passwordAgainField;
    #endregion

    #region Buttons
    public Button submitButton;
    public Button backButton;
    #endregion

    public GameObject Errortext;
    private User loggedUser;
    ErrorNotificator errorMessenger;
    UserData userData;
    Regex passwordRegex = new Regex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{5,}$");

    private void Awake()
    {
        userData = GetComponent<UserData>();
        errorMessenger = GetComponent<ErrorNotificator>();
    }

    public void Checking(string input)
    {
        if (string.IsNullOrWhiteSpace(nameField.text) || string.IsNullOrWhiteSpace(passwordField.text) || string.IsNullOrWhiteSpace(passwordAgainField.text))
        {
            submitButton.interactable = false;
        }
        else
        {
            submitButton.interactable = true;
        }
    }

    public void CheckingLogin(string input)
    {
        if (string.IsNullOrWhiteSpace(loginNameField.text) || string.IsNullOrWhiteSpace(loginPasswordField.text))
        {
            submitButton.interactable = false;
        }
        else
        {
            submitButton.interactable = true;
        }
    }

    public void GoBackToPrevious()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public IEnumerator WaitForNextScene()
    {
        Errortext.SetActive(false);
        yield return new WaitForSeconds(5);
        GoBackToPrevious();
        Errortext.SetActive(true);
    }
    


    public void RegisterUser()
    {

        if (CheckMatchingPasswords(passwordField.text, passwordAgainField.text) && PasswordRegularExpression(passwordField.text))
        {
            string username = nameField.text;
            string passwordHash = HashingPassword(passwordField.text);
            string password = passwordField.text;
            User user = userData.LoginData(username);

            //!!!!!PURKKA koodissa joka tullaan korjaamaan!!!!!!
            Debug.Log(user.username.Length);
            if (user.username.Length == 0)
            {
                userData.AddUser(nameField.text, passwordHash);
                errorMessenger.errorMsg.color = Color.green;
                errorMessenger.ShowNotification("Congratulations, you've succesfully created an account!");
                Debug.Log("Hello " + nameField.text + " " + passwordHash + " " + passwordAgainField.text);
                StartCoroutine(WaitForNextScene());
                // MainManager.Instance.savedUserName = user.username;
                //SceneManager.LoadScene("MainPage");
            }
            else
            {
                errorMessenger.ShowNotification("User already exists, please try different username.");
            }
        }
        if (!CheckMatchingPasswords(passwordField.text, passwordAgainField.text))
        {
            errorMessenger.ShowNotification("Passwords do not match!");
        }
        if (!PasswordRegularExpression(passwordField.text))
        {
            PasswordRequires(passwordField.text);
            errorMessenger.ShowNotification("Password doesn't meet regulations. Missing the following: " + PasswordRequires(passwordField.text));
        }

    }
   
    public void LoginUser()
    {

        string user = loginNameField.text;
        string password = loginPasswordField.text;

        Debug.Log(loginNameField.text + " " + loginPasswordField.text);

        loggedUser = userData.LoginData(user);
        Debug.Log(loggedUser.id);
        if(loggedUser.id != 0)
        {
            Debug.Log("LöyTYi");
            if (DeCryptPassword(password, loggedUser.password))
            {
            //PlayerManager pManager;
            //pManager = gameObject.GetComponent<PlayerManager>();
            //pManager.setUser(loggedUser);
            MainManager.Instance.savedUserName = loggedUser.username;
            MainManager.Instance.id = loggedUser.id;
            SceneManager.LoadScene("MainPage");
            }
            else
            {
                errorMessenger.ShowNotification("Password or username not matching ");
            }

        }
        else
        {
            errorMessenger.ShowNotification("Password or username not matching ");
        }


    }

    public bool DeCryptPassword(string opassword, string dpassword)
    {
        return BCrypt.Net.BCrypt.Verify(opassword, dpassword);
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
        Debug.Log(passwordRegex.IsMatch(password) + " match regex");
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
            if (!Regex.IsMatch(password, @"[A-Z]"))
            {
                sb.Append("\r\n-Uppercase letter.");
            }
            if (!Regex.IsMatch(password, @"\d"))
            {
                sb.Append("\r\n-Number.");
            }
            if (!Regex.IsMatch(password, @"[@#!]"))
            {
                sb.Append("\r\n-Special character (@ or # or !).");
            }
            break;
        }
        return sb.ToString();
    }

}