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
        void BeObserved(IObserver observer);
        void BeObserved(IList<IObserver> observers);
    }
}
