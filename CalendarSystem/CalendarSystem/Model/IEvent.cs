﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarSystem.Model
{
    public interface IEvent
    {
        Notification _notification { get; set; }
        DateTime _date  { get; set; }
        TimeSpan _timeSpan { get; set; }
        string _description { get; set; }
        int _ID { get; }


        void changeTag(Tag tag);
    }
}