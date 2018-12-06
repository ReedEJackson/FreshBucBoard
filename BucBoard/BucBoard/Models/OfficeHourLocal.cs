using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BucBoard.Models
{
    public class OfficeHourLocal
    {
        public DayHours[] WeekDays { get; set; }
        public OfficeHourLocal()
        {
            WeekDays = new DayHours[5];
            for (int i = 0; i < WeekDays.Count(); i++)
            {
                WeekDays[i] = new DayHours();
            }
        }
    }
}