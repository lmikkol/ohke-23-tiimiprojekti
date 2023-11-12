using System.Collections;
using System.Collections.Generic;
using System;
using System.Data;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using Mono.Data.Sqlite;
using TMPro;

public class TaskListView : MonoBehaviour
{

    public Button addTaskButton;
    public Button removeTaskButton;
    public GameObject task;
    public GameObject spawnPos;
    public List<GameObject> taskList = new List<GameObject>();

    public TMP_Text TaskName;
    public TMP_Text TaskTitle;
    public GameObject taskPanel;
    public bool buttonClick;
    

    TaskDao taskdao;

    // Start is called before the first frame update
    void Start()
    {
        addTaskButton.onClick.AddListener(AddTask);
        removeTaskButton.onClick.AddListener(RemoveTask);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddTask()
    {
        int i = 0;
        Debug.Log("Pressed");
        GameObject newTask = Instantiate(task, new Vector2(spawnPos.transform.position.x, spawnPos.transform.position.y), transform.rotation) as GameObject;
        //TMP_Text name = Instantiate(TaskName, new Vector2(spawnPos.transform.position.x, spawnPos.transform.position.y), transform.rotation) as TMP_Text;
        newTask.transform.SetParent(this.transform, true);
        //name.transform.SetAsFirstSibling();
        taskList.Add(newTask);
        //taskList.Add(name);
        //Debug.Log(TaskName.text + TaskTitle.text);
        //taskdao.AddTask(TaskName.text, TaskTitle.text);
        if (taskList.Count > 1)
        {
            foreach (GameObject task in taskList.Skip(1))
            {
                i++;
                task.transform.position = new Vector2(task.transform.position.x, taskList[i - 1].transform.position.y - 1.2f);
            }
        }
    }


    //If button is pressed, instantiate a new gameobject (prefab) and add it to list
    //If a new task is added, the transfrom of the previous task will be moved down
    //public void AddTask()
    //{
    //    int i = 0;  
    //    Debug.Log("Pressed");
    //    GameObject newTask = Instantiate(task, new Vector2(spawnPos.transform.position.x, spawnPos.transform.position.y), transform.rotation) as GameObject;
    //    newTask.transform.SetParent(this.transform, true);
    //    taskList.Add(newTask);
    //    //taskdao.AddTask(taskName, taskTitle);
    //    if (taskList.Count > 1)
    //    {
    //        foreach (GameObject task in taskList.Skip(1))
    //        {
    //            i++;
    //            task.transform.position = new Vector2(task.transform.position.x, taskList[i -1].transform.position.y - 1.2f);
    //        }
    //    }

    //}



    public void OnButtonClick()
    {

    }
    public void RemoveTask()
    {
      //need to reference the right instantiated task... 
    }

   
}
