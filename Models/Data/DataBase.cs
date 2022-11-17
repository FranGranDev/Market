using MySql.Data.MySqlClient;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using Market.Models.Users;
using System;
using Market.Models.Items;


namespace Market.Models.Data
{
    /*
     * CREATE TABLE `market`.`items` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `model` VARCHAR(45) NOT NULL,
  `brand` VARCHAR(45) NOT NULL,
  `releaseDate` DATE NOT NULL,
  `baseCost` INT NOT NULL,
  `sale` DOUBLE NOT NULL,
  `count` INT NOT NULL,
  PRIMARY KEY (`id`));

     */
    public class DataBase : IUserDataBase, IMarketDataBase
    {
        private const string USERS = "users";
        private const string LOGIN = "login";
        private const string PASSWORD = "password";
        private const string IS_ADMIN = "isAdmin";

        private const string ITEMS = "items";
        private const string MODEL = "model";
        private const string BRAND = "brand";
        private const string RELEASE_DATE = "releaseDate";
        private const string BASE_COST = "baseCost";
        private const string SALE = "sale";
        private const string COUNT = "count";


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

        #region Users

        private void CheckForAdmin()
        {
            if(!Exists("admin"))
            {
                AddNewUser("admin", "admin", true);
            }
        }

        public User GetUser(string login)
        {
            MySqlCommand command = new MySqlCommand($"select * from {USERS} where {LOGIN} = @login", SqlConnection);
            command.Parameters.Add("@login", MySqlDbType.VarChar).Value = login;

            List<User> users = new List<User>();

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    string dataLogin = reader.GetString(1);
                    string dataPassword = reader.GetString(2);
                    bool dataIsAdmin = reader.GetBoolean(3);

                    if (dataIsAdmin)
                    {
                        users.Add(new Admin(dataLogin, dataPassword));
                    }
                    else
                    {
                        users.Add(new User(dataLogin, dataPassword));
                    }
                }
            }
         

            return users.Count > 0 ? users[0] : null;
        }
        public List<User> GetAllUsers()
        {            
            MySqlCommand command = new MySqlCommand($"select * from {USERS}", SqlConnection);

            
            List<User> users = new List<User>();

            using(MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
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
            }
            return users;
        }
        public void AddNewUser(string login, string password, bool isAdmin = false)
        {
            using (MySqlCommand command = new MySqlCommand($"insert into {USERS}({LOGIN}, {PASSWORD}, {IS_ADMIN}) values (@login, @password, @isAdmin)", SqlConnection))
            {
                command.Parameters.Add("@login", MySqlDbType.VarChar).Value = login;
                command.Parameters.Add("@password", MySqlDbType.VarChar).Value = password;
                command.Parameters.Add("@isAdmin", MySqlDbType.VarBinary).Value = isAdmin ? 1 : 0;

                command.ExecuteNonQuery();
            }
        }
        public void RemoveUser(string login)
        {
            using (MySqlCommand command = new MySqlCommand($"delete from {USERS} where {LOGIN} = @login", SqlConnection))
            {
                command.Parameters.Add("@login", MySqlDbType.VarChar).Value = login;
                command.ExecuteNonQuery();
            }
        }
        public bool Exists(string login)
        {
            using(MySqlCommand command = new MySqlCommand($"select count(*) from {USERS} where {LOGIN} = @login", SqlConnection))
            {
                command.Parameters.Add("@login", MySqlDbType.VarChar).Value = login;

                return Convert.ToInt32(command.ExecuteScalar()) > 0;
            }
        }

        #endregion

        #region Market
        public void AddSlot(MarketSlot item)
        {
            using (MySqlCommand command = new MySqlCommand($"insert into {ITEMS}({MODEL}, {BRAND}, {RELEASE_DATE}, {BASE_COST}, {SALE}, {COUNT}) values (@model, @brand, @date, @cost, @sale, @count)", SqlConnection))
            {
                command.Parameters.Add("@model", MySqlDbType.VarChar).Value = item.Item.Model;
                command.Parameters.Add("@brand", MySqlDbType.VarChar).Value = item.Item.Brand;
                command.Parameters.Add("@date", MySqlDbType.Date).Value = item.Item.Release.ToString("yyyy-MM-dd");
                command.Parameters.Add("@cost", MySqlDbType.Int32).Value = item.Cost.BaseCost;
                command.Parameters.Add("@sale", MySqlDbType.Double).Value = item.Cost.Sale;
                command.Parameters.Add("@count", MySqlDbType.Int32).Value = item.Count;

                command.ExecuteNonQuery();
            }
        }
        public void RemoveSlot(int id)
        {
            MySqlCommand command = new MySqlCommand($"delete from {ITEMS} where id = {id}", SqlConnection);
            using (command)
            {
                command.ExecuteNonQuery();
            }
        }
        public MarketSlot GetSlot(int id)
        {
            throw new NotImplementedException();
        }
        public void ChangeSlot(int id, MarketSlot item)
        {
            MySqlCommand command = new MySqlCommand($"update {ITEMS} set {MODEL} = @model, {BRAND} = @brand, {RELEASE_DATE} = @date, {BASE_COST} = @cost, {SALE} = @sale, {COUNT} = @count where id = {item.id}", SqlConnection);
            using (command)
            {
                command.Parameters.Add("@model", MySqlDbType.VarChar).Value = item.Item.Model;
                command.Parameters.Add("@brand", MySqlDbType.VarChar).Value = item.Item.Brand;
                command.Parameters.Add("@date", MySqlDbType.Date).Value = item.Item.Release.ToString("yyyy-MM-dd");
                command.Parameters.Add("@cost", MySqlDbType.Int32).Value = item.Cost.BaseCost;
                command.Parameters.Add("@sale", MySqlDbType.Double).Value = item.Cost.Sale;
                command.Parameters.Add("@count", MySqlDbType.Double).Value = item.Count;

                command.ExecuteNonQuery();
            }
        }
        public List<MarketSlot> GetAllSlots()
        {
            MySqlCommand command = new MySqlCommand($"select * from {ITEMS}", SqlConnection);
            List<MarketSlot> slots = new List<MarketSlot>();

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string model = reader.GetString(1);
                    string brand = reader.GetString(2);
                    DateTime time = reader.GetDateTime(3);
                    int baseCost = reader.GetInt32(4);
                    double sale = reader.GetDouble(5);
                    int count = reader.GetInt32(6);

                    MarketItem item = new MarketItem(model, brand, time);
                    ItemCost cost = new ItemCost(baseCost, sale);

                    slots.Add(new MarketSlot(id, item, cost, count));
                }
            }
            return slots;
        }
        #endregion
    }
}
