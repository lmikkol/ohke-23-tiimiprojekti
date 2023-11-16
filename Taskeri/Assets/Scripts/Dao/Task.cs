using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task : MonoBehaviour
{

    public static Task Instance;
    
    public string taskTitle { get; set; }
    public string taskDescription { get; set; }
    public int taskDone { get; set; }

    // Start is called before the first frame update
    public Task(string taskTitle, string taskDescription)
    {
      
        this.taskTitle = taskTitle;
        this.taskDescription = taskDescription;
        this.taskDone = 0;
    }

    private void Awake()
    {
        Instance = this;
    }
}