using System;
using System.Collections.Generic;
using System.Windows;
using Market.Users;


namespace Market.Classes
{
    class AppManager
    {
        #region Singltone

        public AppManager(Window start)
        {
            UserManager = new UsersManager();

            windowStack = new Stack<Window>();
            windowStack.Push(start);

            Main = this;
        }
        public static AppManager Main { get; private set; }

        #endregion

        private Stack<Window> windowStack;

        public UsersManager UserManager { get; private set; }
        public Window Active
        {
            get
            {
                if (windowStack.Count == 0)
                    return null;
                return windowStack.Peek();
            }
        }

        public void GoWindow(Window window)
        {
            if (windowStack.Count > 0)
            {
                Active.Hide();
            }
            window.Closed += ClosePrev;

            windowStack.Push(window);
            Active.Show();
        }
        public void GoPrev()
        {
            if (windowStack.Count > 1)
            {
                windowStack.Peek().Close();
            }
        }

        private void ClosePrev(object sender, EventArgs e)
        {
            if (windowStack.Count > 1)
            {
                windowStack.Pop();
                Active.Show();
            }
        }
    }
}
