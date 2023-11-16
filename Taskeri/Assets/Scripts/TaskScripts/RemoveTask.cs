using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RemoveTask : MonoBehaviour
{

    public Button removeTaskButton; //
    public Button moreInfoButton; //
    
    public TMP_Text title;
    
    public GameObject moreInfoContainer; //
    public GameObject descriptionForm; //
    GameObject newTask;
    public Task task; //
     

    // Start is called before the first frame update
    void Start()
    {
        moreInfoContainer = GameObject.Find("TestPosition");

        moreInfoButton.onClick.AddListener(DisplayDescription);
        removeTaskButton.onClick.AddListener(RemoveTaskOnClick);
    }


    // Set Task- data to an object
    public void SetTaskObject(Task task)
    {
        this.task = task;
    }


    // Remove this task from the list
    public void RemoveTaskOnClick()
    {
        DestroyChild(true);
        Destroy(gameObject);
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

    // Destroy more-info panel from displaycontainer
    public void DestroyChild(bool isClicked)

    {
        for (int i = moreInfoContainer.transform.childCount - 1; i >= 0; i--)
        {
            if(isClicked)
            {
                Object.Destroy(newTask);
            }
            else
            {
                Object.Destroy(moreInfoContainer.transform.GetChild(i).gameObject);
            }
           
        }
    }
}
