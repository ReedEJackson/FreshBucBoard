using BucBoard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BucBoard.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Dashboard()
        {
            UserListModel userList = new UserListModel();
            using (bucboardEntities db = new bucboardEntities())
            {
                foreach (var teacher in db.Users)
                {
                    userList.Teachers.Add(teacher);
                }
            }
            return View(userList);
        }
    }
}