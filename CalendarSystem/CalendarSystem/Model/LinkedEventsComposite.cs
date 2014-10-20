using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarSystem.Model
{
    class LinkedEventsComposite : IComponentComposite, IEnumerable<IComponentComposite>
    {
        private IList<IComponentComposite> _children = new List<IComponentComposite>();
        
        
        public void AddEvent(IComponentComposite anEvent)
        {
            _children.Add(anEvent);
        }
        public void AddRangeOfEvent(IList<IComponentComposite> someEvents)
        {
            _children.Concat(someEvents);
        }

        public void removeEvent(IComponentComposite eventToRemove)
        {
            _children.Remove(eventToRemove);
        }

        public IComponentComposite getChild(int index)
        {
            return _children[index];
        }

        public IEnumerator<IComponentComposite> GetEnumerator()
        {
            foreach (IComponentComposite child in _children)
                yield return child;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
