using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BucBoard.Models
{
    public class MultipleModelPass
    {
        //Database models
        public User MyUser { get; set; }
        public Calendar MyCalendar { get; set; }
        public Event MyEvent { get; set; }
        public Alert MyAlert { get; set; }
        public OfficeHour MyOfficeHour { get; set; }

        //Custom models
        public UserListModel MyUserListModel { get; set; }
        public WeekDay MyWeekDay { get; set; }
        public OfficeHourLocal MyOfficeHours { get; set; }
        public DayHours MyDayHours { get; set; }
        public InOffice MyInOffice { get; set; }

        public MultipleModelPass()
        {

        }
    }
}