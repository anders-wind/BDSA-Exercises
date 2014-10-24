using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarSystem.Exceptions
{
    public class EventDoesNotExistException : Exception
    {
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