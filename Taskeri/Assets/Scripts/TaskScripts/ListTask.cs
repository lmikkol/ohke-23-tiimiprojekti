using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    
    public Button descriptionButton;
    #endregion
 
    #region TMPs
    public TMP_Text taskDescription;

    public TMP_Text taskTitle;
    public TMP_InputField title;
    public TMP_InputField description;
    #endregion

    public GameObject descriptionForm;

    // Start is called before the first frame update
    void Start()
    {

        addTaskButton.onClick.AddListener(OpenAddTask);
        addNewTask.onClick.AddListener(AddTask);
        closeForm.onClick.AddListener(CloseAddTask);
        logOutButton.onClick.AddListener(LogOut);

        // descriptionButton.onClick.AddListener(DisplayDescription);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddTask()
    {
        Debug.Log("Pressed");
        //ETSI NÄMÄ NIMIKENTÄN MUKAAN STRINGEIKSI NIINKUIN REMOVE TASKISSA JA LISÄÄ DESCRIPTION KANSSA SAMALLA TAVALLA
        taskTitle = task.GetComponentInChildren<TMP_Text>();
        taskTitle.text = title.text;

        //HUOMISEN KOODIA
        //Tasks taskObject = new Tasks(stringi1, stringi2);

        GameObject addedTask = Instantiate(task, task.transform.position, task.transform.rotation) as GameObject;
        addedTask.transform.SetParent(container.transform, false); 

        //MUISTA LISÄÄ TÄMÄ Objekti myös remove taskille tai jotain jotain....
        //addedTask.taskiObjekti(taskObject);


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

    // public void DisplayDescription()
    // {
    //     GameObject newTask = Instantiate(descriptionForm, transform) as GameObject;
    //     GameObject taski = Instantiate(descriptionForm, descriptionForm.transform.position, descriptionForm.transform.rotation) as GameObject;
    //     taski.transform.parent = container.transform;
    //     // Debug.Log("Open Clicked!");
    //     Image taskTitlePh = newTask.transform.Find("TaskTitleForm").GetComponent<Image>();
    //     TMP_Text headLiner = taskTitlePh.transform.Find("TaskTitleTxt").GetComponent<TMP_Text>();
    //     //TMP_Text info = newTask.transform.Find("TaskDescriptionTxt").GetComponent<TMP_Text>();
    //     headLiner.text = title.text;
    //     //info.text = description.text;

    //     // taskDescription = task.GetComponentInChildren<TMP_Text>();
    //     // taskDescription.text = description.text;

    //     // GameObject newTask = (Instantiate(descriptionForm, transform) as GameObject).transform.parent = container.transform;
    // }

    // public Button showData;
    // public TMP_Text textField; // Add more fields as needed

    // public GameObject testi;

    // // Update is called once per frame
    // void Start()
    // {
    //     showData.onClick.AddListener(ShowInformation);
    // }

    // public void ShowInformation()
    // {
    //     GameObject newTask = Instantiate(testi, transform) as GameObject;
    //     TMP_Text teksti = newTask.transform.Find("title").GetComponent<TMP_Text>();
    //     TMP_Text des = newTask.transform.Find("des").GetComponent<TMP_Text>();
    //     teksti.text = "HELLOOOO";
    //     des.text = "BIAATCH";
    // }

}
