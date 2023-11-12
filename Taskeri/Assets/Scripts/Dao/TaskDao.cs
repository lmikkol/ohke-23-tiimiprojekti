using System;
using System.Data;
using UnityEngine;
using Mono.Data.Sqlite;
using TMPro;

public class TaskDao : MonoBehaviour
{
    private string dbName = "URI=file:DataBummer.db";

    //public TMP_InputField taskName;
    //public TMP_InputField taskType;
    //public TMP_InputField taskTitle;

    public TMP_Text TaskName;
    public TMP_Text TaskTitle;
    public TMP_Text taskPaneList;

    //public Button addTask;

    // Start is called before the first frame update
    void Start()
    {
        CreateTaskDB();

        //DisplayUserData();
    }

    public void CreateTaskDB()
    {
        //Creating database connection
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                //Create a table for user credentials
                command.CommandText = "CREATE TABLE IF NOT EXISTS Tasks (task_id INTEGER PRIMARY KEY, FOREIGN KEY (user_id) REFERENCES User(id), name TEXT NOT NULL, type TEXT NOT NULL, title TEXT NOT NULL, body TEXT NOT NULL, status VARCHAR, created DATETIME)";
                command.ExecuteNonQuery();
            }

            connection.Close();
        }
    }

    public void AddTask(string taskName, string taskTitle)
    {
        
                //string taskName = TaskName.text;
                //string taskTitle = TaskTitle.text;

        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                //"INSERT INTO Tasks(name, title) VALUES ('" + taskName + "', '" + taskTitle + "'); SELECT last_insert_rowid()"
                command.CommandText = "INSERT INTO Tasks(name, title) VALUES ('" + taskName + "', '" + taskTitle + "');";
                //command.Parameters.AddWithValue("@taskName", taskName);
                //command.Parameters.AddWithValue("@taskTitle", taskTitle);
                command.ExecuteNonQuery();
                    
                Debug.Log("Inserting?");
                /*"Taskin nimi: " + taskName + " " + " Taskin title: " + " " + taskTitle*/
            }
            connection.Close();
        }

        DisplayTask();
    }

    public void DisplayTask()
    {
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM Tasks";

                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())

                        taskPaneList.text += reader["name"] + "\t\t" + reader["title"] + "\n";

                    reader.Close();

                }
            }
            connection.Close();
        }
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

