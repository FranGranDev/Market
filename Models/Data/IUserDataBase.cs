﻿using Market.Models.Users;
using System.Collections.Generic;


namespace Market.Models.Data
{
    public interface IUserDataBase
    {
        User GetUser(string login);
        void AddNewUser(string login, string password, bool isAdmin = false);
        void RemoveUser(string login);
        bool Exists(string login);
        List<User> GetAllUsers();
    }
}
