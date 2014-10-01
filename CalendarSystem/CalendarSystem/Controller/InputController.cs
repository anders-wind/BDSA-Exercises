using System;
using System.Dynamic;
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
       
        private InputController()
        {
            _storage = new FakeStorage();
            _viewController = ViewController.getInstance();
            _notificationController = NotificationController.getInstance();
        }

        public void CreateCalendarEntry(string description, int month, int day, int startHour, int endHour)
        {
        }

        public void UpdateCalendarEntry(IEvent eventToUpdate, IEvent oldEvent)
        {
        }

        void Login(string username, string password)
        {
            User user;
            try
            {
                user = _storage.loginAuthentication(username, password);
                ViewController.getInstance().startMainView();
            }
            catch (Exception ex)
            {
            }
        }


        public static InputController getInstance()
        {
            if (_instance == null) _instance = new InputController();
            return _instance;
        }
    }
}
