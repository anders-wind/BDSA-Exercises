using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarSystem.View
{
    /// <summary>
    /// The main view is the container of the other views as well as search bars, properties and so on.
    /// </summary>
    class MainView : IViews
    {
        private CalendarView _calendarView;
        public MainView(CalendarView calendarView)
        {
            _calendarView = calendarView;
        }

        public void Show()
        {
            throw new NotImplementedException();
        }

        public void Hide()
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }
    }
}
