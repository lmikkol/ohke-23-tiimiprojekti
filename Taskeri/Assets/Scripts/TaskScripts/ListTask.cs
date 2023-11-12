using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ListTask : MonoBehaviour
{
    public GameObject task;

    public GameObject container;

    public Button addTaskButton;

    public TMP_Text taskTitle;

    public Button addNewTask;
    public Button closeForm;

    public GameObject taskForm;
    public TMP_InputField title;
    public TMP_InputField description;



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

    // Start is called before the first frame update
    void Start()
    {
        addTaskButton.onClick.AddListener(OpenAddTask);
        addNewTask.onClick.AddListener(AddTask);
        closeForm.onClick.AddListener(CloseAddTask);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
