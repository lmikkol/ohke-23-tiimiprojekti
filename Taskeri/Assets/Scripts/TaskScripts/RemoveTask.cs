using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RemoveTask : MonoBehaviour
{

    public Button removeTask;

    public TMP_Text title;
    public Button descriptionButton;
    public GameObject container;
    public GameObject descriptionForm;

    // Start is called before the first frame update
    void Start()
    {
        container = GameObject.Find("TestPosition");
        descriptionButton.onClick.AddListener(DisplayDescription);

        removeTask.onClick.AddListener(RemoveTaskClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RemoveTaskClick()
    {
        Debug.Log("Remove pressed");
        KillChild();
        Destroy(gameObject);
    }

    public void DisplayDescription()
    {

        KillChild();

        // foreach(GameObject child in container.transform)
        // {
        //     Destroy(child);
        // }

        // GameObject old = GameObject.FindWithTag("Description");
        // Destroy(old);

        GameObject newTask = Instantiate(descriptionForm, container.transform) as GameObject;
        //newTask.transform.SetParent(container.transform, false); 
        //newTask.transform.localPosition = new Vector2(0, 0);

        // GameObject newTask = Instantiate(descriptionForm, transform) as GameObject;
       // newTask.transform.parent = container.transform;
        // Debug.Log("Open Clicked!");
        Image taskTitlePh = newTask.transform.Find("TaskTitleForm").GetComponent<Image>();
        TMP_Text headLiner = taskTitlePh.transform.Find("TaskTitleTxt").GetComponent<TMP_Text>();
        //TMP_Text info = newTask.transform.Find("TaskDescriptionTxt").GetComponent<TMP_Text>();
        headLiner.text = title.text;
        //info.text = description.text;

        // taskDescription = task.GetComponentInChildren<TMP_Text>();
        // taskDescription.text = description.text;

        // GameObject newTask = (Instantiate(descriptionForm, transform) as GameObject).transform.parent = container.transform;
    }

    public void KillChild()
    {
        for (int i = container.transform.childCount - 1; i >= 0; i--)
        {
            Object.Destroy(container.transform.GetChild(i).gameObject);
        }
    }
}
