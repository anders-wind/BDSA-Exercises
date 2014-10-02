using CalendarSystem.Controller;
using CalendarSystem.DataStorage;
using CalendarSystem.Model;
using CalendarSystem.View;

namespace CalendarSystem
{
    static class Startup
    {
        private static void Main(string[] args)
        {
            InputController.getInstance();
            LoginView loginView = new LoginView();
            // wait for login to succeed.
        }
    }
}
