using System.Windows;
using System.Windows.Media;
using Market.Classes;
using Market.Users;

namespace Market
{

    public partial class RegistrationPanel : Window
    {
        public RegistrationPanel()
        {
            InitializeComponent();
        }


        private bool loginError = true;
        private bool passwordError = true;
        private bool confirmError = true;


        private void Button_Back_Click(object sender, RoutedEventArgs e)
        {
            AppManager.Main.GoPrev();
        }
        private void Button_Registration_Click(object sender, RoutedEventArgs e)
        {
            string loginText = login.Text.Trim();
            string passwordText = password.Password.Trim();

            if (!passwordError && !loginError && !confirmError)
            {
                AppManager.Main.UserManager.RegistrateNew(loginText, passwordText,
                    (x) =>
                    {
                        MessageBox.Show($"User {x.Login} registrated");
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

        private void Confirm_GotFocus(object sender, RoutedEventArgs e)
        {
            confirm.Background = Brushes.Transparent;
            confirm.ToolTip = null;
        }
        private void Confirm_LostFocus(object sender, RoutedEventArgs e)
        {
            confirmError = true;

            if (loginError)
                return;
            if (passwordError)
            {
                confirm.ToolTip = $"Enter password first";
                confirm.Background = Brushes.LightCoral;
                return;
            }

            string confirmText = confirm.Password.Trim();
            string passwordText = password.Password.Trim();

            if (confirmText != passwordText)
            {
                confirm.ToolTip = $"Not equal";
                confirm.Background = Brushes.LightCoral;
                return;
            }

            confirmError = false;
        }
    }
}
