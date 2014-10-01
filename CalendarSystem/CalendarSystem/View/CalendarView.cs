using CalendarSystem.Model;

namespace CalendarSystem.View
{
    class CalendarView : IObserver
    {
        private OverviewType currentOverviewType;
        public enum OverviewType
        {
            montly, 
            weekly, 
            daily
        }
        public void changeOverviewType(OverviewType overviewType) // Muligvis til en controller class (view fremstiller data, manipulere ikke med data)
        {
            currentOverviewType = overviewType;
        }

        public void NotifyObserver()
        {
            throw new System.NotImplementedException();
        }
    }
}
