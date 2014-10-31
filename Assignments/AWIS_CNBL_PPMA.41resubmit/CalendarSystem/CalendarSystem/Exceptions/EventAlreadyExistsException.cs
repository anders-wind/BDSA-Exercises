using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarSystem.Exceptions
{
    public class EventAlreadyExistsException : Exception
    {
        public override string Message
        {
            get { return base.Message + "The event already exists in the storage. You cant save if an event already exists with the same ID"; }
        }
        public EventAlreadyExistsException()
        {

        }

        public EventAlreadyExistsException(string message)
            : base(message)
        {
        }

        public EventAlreadyExistsException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
