using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarSystem.Model
{
    /// <summary>
    /// The interface for observable objects. Used to implement the observer pattern, such that the model can notify the view(controller)
    /// </summary>
    interface IObservable
    {
        /// <summary>
        /// Notify observers that a change has happened.
        /// </summary>
        void NotifyObservers();
        /// <summary>
        /// Become observed by an object which class has implemented IObserver
        /// </summary>
        /// <param name="observer"></param>
        void BeObserved(IObserver observer);
        /// <summary>
        /// Be observed by a list of IObserver(s).
        /// </summary>
        /// <param name="observers"></param>
        void BeObserved(IList<IObserver> observers);
    }
}
