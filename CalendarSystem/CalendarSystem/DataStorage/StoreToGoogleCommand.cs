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
        private LinkedEventsComposite _linkedEvents;
        public StoreToGoogleCommand(LinkedEventsComposite linkedEvents)
        {
            _linkedEvents = linkedEvents;
        }

        public void Undo()
        {
            // Delete the events that was uploaded
            throw new NotImplementedException();
        }

        public void Execute()
        {
            try
            {
                // upload all the linked events.
            }
            catch (Exception)
            {
                Undo();
            }
        }
    }
}
