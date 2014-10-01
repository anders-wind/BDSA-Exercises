using CalendarSystem.Model;
using CalendarSystem.View;

namespace CalendarSystem.Controller
{
    class ViewController : IObserver
    {
        private static ViewController _instance = null;
        private InputController _inputController;
        private NotificationController _notificationController;

        private CalendarView _calendarView;
        private EventView _eventView;
        private NotificationView _notificationView;
        private MainView _mainView;

        private ViewController()
        {
            _notificationController = NotificationController.getInstance();
            _inputController = InputController.getInstance();
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

        public void UpdateCalenderOverview(CalendarView.OverviewType overviewType)
        {
            _calendarView.changeOverviewType(overviewType);
        }

        public void NotifyObserver()
        {
            throw new System.NotImplementedException();
        }
    }
}
