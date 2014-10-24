using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarSystem.Exceptions
{
    public class UsernamePasswordMismatchException : Exception
    {
        public UsernamePasswordMismatchException()
        {

        }

        public UsernamePasswordMismatchException(string message)
            : base(message)
        {
        }

        public UsernamePasswordMismatchException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
