using System;
using System.Dynamic;
using CalendarSystem.DataStorage;
using CalendarSystem.Model;
using CalendarSystem.View;

namespace CalendarSystem.Controller
{
    /// <summary>
    /// The inputcontroller handles all incoming user interaction, such as button presses and so on.
    /// </summary>
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
            _storage.BeObserved(_viewController);
            _storage.BeObserved(_notificationController);
        }

        /// <summary>
        /// A method which will often be called from the view.
        /// The method takes some parameters and gives the to the storage, where an event will be created and uploaded.
        /// </summary>
        /// <param name="description">The description of an event</param>
        /// <param name="month"> The month of the event</param>
        /// <param name="day"> The day of the event</param>
        /// <param name="startHour">The start hour of the event</param>
        /// <param name="endHour">The end hour of the event</param>
        public void CreateCalendarEntry(string description,int year, int month, int day, int startHour, int endHour)
        {
            _storage.SaveEvent(description, new DateTime(year, month, day), new TimeSpan(endHour-startHour), null);
        }

        /// <summary>
        /// A method which will often be called from the view.
        /// The method takes some parameters and gives the to the storage, where an event will be updated and uploaded.
        /// </summary>
        /// <param name="ID"> The ID of the </param>
        /// <param name="description">The description of an event</param>
        /// <param name="month"> The month of the event</param>
        /// <param name="day"> The day of the event</param>
        /// <param name="startHour">The start hour of the event</param>
        /// <param name="endHour">The end hour of the event</param>
        public void UpdateCalendarEntry(int ID, string description, int year, int month, int day, int startHour, int endHour)
        {
            _storage.UpdateEvent(ID, description, new DateTime(year, month, day), new TimeSpan(endHour - startHour), null);
        }

        /// <summary>
        /// A method to create a tag and put it in the datastorage
        /// </summary>
        /// <param name="newTag"></param>
        public void CreateTag(string newTag)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Send the request for a new view type to the viewController.
        /// </summary>
        /// <param name="overviewType">A string which represents a overview type</param>
        public void ChangeOverviewType(string overviewType)
        {
            ViewController.getInstance().UpdateCalenderOverview(overviewType);
        }

        /// <summary>
        /// Given a username and a password, authenticate with the storage and let it download the calendar.
        /// If everything goes fine, create the window.
        /// </summary>
        /// <param name="username">The inputted username</param>
        /// <param name="password">The inputted password</param>
        void Login(string username, string password)
        {
            try
            {
                _storage.loginAuthentication(username, password);
                ViewController.getInstance().startMainView();
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Singleton pattern. Makes sure only one instance can exist at a given time, and give classes easy access to the controller.
        /// </summary>
        /// <returns>The only instance of the class</returns>
        public static InputController getInstance()
        {
            if (_instance == null) _instance = new InputController();
            return _instance;
        }
    }
}
