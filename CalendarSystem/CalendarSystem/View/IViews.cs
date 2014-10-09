using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CalendarSystem.View
{
    abstract class IViews
    {
        /// <summary>
        /// shows the view
        /// </summary>
        public abstract void Show();

        /// <summary>
        /// Hides the view
        /// </summary>
        public abstract void Hide();

        /// <summary>
        /// clears the view of data.
        /// </summary>
        public abstract void Clear();
    }
}
