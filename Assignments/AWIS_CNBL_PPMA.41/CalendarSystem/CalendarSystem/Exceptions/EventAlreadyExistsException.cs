using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarSystem.Exceptions
{
    public class EventAlreadyExistsException : Exception
    {
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
