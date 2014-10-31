using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarSystem.Exceptions
{
    public class EventDoesNotExistException : KeyNotFoundException
    {
        public override string Message
        {
            get { return base.Message + ": The event does not exist in the storage. You cant update/delete if an event that does not exist"; }
        }
        public EventDoesNotExistException()
        {

        }

        public EventDoesNotExistException(string message)
            : base(message)
        {
        }

        public EventDoesNotExistException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}