using System;
using System.Data;
using UnityEngine;
using Mono.Data.Sqlite;
using TMPro;
using System.Collections.Generic;

public class TaskDao : MonoBehaviour
{
    private string dbName = "URI=file:DataBummer.db";

    //public TMP_InputField taskName;
    //public TMP_InputField taskType;
    //public TMP_InputField taskTitle;

    public TMP_Text TaskName;
    public TMP_Text TaskTitle;
    public TMP_Text taskPaneList;

    Task task;

    //public Button addTask;

    void Awake()
    {
        CreateTaskDB();

        
    }

    //Creates Task- datatable if doesnt exists
    public void CreateTaskDB()
    {
        using (var connection = new SqliteConnection(dbName))
        {
            Debug.Log("create DB");
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"CREATE TABLE IF NOT EXISTS Tasks
                                        (task_id INTEGER PRIMARY KEY, 
                                        title TEXT NOT NULL, 
                                        description TEXT, 
                                        created_at TEXT NOT NULL, 
                                        done INTEGER, 
                                        user_id INTEGER,
                                        FOREIGN KEY(user_id) REFERENCES User(id))";
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            connection.Close();
        }
    }

    //Adds new task to the Task- table
    public void AddTask(string taskTitle, string taskDescription, string taskDate, int userId)
    {
        Debug.Log("create task");
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {

                command.CommandText = "INSERT INTO Tasks(title, description, created_at, done, user_id) VALUES(@taskTitle, @taskDescription, @taskDate, @done, @user_id)";
                command.Parameters.AddWithValue("@taskTitle", taskTitle);
                command.Parameters.AddWithValue("@taskDescription", taskDescription);
                command.Parameters.AddWithValue("@taskDate", taskDate);
                command.Parameters.AddWithValue("@done", 0);
                command.Parameters.AddWithValue("@user_id", userId);
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            connection.Close();
        }
    }



    public List<List<string>> SelectAllTaskByUserId(int userId)
    {
        List<List<string>> tasks = new();
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM Tasks WHERE user_id = @user_id ORDER BY done ";
                command.Parameters.AddWithValue("@user_id", userId);

                using (IDataReader reader = command.ExecuteReader())
                {
                    int i = 0;
                    while (reader.Read())
                    {
                        List<string> ph = new()
                        {
                            reader["title"].ToString(),
                            reader["description"].ToString(),
                            reader["done"].ToString()
                        };
                        tasks.Add(ph);
                    }


                    reader.Close();
                }
            }
            connection.Close();
        }

        return tasks;
    }

    public Tasks TaskData(string taskName)
    {

        Tasks taskname = new Tasks();
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                //"INSERT INTO Tasks(name, title) VALUES ('" + taskName + "', '" + taskTitle + "'); SELECT last_insert_rowid()"
                command.CommandText = "SELECT * FROM Tasks WHERE name = @name;";
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("name", taskname.taskName);
                //command.CommandType = CommandType.Int;

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Debug.Log(reader["username"] + " " + reader["password"] + " " + reader["id"] + " tietokannasta salasana");

                        taskname = new Tasks
                        (

                        Convert.ToInt32(reader["user_id"]) /*100*/,
                        reader["name"].ToString(),
                        reader["title"].ToString()

                        );

                    }
                    Debug.Log(taskname.taskName);
                    return taskname;

                }

                connection.Close();
            }
        }
        return taskname;
    }


}
