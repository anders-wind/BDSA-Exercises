using System;
using CalendarSystem.Controller;
using CalendarSystem.DataStorage;
using CalendarSystem.Model;

namespace CalendarSystem.View
{
    class LoginView
    {
        public LoginView()
        {
            
        }

        private void okButton()
        {
            // check user in database
            string username = "";
            string password = "";
            User user;
            try
            {
                user = InputController.getInstance()._storage.loginAuthentication(username, password);
            }catch (Exception ex)
            {
                return;
            }
            InputController.getInstance().userLogedIn(user);
            ViewController.getInstance().startMainView();
            // if user in database start program.
        }

        public User GetUser() // from login prompt
        {
            throw new NotImplementedException();
        }
    }
}
