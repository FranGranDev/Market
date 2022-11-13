using System;
using System.Collections.Generic;
using Market.Models.Exceptions;


namespace Market.Models.Users
{
    public class UsersManager
    {
        public const int MIN_LOGIN_LENGHT = 4;
        public const int MAX_LOGIN_LENGHT = 16;

        public const int MIN_PASSWORD_LENGHT = 4;
        public const int MAX_PASSWORD_LENGHT = 16;


        public UsersManager()
        {
            users = new List<User>()
            {
                new User("admin", "admin")
            };
        }


        private List<User> users;

        public List<User> Users => users;
        public User Currant { get; private set; }

        #region User

        public void RegistrateNew(string login, string password)
        {
            List<User> finded = users.FindAll(x => x.Login == login);
            if (finded.Count == 0)
            {
                User user = new User(login, password);
                users.Add(user);
                return;
            }
            else
            {
                throw new UserAlreadyExistsException();
            }
        }
        public void LogIn(string login, string password)
        {
            List<User> finded = users.FindAll(x => x.Login == login);
            if(finded.Count == 0)
            {
                throw new NoUserFindedException(login);
            }
            User user = finded[0];
            if(!user.ComparePassword(password))
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
