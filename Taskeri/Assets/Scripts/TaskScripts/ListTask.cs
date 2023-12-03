using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;
using System;


public class ListTask : MonoBehaviour
{

    #region GameObjects
    
    public GameObject task;

    public GameObject container;

    public GameObject taskForm;

    public GameObject donePanel;
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
    public GameObject taskCreatedPanel;
    public TMP_Text taskCreated;
    public TMP_Text taskDate;

    public TMP_InputField titleInput;
    public TMP_InputField descInput;
    ErrorNotificator errorMessenger;

    // Start is called before the first frame update

    void Awake()
    {
        //loggedInUser = GetComponent<MainManager>();
    }
    void Start()
    {

        loggedInUser = MainManager.Instance;
        taskdao = GetComponent<TaskDao>();
        errorMessenger = GetComponent<ErrorNotificator>();

        List<List<string>> test = taskdao.SelectAllTaskByUserId(loggedInUser.id);
        AddTaskToTheView(test);
        addTaskButton.onClick.AddListener(OpenAddTask);
        addNewTask.onClick.AddListener(AddTask);
        closeForm.onClick.AddListener(CloseAddTask);
        logOutButton.onClick.AddListener(LogOut);

    }

    public void RemoveTask(int taskId)
    {

        taskdao.RemoveFromDatabase(taskId);
        List<List<string>> test = taskdao.SelectAllTaskByUserId(loggedInUser.id);
        AddTaskToTheView(test);
    }


    public void UpdateTaskStatus(int done, int taskId)
    {

        taskdao.UpdateTaskDoneStatus(done, taskId);
        List<List<string>> test = taskdao.SelectAllTaskByUserId(loggedInUser.id);
        AddTaskToTheView(test);
    }

    public void AddTask()
    {

        if (string.IsNullOrWhiteSpace(titleInput.text) || string.IsNullOrWhiteSpace(descInput.text))
        {
            errorMessenger.errorMsg.color = Color.red;
            errorMessenger.ShowNotification("You need to add title and description to add a new task!", 5);
        }
        else
        {
            taskdao.AddTask(title.text, description.text, loggedInUser.id);

            List<List<string>> test = taskdao.SelectAllTaskByUserId(loggedInUser.id);
            StartCoroutine(ShowTaskMessage());
            AddTaskToTheView(test);
            title.text = "";
            description.text = "";
        }

        
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
            Toggle doneToggle = addedTask.transform.Find("Toggle").GetComponent<Toggle>();
            GameObject donePanel = addedTask.transform.Find("MaskPanel").GetComponent<GameObject>();
            //TMP_Text createdDate = addedTask.transform.Find("Date").GetComponent<TMP_Text>();
            Task newTask = Task.Instance;

            Task.Instance.taskId = Convert.ToInt32(testi[i][0]);
            Task.Instance.taskTitle = testi[i][1];
            Task.Instance.taskDescription = testi[i][2];
            Task.Instance.taskDone = Convert.ToInt32(testi[i][3]);
            Task.Instance.dateTime = testi[i][4];

            taskTitlePlaceHold.text = newTask.taskTitle;
            doneToggle.isOn = Convert.ToBoolean(Convert.ToInt32(testi[i][3]));
           // donePanel.SetActive(Convert.ToBoolean(Convert.ToInt32(testi[i][3])));
            //KATSO MYÖHEMMIN
            RemoveTask code = addedTask.transform.GetComponent<RemoveTask>();

            code.SetTaskObject(newTask);
            
        }
    }

    public void DestroyContainerChild()

    {
        for (int i = container.transform.childCount - 1; i >= 0; i--)
        {


            Destroy(container.transform.GetChild(i).gameObject);


        }
    }

    public IEnumerator ShowTaskMessage()
    {
        taskCreatedPanel.SetActive(true);
        taskCreated.color = Color.green;
        taskCreated.text = "Congratulations! \n New task \n was created succesfully!";
        yield return new WaitForSeconds(3);
        taskCreatedPanel.SetActive(false);
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