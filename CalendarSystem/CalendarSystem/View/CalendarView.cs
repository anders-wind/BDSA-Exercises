using CalendarSystem.Model;

namespace CalendarSystem.View
{
    /// <summary>
    /// The calendar view visually represents the calendar of events in the storage
    /// </summary>
    class CalendarView : IViews
    {
        private OverviewType currentOverviewType;
        /// <summary>
        /// An enum type of the different kinds of views.
        /// </summary>
        public enum OverviewType
        {
            montly, 
            weekly, 
            daily
        }
        /// <summary>
        /// Change the way the events are shown on screen
        /// </summary>
        /// <param name="overviewType"></param>
        public void changeOverviewType(OverviewType overviewType) // Muligvis til en controller class (view fremstiller data, manipulere ikke med data)
        {
            currentOverviewType = overviewType;
        }

        public override void Show()
        {
            throw new System.NotImplementedException();
        }

        public override void Hide()
        {
            throw new System.NotImplementedException();
        }

        public override void Clear()
        {
            throw new System.NotImplementedException();
        }
    }
}
