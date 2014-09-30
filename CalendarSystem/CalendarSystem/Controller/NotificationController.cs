namespace CalendarSystem.Controller
{
    class NotificationController
    {
        private static NotificationController _instance = null;
        private NotificationController()
        {
            
        }

        private void notifyUser()
        {
            
        }

        public static NotificationController getInstance()
        {
            if (_instance == null) _instance = new NotificationController();
            return _instance;
        }
    }
}
