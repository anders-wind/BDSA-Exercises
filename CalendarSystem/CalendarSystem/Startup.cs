using CalendarSystem.Controller;
using CalendarSystem.DataStorage;
using CalendarSystem.Model;
using CalendarSystem.View;

namespace CalendarSystem
{
    internal class Startup
    {
        private static void Main(string[] args)
        {
            LoginView loginView = new LoginView();
            // wait for login to succeed.


            ViewController viewController = new ViewController();
            InputController inputController = InputController.getInstance();
            NotificationController notificationController = new NotificationController();
        }
    }
}
