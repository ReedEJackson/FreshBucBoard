using BucBoard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BucBoard.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Appointment()
        {
            ViewBag.Message = "Schedule Bucpointment";
            LoadAppointments appts = new LoadAppointments();
            List<SelectListItem> ApptTimes = new List<SelectListItem>();
            List<OfficeHour> appointments = appts.GetAppointments();
            string StartTimeH;
            string StartTimeM;
            string EndTimeH;
            string EndTimeM;
            foreach (OfficeHour e in appointments)
            {
                StartTimeH = e.startingHours.ToString();
                if (e.startingMinutes == 0)
                    StartTimeM = "00";
                else
                    StartTimeM = e.startingMinutes.ToString();

                EndTimeH = e.endingHours.ToString();
                if (e.endingMinutes == 0)
                    EndTimeM = "00";
                else
                    EndTimeM = e.endingMinutes.ToString();

                ApptTimes.Add(new SelectListItem { Text = e.day + ": " + StartTimeH + ":" + StartTimeM + "PM" + " - " + EndTimeH + ":" + EndTimeM + "PM", Value = e.officeHoursID.ToString() });
            }

            ViewBag.Appts = ApptTimes;
            ViewBag.SelectedItem = "";
            return View();
        }

        [HttpPost]
        public void ScheduleAppt()
        {
            string StuId, StuEmail, ApptTime;

            StuId = Request["ID"];
            StuEmail = Request["Sender"];
            ApptTime = Request["ApptNumber"];

            using (bucboardEntities db = new bucboardEntities())
            {
                OfficeHour EntryToUpdate = db.OfficeHours.Where(entry => entry.officeHoursID.ToString() == ApptTime).FirstOrDefault();
                if (EntryToUpdate != default(OfficeHour))
                    EntryToUpdate.isAvailable = 1;
                db.SaveChanges();
            }


        }

        public ActionResult Email()
        {
            ViewBag.Message = "Send Buc-mail";

            List<string> SubOptions = new List<string>();
            List<SelectListItem> Options = new List<SelectListItem>();
            Options.Add(new SelectListItem { Text = "Need an appointment", Value = "Needs an appointment" });
            Options.Add(new SelectListItem { Text = "Need help with assignment", Value = "Need help with assignment" });
            Options.Add(new SelectListItem { Text = "Missed you in office", Value = "Missed you in office" });
            Options.Add(new SelectListItem { Text = "Other", Value = "Other" });

            ViewBag.Subjects = Options;


            return View();
        }

        [HttpPost]
        public ActionResult SendEmailView()
        {


            return View();
        }
    }
}