using BucBoard.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
            #region Get office hours

            OfficeHourLocal MyOfficeHours = new OfficeHourLocal();
            InOffice tempTime;

            string connectionString = @"Data Source=bucboard.database.windows.net;Initial Catalog=bucboard;User ID=bucboard;Password=se2fall2018!;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection connection = new SqlConnection(connectionString);
            using (SqlCommand command = new SqlCommand(""))
            {
                int x;
                command.Connection = connection;
                connection.Open();

                command.CommandText = "SELECT * FROM OfficeHours WHERE userID = 1 AND day = 'Monday'";
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                foreach (DataRow col in table.Rows)
                {
                    tempTime = new InOffice((int)col[1], (int)col[2], )
                    MyOfficeHours.WeekDays[0].DayTimes.Add();
                    //Start time
                    x = (int)col[1];
                    x = (int)col[3];

                    //End time
                    x = (int)col[2];
                    x = (int)col[4];
                }

                connection.Close();
            } 

            #endregion

            MultipleModelPass model = new MultipleModelPass();
            User tempUser = new Models.User();
            using (bucboardEntities db = new bucboardEntities())
            {
                //Get current user
                tempUser = CreateUser(BucGlobal.BucCurrentUser);
                model.MyUser = tempUser;

                //Get office days
                var officeDay = db.OfficeHours.Where(u => u.userID == BucGlobal.BucCurrentUser).FirstOrDefault();

                for (int i = 0; i < 5; i++)
                {
                    
                }
                //Get office times
                //Get office time values

            }
            model.MyWeekDay = new WeekDay();
            return View(model);
        }

        public ActionResult Manage()
        {
            MultipleModelPass model = new MultipleModelPass();
            UserListModel userList = new UserListModel();
            User tempUser = new Models.User();
            using (bucboardEntities db = new bucboardEntities())
            {
                //Get list of users 
                var allUsers = db.Users.ToArray();
                
                for (int i = 0; i < allUsers.Count(); i++)
                {
                    tempUser = CreateUser(allUsers[0].userID);
                    userList.Teachers.Add(tempUser);
                }
                model.MyUserListModel = userList;
            }
            
            return View(model);
        }

        //Create user object from its ID
        public User CreateUser(int userId)
        {
            using (bucboardEntities db = new bucboardEntities())
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

        public User CreateOfficeHours(int userId)
        {
            using (bucboardEntities db = new bucboardEntities())
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