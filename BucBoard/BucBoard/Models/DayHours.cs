using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BucBoard.Models
{
    public class DayHours
    {
        public List<InOffice> DayTimes { get; set; }

        public DayHours()
        {
            DayTimes = new List<InOffice>();
        }
    }
}