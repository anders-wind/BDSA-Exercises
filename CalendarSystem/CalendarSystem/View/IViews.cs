using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CalendarSystem.View
{
    interface IViews
    {
        /// <summary>
        /// shows the view
        /// </summary>
        void Show();

        /// <summary>
        /// Hides the view
        /// </summary>
        void Hide();

        /// <summary>
        /// clears the view of data.
        /// </summary>
        void Clear();
    }
}
