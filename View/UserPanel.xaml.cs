using System;
using System.Windows;
using System.Windows.Media;
using Market.Models; 


namespace Market.View
{
    public partial class UserPanel : Window
    {


        public UserPanel()
        {
            InitializeComponent();
        }


        private bool loginError = true;
        private bool passwordError = true;

        private void Button_Back_Click(object sender, RoutedEventArgs e)
        {
            AppManager.Main.GoPrev();
        }
        private void Button_Login_Click(object sender, RoutedEventArgs e)
        {
            string loginText = login.Text.Trim();
            string passwordText = password.Password.Trim();

            if(!passwordError && !loginError)
            {
                AppManager.Main.UserManager.LogIn(loginText, passwordText,
                    (x) =>
                    {
                        MessageBox.Show($"User {x.Login} sing in");
                    },
                    (x) =>
                    {
                        MessageBox.Show($"Error, {x}");
                    });
            }
        }


        private void Login_GotFocus(object sender, RoutedEventArgs e)
        {
            login.Background = Brushes.Transparent;
            login.ToolTip = null;

        }
        private void Login_LostFocus(object sender, RoutedEventArgs e)
        {
            string loginText = login.Text.Trim();

            loginError = true;

            if (loginText.Length == 0)
                return;
            if (loginText.Length < User.MIN_LOGIN_LENGHT)
            {
                login.ToolTip = $"Min login lenght is {User.MIN_LOGIN_LENGHT}";
                login.Background = Brushes.LightCoral;
                return;
            }
            if (loginText.Length > User.MAX_LOGIN_LENGHT)
            {
                login.ToolTip = $"Max login lenght is {User.MAX_LOGIN_LENGHT}";
                login.Background = Brushes.LightCoral;
                return;
            }

            loginError = false;
        }

        private void Password_GotFocus(object sender, RoutedEventArgs e)
        {
            password.Background = Brushes.Transparent;
            password.ToolTip = null;

        }
        private void Password_LostFocus(object sender, RoutedEventArgs e)
        {
            string passwordText = password.Password.Trim();

            passwordError = true;
            if (passwordText.Length == 0)
                return;
            if (passwordText.Length < User.MIN_PASSWORD_LENGHT)
            {
                password.ToolTip = $"Min password lenght is {User.MIN_PASSWORD_LENGHT}";
                password.Background = Brushes.LightCoral;
                return;
            }
            if (passwordText.Length > User.MAX_PASSWORD_LENGHT)
            {
                password.ToolTip = $"Max password lenght is {User.MAX_PASSWORD_LENGHT}";
                password.Background = Brushes.LightCoral;
                return;
            }

            passwordError = false;
        }
    }
}