using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class RemoveTask : MonoBehaviour
{

    public Button removeTaskButton; //
    public Button moreInfoButton; //
    
    public TMP_Text title;
    
    public GameObject moreInfoContainer; //
    public GameObject descriptionForm; //
    GameObject newTask;
    public Task task; //
    public ListTask taskview;
    public Image donePanel;
    public Toggle toggle;
    Image descPanel;


    // Start is called before the first frame update
    void Start()
    {
       
        taskview = GameObject.FindObjectOfType<ListTask>();
        moreInfoContainer = GameObject.Find("TestPosition");

        moreInfoButton.onClick.AddListener(DisplayDescription);
        removeTaskButton.onClick.AddListener(RemoveTaskOnClick);

        toggle.onValueChanged.AddListener(delegate { ToggleValue(); });
    }


    // Set Task- data to an object
    public void SetTaskObject(Task task)
    {
        this.task = task;
        donePanel.gameObject.SetActive(Convert.ToBoolean(task.taskDone));
    }

    public void ToggleValue()
    {
        taskview.UpdateTaskStatus(Convert.ToInt32(toggle.isOn), task.taskId);
        Debug.Log("Toggle values is : " + toggle.isOn);
    }

    // Remove this task from the list
    public void RemoveTaskOnClick()
    {

        Debug.Log(task.taskId + " TÄMÄ POISTETTIIN");
        DestroyChild(true);
       // Destroy(gameObject);
        taskview.RemoveTask(task.taskId);
    }

    // Display more-info panel in screen
    public void DisplayDescription()
    {

        DestroyChild(false);

        newTask = Instantiate(descriptionForm, moreInfoContainer.transform) as GameObject;

        Image taskTitlePh = newTask.transform.Find("TaskTitleForm").GetComponent<Image>();
        Image taskDesc = newTask.transform.Find("DescriptionTxtForm").GetComponent<Image>();

        TMP_Text taskDescription = taskDesc.transform.Find("TaskDescriptionTxt").GetComponent<TMP_Text>();
        TMP_Text headLiner = taskTitlePh.transform.Find("TaskTitleTxt").GetComponent<TMP_Text>();

        

        headLiner.text = task.taskTitle;
        taskDescription.text = task.taskDescription;

    }

    //public void changeTaskPanelStatus(bool status)
    //{
    //    Image taskTitlePh = newTask.transform.Find("TaskTitleForm").GetComponent<Image>();
    //    Image taskDesc = newTask.transform.Find("DescriptionTxtForm").GetComponent<Image>();

    //    TMP_Text taskDescription = taskDesc.transform.Find("TaskDescriptionTxt").GetComponent<TMP_Text>();

    //    if(taskDescription.text == task.taskDescription)
    //    descPanel.gameObject.SetActive(status);

    //}

    // Destroy more-info panel from displaycontainer
    public void DestroyChild(bool isClicked)

    {
        for (int i = moreInfoContainer.transform.childCount - 1; i >= 0; i--)
        {
            if(isClicked)
            {
                Destroy(newTask);
            }
            else
            {
                Destroy(moreInfoContainer.transform.GetChild(i).gameObject);
            }
           
        }
    }
}
