using System;
using System.Collections.Generic;
using Market.Models.Exceptions;
using Market.Models.Data;


namespace Market.Models.Users
{
    public class UsersManager
    {
        public const int MIN_LOGIN_LENGHT = 4;
        public const int MAX_LOGIN_LENGHT = 16;

        public const int MIN_PASSWORD_LENGHT = 4;
        public const int MAX_PASSWORD_LENGHT = 16;

        public UsersManager(IDataBase dataBase)
        {
            this.dataBase = dataBase;
        }


        private IDataBase dataBase;


        public List<User> Users
        {
            get => dataBase.GetAllUsers();
        }
        public User Currant { get; private set; }

        #region User

        public void RegistrateNew(string login, string password)
        {
            if (!dataBase.Exists(login))
            {
                dataBase.AddNewUser(login, password);
                return;
            }
            else
            {
                throw new UserAlreadyExistsException();
            }
        }
        public void LogIn(string login, string password)
        {
            if (!dataBase.Exists(login))
            {
                throw new NoUserFindedException(login);
            }
            User user = dataBase.GetUser(login, password);
            if (!user.ComparePassword(password))
            {
                throw new InvalidLoginOrPasswordException(login);
            }

            Currant = user;
        }
        public void LogOut()
        {
            if(Currant == null)
            {
                throw new UserNotSingInException();
            }

            Currant = null;
        }

        #endregion

        #region Admin

        public void BlockUser(User user)
        {

        }

        #endregion
    }
}
