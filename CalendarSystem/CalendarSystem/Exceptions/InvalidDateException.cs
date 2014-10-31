using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarSystem.Exceptions
{
    class InvalidDateException : Exception
    {
        public InvalidDateException()
        {

        }

        public InvalidDateException(string message)
            : base(message)
        {
        }

        public InvalidDateException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
