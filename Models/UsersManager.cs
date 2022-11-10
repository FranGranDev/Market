using System;
using System.Collections.Generic;


namespace Market.Models
{
    public class UsersManager
    {
        public UsersManager()
        {
            users = new List<User>()
            {
                new User("admin", "admin")
            };

            Active = this;
        }
        public static UsersManager Active { get; private set; }

        private List<User> users;


        public User Currant { get; private set; }


        public void RegistrateNew(string login, string password, Action<User> onSuccess, Action<UserFailType> onFail)
        {
            List<User> finded = users.FindAll(x => x.Login == login);
            if (finded.Count == 0)
            {
                User user = new User(login, password);
                users.Add(user);

                onSuccess?.Invoke(user);
                return;
            }
            else
            {
                onFail?.Invoke(UserFailType.UserAlreadyExists);
            }
        }

        public void LogIn(string login, string password, Action<User> onSuccess, Action<UserFailType> onFail)
        {
            List<User> finded = users.FindAll(x => x.Login == login);
            if(finded.Count == 0)
            {
                onFail?.Invoke(UserFailType.InvalidLoginOrPassword);
                return;
            }
            User user = finded[0];
            if(!user.ComparePassword(password))
            {
                onFail?.Invoke(UserFailType.InvalidLoginOrPassword);
                return;
            }

            Currant = user;
            onSuccess?.Invoke(user);
        }

        public void LogOut(Action<User> onSuccess, Action<UserFailType> onFail)
        {
            if(Currant != null)
            {
                onSuccess?.Invoke(Currant);
            }
            else
            {
                onFail?.Invoke(UserFailType.NotLogIn);
            }

            Currant = null;
        }

        public enum UserFailType
        {
            InvalidLoginOrPassword,
            UserAlreadyExists,
            NotLogIn,
            Blocked,
        }
    }
}
