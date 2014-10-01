using System.Collections.Generic;

namespace CalendarSystem.Model
{
    public class Calendar : IObservable
    {
        private IList<IObserver> _Observers = new List<IObserver>();
        private IList<IEvent> _Events = new List<IEvent>();



        public void createCalenderEntry(string description, int month, int day, int startHour, int endHour)
        {
            Event calenderEvent = new Event(description, month, day, startHour, endHour, _Events.Count);
            _Events.Add(calenderEvent);
        }

        public void createCalenderEntry(IEvent newEvent)
        {
            _Events.Add(newEvent);
        }

        public void updateCalenderEntry()
        {

        }
        

        
        public void NotifyObservers()
        {
            foreach (var subscriber in _Observers)
            {
                subscriber.NotifyObserver();
            }
        }

        public void Observe(IObserver observer)
        {
            _Observers.Add(observer);
        }

        public void Observe(IList<IObserver> observers)
        {
            foreach (var observer in observers)
            {
                _Observers.Add(observer);
            }
        }
    }


    

}
