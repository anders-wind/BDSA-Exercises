using System.Collections.Generic;

namespace CalendarSystem.Model
{
    public class Calendar
    {
        private IList<IObserver> _Observers = new List<IObserver>();
        private IList<Event> _Events = new List<Event>();



        public void createCalenderEntry(int month, int day, int startHour, int startMinute, int endHour, int endMinute)
        {
            Event CalenderEvent = new Event(month, day, startHour, startMinute, endHour, endMinute);
            _Events.Add(CalenderEvent);
        }

        public void updateCalenderEntry()
        {

        }
        

        
        private void NotifyObservers()
        {
            foreach (var subscriber in _Observers)
            {
                subscriber.NotifyObserver();
            }
        }

        public void Subscribe(IObserver observer)
        {
            _Observers.Add(observer);
        }
    }


    

}
