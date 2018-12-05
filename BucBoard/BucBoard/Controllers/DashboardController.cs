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
            MultipleModelPass model = new MultipleModelPass();
            UserListModel userList = new UserListModel();
            User tempUser = new Models.User();
            using (bucboardEntities db = new bucboardEntities())
            {
                //Get user model
                tempUser = CreateUser(BucGlobal.BucCurrentUser);
                model.MyUser = tempUser;

                //Get list of users 
                var allUsers = db.Users.ToArray();
                for (int i = 0; i < allUsers.Count(); i++)
                {
                    tempUser = CreateUser(allUsers[0].userID);
                    userList.Teachers.Add(tempUser);
                }
                model.MyUserListModel = userList;
            }
            ViewData["CurrentUser"] = model.MyUser;
            return View(model);
        }

        //Create user object from its ID
        public User CreateUser(int userId)
        {
            using (var db = new bucboardEntities())
            {
                var user = db.Users.SingleOrDefault(x => x.userID == userId);
                if (user != null)
                {
                    //Map user properties
                    return new User
                    {
                        userID = user.userID,
                        firstName = user.firstName,
                        lastName = user.lastName,
                        officeNumber = user.officeNumber,
                        department = user.department,
                        isAdmin = user.isAdmin,
                        email = user.email,
                        password = user.password,
                        confirmPassword = user.confirmPassword,
                    };
                }
                return null;
            }
        }
    }
}