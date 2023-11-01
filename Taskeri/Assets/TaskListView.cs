using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class TaskListView : MonoBehaviour
{

    public Button addTaskButton;
    public Button removeTaskButton;
    public GameObject task;
    public GameObject spawnPos;
    public List<GameObject> taskList = new List<GameObject>(); 

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


    //If button is pressed, instantiate a new gameobject (prefab) and add it to list
    //If a new task is added, the transfrom of the previous task will be moved down
    public void AddTask()
    {
        int i = 0;  
        Debug.Log("Pressed");
        GameObject newTask = Instantiate(task, new Vector2(spawnPos.transform.position.x, spawnPos.transform.position.y), transform.rotation) as GameObject;
        newTask.transform.SetParent(this.transform, true);
        taskList.Add(newTask);
        if (taskList.Count > 1)
        {
            foreach (GameObject task in taskList.Skip(1))
            {
                i++;
                task.transform.position = new Vector2(task.transform.position.x, taskList[i -1].transform.position.y - 1.2f);
            }
        }

    }

    public void RemoveTask()
    {
      //need to reference the right instantiated task... 
    }

   
}
