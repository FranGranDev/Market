using System.Windows;
using System.ComponentModel;
using Market.Models;
using System;


namespace Market.View
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            new AppManager(this);
        }


        private void Button_Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void Button_Login_Click(object sender, RoutedEventArgs e)
        {
            AppManager.Main.GoWindow(new UserPanel());
        }
        private void Button_Registration_Click(object sender, RoutedEventArgs e)
        {
            AppManager.Main.GoWindow(new RegistrationPanel());
        }
    }
}
