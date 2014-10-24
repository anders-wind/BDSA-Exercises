using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarSystem.Exceptions
{
    class InvalidEndDateException : Exception
    {
        public InvalidEndDateException()
        {

        }

        public InvalidEndDateException(string message)
            : base(message)
        {
        }

        public InvalidEndDateException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
