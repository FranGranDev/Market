using MySql.Data.MySqlClient;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using Market.Models.Users;
using System;

namespace Market.Models.Data
{
    public class DataBase : IDataBase
    {
        private const string USERS = "users";
        private const string LOGIN = "login";
        private const string PASSWORD = "password";
        private const string IS_ADMIN = "isAdmin";

        public DataBase()
        {
            sqlConnection = new MySqlConnection("server=localhost;port=3306;username=root;password=qwerty123;database=Market");

            OpenConnection();
            CheckForAdmin();
        }
        ~DataBase()
        {
            CloseConnection();
        }

        private readonly MySqlConnection sqlConnection;

        public MySqlConnection SqlConnection => sqlConnection;

        public void OpenConnection()
        {
            if(sqlConnection.State == ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
        }
        public void CloseConnection()
        {
            if (sqlConnection.State == ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }


        private void CheckForAdmin()
        {
            if(!Exists("admin"))
            {
                AddNewUser("admin", "admin", true);
            }
        }


        public User GetUser(string login, string password)
        {
            MySqlCommand command = new MySqlCommand($"select * from {USERS} where {LOGIN} = @login and {PASSWORD} = @password", SqlConnection);
            command.Parameters.Add("@login", MySqlDbType.VarChar).Value = login;
            command.Parameters.Add("@password", MySqlDbType.VarChar).Value = password;

            MySqlDataReader reader = command.ExecuteReader();

            List<User> users = new List<User>();

            while (reader.Read())
            {
                string dataLogin = reader[1].ToString();
                string dataPassword = reader[2].ToString();
                bool dataIsAdmin = reader[3].ToString() == "True";

                if (dataIsAdmin)
                {
                    users.Add(new Admin(dataLogin, dataPassword));
                }
                else
                {
                    users.Add(new User(dataLogin, dataPassword));
                }
            }
            reader.Close();

         

            return users.Count > 0 ? users[0] : null;
        }
        public List<User> GetAllUsers()
        {            
            MySqlCommand command = new MySqlCommand($"select * from {USERS}", SqlConnection);

            MySqlDataReader reader = command.ExecuteReader();

            List<User> users = new List<User>();

            while(reader.Read())
            {
                string login = reader[1].ToString();
                string password = reader[2].ToString();
                bool isAdmin = reader[3].ToString() == "True";

                if (isAdmin)
                {
                    users.Add(new Admin(login, password));
                }
                else
                {
                    users.Add(new User(login, password));
                }
            }
            reader.Close();

            return users;
        }
        public void AddNewUser(string login, string password, bool isAdmin = false)
        {
            MySqlCommand command = new MySqlCommand($"insert into {USERS}({LOGIN}, {PASSWORD}, {IS_ADMIN}) values (@login, @password, @isAdmin)", SqlConnection);
            command.Parameters.Add("@login", MySqlDbType.VarChar).Value = login;
            command.Parameters.Add("@password", MySqlDbType.VarChar).Value = password;
            command.Parameters.Add("@isAdmin", MySqlDbType.VarBinary).Value = isAdmin ? 1 : 0;


            command.ExecuteNonQuery();
        }
        public void RemoveUser(string login)
        {
            MySqlCommand command = new MySqlCommand($"delete from {USERS} where {LOGIN} = @login", SqlConnection);
            command.Parameters.Add("@login", MySqlDbType.VarChar).Value = login;
            
            command.ExecuteNonQuery();
        }
        public bool Exists(string login)
        {
            using(MySqlCommand command = new MySqlCommand($"select count(*) from {USERS} where {LOGIN} = @login", SqlConnection))
            {
                command.Parameters.Add("@login", MySqlDbType.VarChar).Value = login;

                return Convert.ToInt32(command.ExecuteScalar()) > 0;
            }
        }
    }
}
