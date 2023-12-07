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

    public Button loginButton;

    // Start is called before the first frame update
    void Start()
    {
        CreateDB();

        //    DisplayUserData();
    }

    public void CreateDB()
    {
        //Creating database connection
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                //Create a table for user credentials
                command.CommandText = "CREATE TABLE IF NOT EXISTS User (id INTEGER PRIMARY KEY, username TEXT NOT NULL UNIQUE, password TEXT NOT NULL)";
                command.ExecuteNonQuery();
            }

            connection.Close();
        }
    }

    public void DisplayUserData()
    {
<<<<<<< HEAD
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

    public void AddUser(string user, string hashPassword)
    {

=======
>>>>>>> logOutUser
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
<<<<<<< HEAD

                try
                {
                    command.CommandText = "INSERT INTO User(username, password) VALUES ('" + user + "', '" + hashPassword + "'); SELECT last_insert_rowid()";
                    command.ExecuteNonQuery();
                    //id = Convert.ToInt32(command.ExecuteScalar());
                    //MainManager.Instance.savedUserName = user;


                }
                catch (Exception e)
                {
                    Debug.Log(e);
                }
            }
            connection.Close();
        }
        DisplayUserData();
    }

    public User LoginData(string userName)
    {

        User loggedInUser = new User();

        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                //lis�tty kyselyyn kaikki
                command.CommandText = "SELECT * FROM User WHERE username = @username";
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@username", userName);
                using (var reader = command.ExecuteReader())
                {


                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            //User loggedUser = GetLoggedUser();
                            Debug.Log(reader["username"] + " " + reader["password"] + " " + reader["id"] + " tietokannasta salasana");

                            loggedInUser = new User(
                            //!!!RATKAISE IDn OIKEA MUOTO
                            Convert.ToInt32(reader["id"]) /*100*/,
                            reader["username"].ToString(),
                            reader["password"].ToString()

                        );

                            Debug.Log(loggedInUser.username);
                            return loggedInUser;
                        }
                    }
                }

=======
                command.CommandText = "SELECT * FROM User";

                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())

                        userList.text += reader["username"] + "\t\t" + reader["password"] + "\n";

                    reader.Close();

                }
>>>>>>> logOutUser
            }
            connection.Close();

        }
        return loggedInUser;
    }

<<<<<<< HEAD
=======
    public void AddUser(string user, string hashPassword)
    {

        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {

                try
                {
                    command.CommandText = "INSERT INTO User(username, password) VALUES ('" + user + "', '" + hashPassword + "'); SELECT last_insert_rowid()";
                    command.ExecuteNonQuery();
                    //id = Convert.ToInt32(command.ExecuteScalar());
                    //MainManager.Instance.savedUserName = user;


                }
                catch (Exception e)
                {
                    Debug.Log(e);
                }
            }
            connection.Close();
        }
        DisplayUserData();
    }

    public User LoginData(string userName)
    {

        User loggedInUser = new User();

        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                //lis�tty kyselyyn kaikki
                command.CommandText = "SELECT * FROM User WHERE username = @username";
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@username", userName);
                using (var reader = command.ExecuteReader())
                {


                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            //User loggedUser = GetLoggedUser();
                            Debug.Log(reader["username"] + " " + reader["password"] + " " + reader["id"] + " tietokannasta salasana");

                            loggedInUser = new User(
                            //!!!RATKAISE IDn OIKEA MUOTO
                            Convert.ToInt32(reader["id"]) /*100*/,
                            reader["username"].ToString(),
                            reader["password"].ToString()

                        );

                            Debug.Log(loggedInUser.username);
                            return loggedInUser;
                        }
                    }
                }

            }
            connection.Close();

        }
        return loggedInUser;
    }

>>>>>>> logOutUser
    //public void LoginData(string userName)
    //{
    //    Debug.Log("TIETOKANNASTA SALASANA");
    //    using (var connection = new SqliteConnection(dbName))
    //    {
    //        connection.Open();

    //        using (var command = connection.CreateCommand())
    //        {
    //            command.CommandText = "SELECT password FROM User WHERE username = @username";
    //            command.CommandType = CommandType.Text;
    //            command.Parameters.AddWithValue("@username", userName);
    //            using (var reader = command.ExecuteReader())
    //            {
    //                while (reader.Read())
    //                {
    //                    Debug.Log(reader["password"] + "TIETOKANNASTA SALASANA");
    //                }
    //            }

    //        }
    //        connection.Close();
    //    }
    //}


    // Update is called once per frame
    void Update()
    {

    }
}