using System.Linq;
using System.Web.Mvc;
using System.Web.Helpers;
using BucBoard.Models;
using System.Data;

namespace BucBoard.Controllers
{
    public class BucLoginController : Controller
    {
        // GET: CustomLogin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BucLogin()
        {
            BucGlobal.BucLoggedIn = false;
            return View();
        }

        public ActionResult BucRegister()
        {
            return View();
        }

        [HttpPost]
        public ActionResult BucRegister(User bucUser)
        {
            if (ModelState.IsValid)
            {
                using (bucboardEntities db = new bucboardEntities())
                {
                    //Add user
                    bucUser.userID = 20;
                    db.Users.Add(bucUser);

                    //Add Calendar
                    //Calendar schedule = new Calendar();
                    //db.Calendars.Add(schedule);

                    #region Add Office Hours

                    //OfficeHour officeHRS = new OfficeHour();

                    //officeHRS.day = "Monday";
                    //officeHRS.officeHoursID = 1;
                    //db.OfficeHours.Add(officeHRS);

                    //officeHRS.day = "Tuesday";
                    //officeHRS.officeHoursID = 2;
                    //db.OfficeHours.Add(officeHRS);

                    //officeHRS.day = "Wednesday";
                    //officeHRS.officeHoursID = 3;
                    //db.OfficeHours.Add(officeHRS);

                    //officeHRS.day = "Thursday";
                    //officeHRS.officeHoursID = 4;
                    //db.OfficeHours.Add(officeHRS);

                    //officeHRS.day = "Friday";
                    //officeHRS.officeHoursID = 5;
                    //db.OfficeHours.Add(officeHRS);

                    #endregion

                    #region Add Alerts

                    //Alert myAlert = new Alert();

                    //myAlert.alertID = 1;
                    //myAlert.alertName = "Gone to lunch";
                    //myAlert.isOn = 0;
                    //db.Alerts.Add(myAlert);

                    //myAlert.alertID = 2;
                    //myAlert.alertName = "Out of Office";
                    //myAlert.isOn = 0;
                    //db.Alerts.Add(myAlert);

                    //myAlert.alertID = 3;
                    //myAlert.alertName = "";
                    //myAlert.isOn = 0;
                    //db.Alerts.Add(myAlert); 

                    #endregion

                    //Save Changes to finalize registration
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = bucUser.firstName + " " + bucUser.lastName + " was successfully created!";
                return RedirectToAction("Dashboard", "Dashboard");
            }
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult BucLogin(User bucUser)
        {
            BucGlobal.BucLoggedIn = false;
            BucGlobal.BucCurrentUser = -1;
            using (bucboardEntities db = new bucboardEntities())
            {
                var bucUsr = db.Users.Where(u => u.email == bucUser.email && u.password == bucUser.password).FirstOrDefault();
                if (bucUsr != null)
                {
                    Session["userID"] = bucUsr.userID.ToString();
                    Session["userIDNum"] = bucUsr.userID;
                    Session["email"] = bucUsr.email.ToString();
                    return RedirectToAction("BucLoggedIn");
                }
                else
                {
                    ModelState.AddModelError("", "Email or Password is incorrect.");
                }
            }
            return View();
        }

        public ActionResult BucLoggedIn()
        {
            if (Session["userID"] != null)
            {
                BucGlobal.BucLoggedIn = true;
                BucGlobal.BucCurrentUser = (int)Session["userIDNum"];
                return RedirectToAction("Dashboard", "Dashboard");
            }
            else
            {
                return RedirectToAction("BucLogin");
            }
        }

        private string HashPassword(string pass)
        {
            string salt = Crypto.GenerateSalt();

            string hashedPassword = Crypto.HashPassword(salt + pass);
            return hashedPassword;
        }
    }
}