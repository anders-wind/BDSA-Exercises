using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View;

namespace Model
{
    public class Calendar
    {
        private IList<ISubscriber> subscribers = new List<ISubscriber>();
        private IList<Event> events = new List<Event>();

        
        
        
        
        
        
        
        
        
        private void notifySubscribers()
        {
            foreach (var subscriber in subscribers)
            {
                subscriber.Notify();
            }
        }

        public void Subscribe(ISubscriber subscriber)
        {
            subscribers.Add(subscriber);
        }
    }


    

}
