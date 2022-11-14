using Market.Models.Users;
using System.Collections.Generic;


namespace Market.Models.Data
{
    public interface IDataBase
    {
        User GetUser(string login, string password);
        void AddNewUser(string login, string password);
        void RemoveUser(string login);
        bool Exists(string login);
        List<User> GetAllUsers();
    }
}
