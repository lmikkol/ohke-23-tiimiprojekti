using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UserProfile : MonoBehaviour
{
    public GameObject welcomeText;
    private TextMeshProUGUI msg;
    string userNameText;
    public Button logOutbutton;
   
    MainManager manager;

    //possible info to show

    //string passWord;
    //int rank;
    //etc..


    // Start is called before the first frame update
    void Start()
    {
        manager = MainManager.Instance;
        msg = welcomeText.GetComponent<TextMeshProUGUI>();
        logOutbutton.onClick.AddListener(LogOut);

        if (manager != null)
        {
            userNameText = manager.savedUserName;
            msg.text = "Welcome, " + userNameText + "!";
        }
        else
        {
            Debug.LogError("MainManager instance is not available.");
        }

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void LogOut()
    {
        SceneManager.LoadScene("MainMenu");
    }

    
}
