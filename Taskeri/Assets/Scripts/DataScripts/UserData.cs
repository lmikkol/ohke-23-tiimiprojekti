using UnityEngine;
using System;
using System.Data;
using Mono.Data.Sqlite;
using TMPro;
using UnityEngine.UI;

public class UserData : MonoBehaviour
{
    public TMP_InputField userName;
    public TMP_InputField passWord;
    public TMP_InputField repeatPassword;
    public TMP_Text userList;

    private string dbName = "URI=file:DataBummer.db";
    

    // Start is called before the first frame update
    void Start()
    {
        CreateDB();

        DisplayUserData();
    }

    public void CreateDB()
    {
        //Creating database connection
        using(var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            using(var command = connection.CreateCommand())
            {
                //Create a table for user credentials
                command.CommandText = "CREATE TABLE IF NOT EXISTS User (id PRIMARY KEY, username TEXT NOT NULL UNIQUE, password TEXT NOT NULL)";
                command.ExecuteNonQuery();
            }

            connection.Close();
        }
    }

    public void DisplayUserData()
    {
        using(var connection = new SqliteConnection(dbName))
        {
            connection.Open();

        using(var command = connection.CreateCommand())
        {
            command.CommandText = "SELECT * FROM User";

            using (IDataReader reader = command.ExecuteReader())
            {
                while(reader.Read())
                
                    userList.text += reader["username"] + "\t\t" + reader ["password"] + "\n";

                    reader.Close();
                
            }
        }
            connection.Close();
        }
    }

    public void AddUser()
    {
        using(var connection = new SqliteConnection(dbName))
        {
            connection.Open();
            
            using(var command = connection.CreateCommand())
            {
                
               try
               {
                 command.CommandText = "INSERT INTO User(username, password) VALUES ('" + userName.text + "', '" + passWord.text + "');";
                command.ExecuteNonQuery();
              
               }
               catch (Exception e)
               {
                
                throw e;
               }
               
                // if (se.ResultCode != SQLiteErrorCode.Constraint_Unique)
            }

            connection.Close();
        }
        DisplayUserData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
