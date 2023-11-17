using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tasks : MonoBehaviour
{
    public string taskName { get; set; }
    public string taskTitle { get; set; }

    public int user_id { get; set; }


    public Tasks(int user_id, string taskname, string tasktitle)
    {
        this.user_id = user_id;
        this.taskName = taskname;
        this.taskTitle = tasktitle;
    }

    public Tasks ()
    {
        this.taskName = "";
    }
}
