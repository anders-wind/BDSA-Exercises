using CalendarSystem.View;

namespace CalendarSystem.Controller
{
    class ViewController
    {
        private CalendarView _calendarView;
        private EventView _eventView;
        private NotificationView _notificationView;
        private MainView _mainView;

        public ViewController()
        {
            new MainView(_calendarView);
        }
    }
}
