using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarSystem.Exceptions
{
    class BeginDateIsLesserThanEndDateException : InvalidDateException
    {
        public override string Message
        {
            get { return base.Message + ": The begin date given was at a later point than the enddate"; }
        }

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
