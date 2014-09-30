using System;
using CalendarSystem.DataStorage;
using CalendarSystem.Model;

namespace CalendarSystem.Controller
{
    class InputController
    {
        private static InputController instance = null;

        private IStorage _storage;
        private User _user;
       
        private InputController()
        {
        }

        public void userLogedIn(User user)
        {
            _user = user;
            _storage = new FakeStorage();
        }


        public static InputController getInstance()
        {
            if (instance == null) instance = new InputController();
            return instance;
        }
    }
}
