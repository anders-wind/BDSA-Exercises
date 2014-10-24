using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarSystem.Exceptions
{
    class FaultyIDException : Exception
    {
        public FaultyIDException()
        {

        }

        public FaultyIDException(string message)
            : base(message)
        {
        }

        public FaultyIDException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
