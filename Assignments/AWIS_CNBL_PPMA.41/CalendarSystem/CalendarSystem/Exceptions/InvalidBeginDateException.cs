using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarSystem.Exceptions
{
    class InvalidBeginDateException : Exception
    {
        public InvalidBeginDateException()
        {

        }

        public InvalidBeginDateException(string message)
            : base(message)
        {
        }

        public InvalidBeginDateException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
