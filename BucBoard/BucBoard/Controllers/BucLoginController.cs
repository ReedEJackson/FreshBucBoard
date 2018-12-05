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
                    db.Users.Add(bucUser);
                    //db.Calendars.Add();
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = bucUser.firstName + " " + bucUser.lastName + " was successfully created!";
            }
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult BucLogin(User bucUser)
        {
            BucGlobal.BucLoggedIn = false;
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BucLogOff()
        {
            //AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            BucGlobal.BucLoggedIn = false;
            BucGlobal.BucCurrentUser = -1;
            return RedirectToAction("CustomLogin", "CustomLogin");
        }

        private string HashPassword(string pass)
        {
            string salt = Crypto.GenerateSalt();

            string hashedPassword = Crypto.HashPassword(salt + pass);
            return hashedPassword;
        }
    }
}