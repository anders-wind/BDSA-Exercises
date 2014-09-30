namespace CalendarSystem.Controller
{
    class NotificationController
    {
        private static NotificationController _instance = null;
        private InputController _inputController;
        private ViewController _viewController;
        private NotificationController()
        {
            _viewController = ViewController.getInstance();
            _inputController = InputController.getInstance();
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
