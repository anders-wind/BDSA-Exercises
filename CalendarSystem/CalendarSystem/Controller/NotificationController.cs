using System.Collections.Generic;
using CalendarSystem.Model;

namespace CalendarSystem.Controller
{
    /// <summary>
    /// The Notification controller has a timer for the notifications and will create a popup when a notification's time is exceeded.
    /// </summary>
    class NotificationController : IObserver
    {
        private static NotificationController _instance = null;
        private InputController _inputController;
        private ViewController _viewController;
        private Dictionary<int, Notification> notifications ; 
        private NotificationController()
        {
            _viewController = ViewController.getInstance();
            _inputController = InputController.getInstance();
        }

        /// <summary>
        /// Call the ViewController and make it Create a notification window for the notification.
        /// </summary>
        private void notifyUser(int ID)
        {
            ViewController.getInstance().createNotificationView(ID, notifications[ID]);
        }

        /// <summary>
        /// Singleton pattern. Makes sure only one instance can exist at a given time, and give classes easy access to the controller.
        /// </summary>
        /// <returns>The only instance of the class</returns>
        public static NotificationController getInstance()
        {
            if (_instance == null) _instance = new NotificationController();
            return _instance;
        }

        /// <summary>
        /// A change in the model has happened.
        /// </summary>
        public void NotifyObserver()
        {
            throw new System.NotImplementedException();
        }
    }
}
