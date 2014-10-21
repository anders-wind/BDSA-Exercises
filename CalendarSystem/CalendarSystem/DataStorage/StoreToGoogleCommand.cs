using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalendarSystem.Model;

namespace CalendarSystem.DataStorage
{
    class StoreToGoogleCommand : IUndoableCommand
    {
        private IEvent _iEvent;
        public StoreToGoogleCommand(IEvent iEvent) /// google adapter pattern
        {
            _iEvent = iEvent;
        }

        public void Undo()
        {
            // Delete the events that was uploaded
        }

        public void Execute()
        {
            try
            {
                // upload the event
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
