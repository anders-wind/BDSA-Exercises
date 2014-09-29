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
            User user = loginView.GetUser();


            ViewController viewController = new ViewController();
            InputController inputController = InputController.getInstanceSafe(new FakeStorage(), user);
            NotificationController notificationController = new NotificationController();
        }
    }
}
