using CalendarSystem.View;

namespace CalendarSystem.Controller
{
    class ViewController
    {
        private static ViewController _instance = null;

        private CalendarView _calendarView;
        private EventView _eventView;
        private NotificationView _notificationView;
        private MainView _mainView;

        private ViewController()
        {
            
        }

        public void startMainView()
        {
            new MainView(_calendarView);
        }

        public static ViewController getInstance()
        {
            if(_instance == null) _instance = new ViewController();
            return _instance;
        }
    }
}
