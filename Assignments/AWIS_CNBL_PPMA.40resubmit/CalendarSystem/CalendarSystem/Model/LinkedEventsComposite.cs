using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarSystem.Model
{
    class LinkedEventsComposite : IEvent, IEnumerable<IEvent>
    {
        private IList<IEvent> _children = new List<IEvent>();


        public void AddEvent(IEvent anEvent)
        {
            _children.Add(anEvent);
        }
        public void AddRangeOfEvent(IList<IEvent> someEvents)
        {
            _children.Concat(someEvents);
        }

        public void removeEvent(IEvent eventToRemove)
        {
            _children.Remove(eventToRemove);
        }

        public IEvent getChild(int index)
        {
            return _children[index];
        }

        public IEnumerator<IEvent> GetEnumerator()
        {
            foreach (IEvent child in _children)
                yield return child;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public Notification _notification
        {
            get{throw new Exception();}
            set{ throw new Exception(); }
        }
        /// <summary>
        /// functions as next events date
        /// </summary>
        public DateTime ?_date
        {
            get
            {
                DateTime ?tempDate = null;
                foreach (var iEvent in this)
                {
                    if (tempDate == null || iEvent._date < tempDate) tempDate = iEvent._date;
                }
                return tempDate;
            }
            set { throw new Exception(); }
        }
        public TimeSpan ?_timeSpan
        {
            get
            {
                DateTime? startDate = null;
                DateTime? endDate = null;
                foreach (var iEvent in this)
                {
                    if (startDate == null || iEvent._date < startDate) startDate = iEvent._date;
                    if (endDate == null || iEvent._date > endDate) endDate = iEvent._date;
                }
                return endDate.Value - startDate.Value;
            }
            set { throw new Exception(); }
        }
        public string _description
        {
            get { throw new Exception(); }
            set { throw new Exception(); }
        }
        public int _ID
        {
            get { throw new Exception(); }
            set { throw new Exception(); }
        }
        public int tag
        {
            get { throw new Exception(); }
            set { throw new Exception(); }
        }
    }
}
