using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task : MonoBehaviour
{ 
    
    public string taskTitle { get; set; }
    public string taskDescription { get; set; }
    public bool taskDone { get; set; }

    // Start is called before the first frame update
    public Task(string taskTitle, string taskDescription)
    {
      
        this.taskTitle = taskTitle;
        this.taskDescription = taskDescription;
        this.taskDone = false;
    }
}