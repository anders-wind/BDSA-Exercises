﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class Notification
    {
        private DateTime date; //date for notification
        private TimeSpan startTime; //start time for notification
        private TimeSpan endTime; //end time for notification
        private String nd; //notification description
        private Tag nt; //notification tag (skal evt. være en liste?, kan en notification have flere tags?)

        // getters og setters for date, startTime, endTime, nd (notification description) og nt (notification tag)
    }
}
