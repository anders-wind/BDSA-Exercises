using System;
using CalendarSystem.DataStorage;
using CalendarSystem.Model;

namespace CalendarSystem.Controller
{
    class InputController
    {
        private static InputController _instance = null;

        public IStorage _storage{ get; private set; }
        public User _user { get; private set; }
       
        private InputController()
        {
            _storage = new FakeStorage();
        }

        public void userLogedIn(User user)
        {
            _user = user;
        }


        public static InputController getInstance()
        {
            if (_instance == null) _instance = new InputController();
            return _instance;
        }
    }
}
