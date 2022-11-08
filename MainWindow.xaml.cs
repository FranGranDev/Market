using System.Windows;
using System.ComponentModel;
using Market.Users;
using System;


namespace Market
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            userManager = new UsersManager();
        }

        private UsersManager userManager;

        private void Button_Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void Button_Login_Click(object sender, RoutedEventArgs e)
        {
            Hide();

            UserPanel panel = new UserPanel(() => Show());
            panel.Show();
        }
        private void Button_Registration_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
