using System;
using CalendarSystem.DataStorage;
using CalendarSystem.Model;

namespace CalendarSystem.Controller
{
    class InputController
    {
        private static InputController _instance = null;
        private ViewController _viewController;
        private NotificationController _notificationController;

        public IStorage _storage{ get; private set; }
        public Calendar _Calendar { get; private set; }
       
        private InputController()
        {
            _storage = new FakeStorage();
            _viewController = ViewController.getInstance();
            _notificationController = NotificationController.getInstance();
        }

        public void userLogedIn(User user)
        {
            _Calendar = _storage.GetCalendar(user);
            _Calendar.Observe(_viewController);
        }


        public static InputController getInstance()
        {
            if (_instance == null) _instance = new InputController();
            return _instance;
        }
    }
}
