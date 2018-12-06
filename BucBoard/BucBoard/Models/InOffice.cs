using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BucBoard.Models
{
    public class InOffice
    {
        public int StartHour { get; set; }
        public int EndHour { get; set; }
        public int StartMin { get; set; }
        public int EndMin { get; set; }
        public InOffice(int startHR, int startMN, int endHR, int endMN)
        {
            StartHour = startHR;
            StartMin = startMN;
            EndHour = endHR;
            EndMin = endMN;
        }
    }
}