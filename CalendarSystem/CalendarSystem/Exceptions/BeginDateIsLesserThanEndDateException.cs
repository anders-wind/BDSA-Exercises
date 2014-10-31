using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarSystem.Exceptions
{
    class BeginDateIsLesserThanEndDateException : InvalidDateException
    {
        public BeginDateIsLesserThanEndDateException()
        {

        }

        public BeginDateIsLesserThanEndDateException(string message)
            : base(message)
        {
        }

        public BeginDateIsLesserThanEndDateException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
