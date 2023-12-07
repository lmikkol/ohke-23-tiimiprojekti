using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AddTaskPanel : MonoBehaviour
{

    public GameObject taskPanel;
    public Button AddButton;
    //bool active = true;

    // Start is called before the first frame update
    void Start()
    {
        taskPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonClick()
    {
        taskPanel.SetActive(true);

        //if(taskPanel == true)
        //{
        //    taskPanel.SetActive(false);
        //}
    }

    public void ClosePanel()
    {
        taskPanel.SetActive(false);
    }

    public void SaveValues()
    {

    }

}
