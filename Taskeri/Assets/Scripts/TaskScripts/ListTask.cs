using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ListTask : MonoBehaviour
{
    public GameObject task;

    public GameObject container;

    public GameObject taskForm;
    

    public Button addTaskButton;
    public Button addNewTask;
    public Button closeForm;
    public Button logOutButton;


    public TMP_Text taskTitle;
    public TMP_InputField title;
    public TMP_InputField description;


    // Start is called before the first frame update
    void Start()
    {
        addTaskButton.onClick.AddListener(OpenAddTask);
        addNewTask.onClick.AddListener(AddTask);
        closeForm.onClick.AddListener(CloseAddTask);
        logOutButton.onClick.AddListener(LogOut);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddTask()
    {
        Debug.Log("Pressed");
        taskTitle = task.GetComponentInChildren<TMP_Text>();
        taskTitle.text = title.text;
        (Instantiate(task, task.transform.position, task.transform.rotation) as GameObject).transform.parent = container.transform;

        //Instantiate(task, task.transform.position, task.transform.rotation);
        //task.transform.SetParent(container.transform);
    }

    public void OpenAddTask()
    {
        taskForm.SetActive(true);
    }

    public void CloseAddTask()
    {
        taskForm.SetActive(false);
    }

    public void LogOut()
    {
        SceneManager.LoadScene("MainMenu");
    }

    
}
