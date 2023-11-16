using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class ListTask : MonoBehaviour
{

    #region GameObjects
    
    public GameObject task;

    public GameObject container;

    public GameObject taskForm;

    #endregion    
    
    #region Buttons
    public Button addTaskButton;
    public Button addNewTask;
    public Button closeForm;
    public Button logOutButton;
    
    #endregion
 
    #region TMPs
    public TMP_Text taskDescription;
    public TMP_Text taskTitle;

   
    public TMP_InputField title;
    public TMP_InputField description;
    MainManager loggedInUser;

    #endregion
    TaskDao taskdao;
    // Start is called before the first frame update

    void Awake()
    {
        loggedInUser = MainManager.Instance;
        taskdao = GetComponent<TaskDao>();

        List<List<string>> test = taskdao.SelectAllTaskByUserId(loggedInUser.id);
        AddTaskToTheView(test);


        //loggedInUser = GetComponent<MainManager>();
    }
    void Start()
    {


        addTaskButton.onClick.AddListener(OpenAddTask);
        addNewTask.onClick.AddListener(AddTask);
        closeForm.onClick.AddListener(CloseAddTask);
        logOutButton.onClick.AddListener(LogOut);

    }



    public void AddTask()
    {


        taskdao.AddTask(title.text, description.text, "12.3.2022", loggedInUser.id);

        List<List<string>> test = taskdao.SelectAllTaskByUserId(loggedInUser.id);
        AddTaskToTheView(test);
    }

    public void AddTaskToTheView(List<List<string>> testi)
    {

        DestroyContainerChild();
        Debug.Log(testi.Count + " LISTAN PITUUS ");
        for (int i = 0; i < testi.Count; i++)
        {
            GameObject addedTask = Instantiate(task, task.transform.position, task.transform.rotation) as GameObject;
            addedTask.transform.SetParent(container.transform, false);

            TMP_Text taskTitlePlaceHold = addedTask.transform.Find("TaskTitle").GetComponent<TMP_Text>();

            Task newTask = Task.Instance;

            Task.Instance.taskTitle = testi[i][0];
            Task.Instance.taskDescription = testi[i][1];

            taskTitlePlaceHold.text = newTask.taskTitle;

            //KATSO MYÖHEMMIN
            RemoveTask code = addedTask.transform.GetComponent<RemoveTask>();

            code.SetTaskObject(newTask);
        }
    }

    public void DestroyContainerChild()

    {
        for (int i = container.transform.childCount - 1; i >= 0; i--)
        {


            Object.Destroy(container.transform.GetChild(i).gameObject);


        }
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