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
       
        private InputController(IStorage storage, User user)
        {
            _storage = storage;
            _user = user;
        }


        public static InputController getInstanceSafe(IStorage storage, User user)
        {
            if (instance == null) instance = new InputController(storage, user);
            return instance;
        }

        public static InputController getInstanceUnsafe()
        {
            if (instance == null) throw new Exception();
            return instance;
        }
    }
}
