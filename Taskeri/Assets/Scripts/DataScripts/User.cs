using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class User : MonoBehaviour
{
    public string username { get; set; }
    public string password { get; set; }

    public int id { get; set; }

    public User(int id, string username, string password)
    {
        //testing...
        this.id = id;
        this.username = username;
        this.password = password;
    }

    public User()
    {
        this.username = "";
    }
}