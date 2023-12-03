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

    //string dateTimeValue = DateTime.Now.ToString("dd:MM:yyyy");


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
        DestroyChild(true, task.taskId);
       // Destroy(gameObject);
        taskview.RemoveTask(task.taskId);
    }

    // Display more-info panel in screen
    public void DisplayDescription()
    {

        DestroyChild(false, -1);

        newTask = Instantiate(descriptionForm, moreInfoContainer.transform) as GameObject;

        Image taskTitlePh = newTask.transform.Find("TaskTitleForm").GetComponent<Image>();
        Image taskDesc = newTask.transform.Find("DescriptionTxtForm").GetComponent<Image>();

        TMP_Text taskDescription = taskDesc.transform.Find("TaskDescriptionTxt").GetComponent<TMP_Text>();

        TMP_Text invisibleId = taskDesc.transform.Find("InvisibleTaskId").GetComponent<TMP_Text>();

        TMP_Text headLiner = taskTitlePh.transform.Find("TaskTitleTxt").GetComponent<TMP_Text>();

        TMP_Text taskDate = newTask.transform.Find("Date").GetComponent<TMP_Text>();


        //taskDate.text = dateTimeValue.ToString();

        DateTime placehodlerDate = DateTime.Parse(task.dateTime);
        string parsedDate = placehodlerDate.ToString("dd:MM:yyyy");
        invisibleId.text = task.taskId.ToString();
        headLiner.text = task.taskTitle;
        taskDescription.text = task.taskDescription;
        taskDate.text = "Date: " + parsedDate;

    }

 

    // Destroy more-info panel from displaycontainer
    //It destroy all visible when open new task description
    public void DestroyChild(bool isClicked, int removableTaskId)

    {
        for (int i = moreInfoContainer.transform.childCount - 1; i >= 0; i--)
        {
            if(isClicked)
            {
              
                Image poistettavaTaski = moreInfoContainer.transform.GetChild(i).Find("DescriptionTxtForm").GetComponent<Image>();
                TMP_Text poistettavanIdTaskissa = poistettavaTaski.transform.Find("InvisibleTaskId").GetComponent<TMP_Text>();
              
                if(removableTaskId.ToString() == poistettavanIdTaskissa.text)
                {
                    Destroy(moreInfoContainer.transform.GetChild(i).gameObject);
                }
            }
            else
            {
                Destroy(moreInfoContainer.transform.GetChild(i).gameObject);
     
            }
           
        }
    }
}
