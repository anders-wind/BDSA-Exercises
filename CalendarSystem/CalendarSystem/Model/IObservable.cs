using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarSystem.Model
{
    interface IObservable
    {
        void NotifyObservers();
        void Observe(IObserver observer);
        void Observe(IList<IObserver> observers);
    }
}
