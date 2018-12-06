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

        }
        public OfficeHourLocal(bool empty)
        {
            WeekDays = new DayHours[5];

            for (int i = 0; i < WeekDays.Count(); i++)
            {
                if (empty)
                {
                    WeekDays[i] = new DayHours(empty);
                }
                else
                {
                    WeekDays[i] = new DayHours(empty);
                }
            }
        }
        public OfficeHourLocal(OfficeHourLocal ohl)
        {
            WeekDays = new DayHours[5];
            for (int i = 0; i < 5; i++)
            {
                WeekDays[i] = ohl.WeekDays[i];
            }
        }
    }
}