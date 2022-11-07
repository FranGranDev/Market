using System.Windows;
using System.ComponentModel;
using Market.Models;
using System;

namespace Market
{
    public partial class MainWindow : Window
    {
        private BindingList<ToDoModel> todoData;

        public MainWindow()
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            todoData = new BindingList<ToDoModel>()
            {
                new ToDoModel(){Text = "aboba"},
                new ToDoModel(){Text = "stas"},
            };

            base_grid.ItemsSource = todoData;
        }
    }
}
