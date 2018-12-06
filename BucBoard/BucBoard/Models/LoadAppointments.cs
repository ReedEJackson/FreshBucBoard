using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BucBoard.Models;

namespace BucBoard.Models
{
    public class LoadAppointments
    {
        public LoadAppointments()
        {

        }

        public List<OfficeHour> GetAppointments()
        {
            List<OfficeHour> OfficeHours = new List<OfficeHour>();
            using (bucboardEntities db = new bucboardEntities())
            {
                OfficeHours = db.OfficeHours.Where(entry => entry.isAvailable == 0).ToList();

            }
            return OfficeHours;
        }
    }
}