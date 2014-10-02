namespace CalendarSystem.Model
{
    /// <summary>
    /// The interface for observing objects. Used to implement the observer pattern, such that the model can notify the view(controller)
    /// </summary>
    public interface IObserver
    {
        /// <summary>
        /// A method which is called from the IObservable objects which the IObserver has observed.
        /// The method notifies that the IObservable has been updated.
        /// </summary>
        void BeNotifiedByObserved();
    }
}