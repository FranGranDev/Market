using System;
using System.Windows;
using System.Windows.Media;
using Market.Users;


namespace Market
{
    public partial class UserPanel : Window
    {
        private const int MIN_LOGIN_LENGHT = 4;
        private const int MAX_LOGIN_LENGHT = 16;

        private const int MIN_PASSWORD_LENGHT = 4;
        private const int MAX_PASSWORD_LENGHT = 16;

        public UserPanel(Action onBack)
        {
            this.onBack = onBack;

            InitializeComponent();
        }

        private Action onBack;

        private bool loginError = true;
        private bool passwordError = true;

        private void Button_Back_Click(object sender, RoutedEventArgs e)
        {
            onBack?.Invoke();
            Close();
        }
        private void Button_Login_Click(object sender, RoutedEventArgs e)
        {
            string loginText = login.Text.Trim();
            string passwordText = password.Password.Trim();

            if (passwordError || loginError)
            {
                MessageBox.Show("Error!");
            }
            else
            {
                MessageBox.Show("Done!");
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
            if (loginText.Length < MIN_LOGIN_LENGHT)
            {
                login.ToolTip = $"Min login lenght is {MIN_LOGIN_LENGHT}";
                login.Background = Brushes.DarkRed;
                return;
            }
            if (loginText.Length > MAX_LOGIN_LENGHT)
            {
                login.ToolTip = $"Max login lenght is {MAX_LOGIN_LENGHT}";
                login.Background = Brushes.DarkRed;
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
            if (passwordText.Length < MIN_PASSWORD_LENGHT)
            {
                password.ToolTip = $"Min password lenght is {MIN_PASSWORD_LENGHT}";
                password.Background = Brushes.DarkRed;
                return;
            }
            if (passwordText.Length > MAX_PASSWORD_LENGHT)
            {
                password.ToolTip = $"Max password lenght is {MAX_PASSWORD_LENGHT}";
                password.Background = Brushes.DarkRed;
                return;
            }

            passwordError = false;
        }
    }
}