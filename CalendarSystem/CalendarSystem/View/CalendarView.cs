using CalendarSystem.Model;

namespace CalendarSystem.View
{
    class CalendarView : IObserver
    {
        private enum OverviewType
        {
            montly, 
            weekly, 
            daily
        }
        public void changeOverviewType() // Muligvis til en controller class (view fremstiller data, manipulere ikke med data)
        {
            throw new System.NotImplementedException();
        }

        public void NotifyObserver()
        {
            throw new System.NotImplementedException();
        }
    }
}
