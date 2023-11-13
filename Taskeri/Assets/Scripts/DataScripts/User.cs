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

    //testing..
    //public User(string username)
    //{
    //    this.username = username;
    //}

    //testing..
    //public void setUserId(int id)
    //{
    //    this.id = id;
    //}

    //public void setUserName(string username)
    //{
    //    this.username = username;
    //}

    //public void setPassword(string password)
    //{
    //    this.password = password;
    //}
    //public int getUserId()
    //{
    //    return this.id;
    //}

    //public string getUsername()
    //{
    //    return this.username;
    //}

    //public string getUserPassword()
    //{
    //    return this.password;
    //}

}