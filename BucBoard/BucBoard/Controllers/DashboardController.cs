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
            MultipleModelPass model = new MultipleModelPass();

            #region Get office hours

            OfficeHourLocal MyOfficeHours = new OfficeHourLocal(true);
            InOffice tempTime;
            string query = "SELECT * FROM OfficeHours WHERE userID = " + BucGlobal.BucCurrentUser + " AND day = '";

            string connectionString = @"Data Source=bucboard.database.windows.net;Initial Catalog=bucboard;User ID=bucboard;Password=se2fall2018!;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection connection = new SqlConnection(connectionString);
            using (SqlCommand command = new SqlCommand(""))
            {
                command.Connection = connection;
                connection.Open();

                #region Monday

                command.CommandText = query + "Monday'";
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                foreach (DataRow col in table.Rows)
                {
                    tempTime = new InOffice((int)col[1], (int)col[2], (int)col[3], (int)col[4]);
                    MyOfficeHours.WeekDays[0].DayTimes.Add(tempTime);
                }

                #endregion

                #region Tuesday

                command.CommandText = query + "Tuesday'";
                adapter = new SqlDataAdapter(command);
                table = new DataTable();
                adapter.Fill(table);
                foreach (DataRow col in table.Rows)
                {
                    tempTime = new InOffice((int)col[1], (int)col[2], (int)col[3], (int)col[4]);
                    MyOfficeHours.WeekDays[1].DayTimes.Add(tempTime);
                }

                #endregion

                #region Wednesday

                command.CommandText = query + "Wednesday'";
                adapter = new SqlDataAdapter(command);
                table = new DataTable();
                adapter.Fill(table);
                foreach (DataRow col in table.Rows)
                {
                    tempTime = new InOffice((int)col[1], (int)col[2], (int)col[3], (int)col[4]);
                    MyOfficeHours.WeekDays[2].DayTimes.Add(tempTime);
                }

                #endregion

                #region Thursday

                command.CommandText = query + "Thursday'";
                adapter = new SqlDataAdapter(command);
                table = new DataTable();
                adapter.Fill(table);
                foreach (DataRow col in table.Rows)
                {
                    tempTime = new InOffice((int)col[1], (int)col[2], (int)col[3], (int)col[4]);
                    MyOfficeHours.WeekDays[3].DayTimes.Add(tempTime);
                }

                #endregion

                #region Friday

                command.CommandText = query + "Friday'";
                adapter = new SqlDataAdapter(command);
                table = new DataTable();
                adapter.Fill(table);
                foreach (DataRow col in table.Rows)
                {
                    tempTime = new InOffice((int)col[1], (int)col[2], (int)col[3], (int)col[4]);
                    MyOfficeHours.WeekDays[4].DayTimes.Add(tempTime);
                }

                #endregion

                connection.Close();
            }
            //Sort times
            for (int i = 0; i < MyOfficeHours.WeekDays.Length; i++)
            {
                MyOfficeHours.WeekDays[i].SortList();
            }

            #endregion

            model.MyOfficeHourLocal = MyOfficeHours;

            User tempUser = new Models.User();
            using (bucboardEntities db = new bucboardEntities())
            {
                //Get current user
                tempUser = CreateUser(BucGlobal.BucCurrentUser);
                model.MyUser = tempUser;
            }
            model.MyWeekDay = new WeekDay();
            model.MyDayHours = new DayHours(false);
            return View(model);
        }

        public ActionResult _BucOfficeHours(OfficeHourLocal bucInput)
        {
            if (ModelState.IsValid)
            {

                if (bucInput != null && bucInput.WeekDays != null)
                {
                    using (bucboardEntities db = new bucboardEntities())
                    {
                        OfficeHour newOfficeHour = new OfficeHour();
                        bool saveProgress = false;
                        for (int i = 0; i < 1; i++)
                        {
                            InOffice temp = new InOffice();
                            temp.StartHour = ValidateHour(bucInput.WeekDays[i].DayTimes[i].StartHourStr);
                            temp.StartMin = ValidateMin(bucInput.WeekDays[i].DayTimes[i].StartMinStr);
                            temp.EndHour = ValidateHour(bucInput.WeekDays[i].DayTimes[i].EndHourStr);
                            temp.EndMin = ValidateMin(bucInput.WeekDays[i].DayTimes[i].EndMinStr);
                            if (temp.StartHour == -1 ||
                                temp.StartMin == -1 ||
                                temp.EndHour == -1 ||
                                temp.EndMin == -1)
                            {
                                ModelState.AddModelError("", "Make sure your values are in the ##:## - ##:## format.");
                            }
                            else if (false)
                            {
                                //bucInput.MyDayHours.AddNewTime(temp)
                                ModelState.AddModelError("", "Make sure your time is not conflicting with other times.");
                            }
                            else
                            {
                                bucInput.WeekDays[i].DayTimes.Add(temp);
                                newOfficeHour.startingHours = temp.StartHour;
                                newOfficeHour.startingMinutes = temp.StartMin;
                                newOfficeHour.endingHours = temp.EndHour;
                                newOfficeHour.endingMinutes = temp.EndMin;
                                switch (i)
                                {
                                    case 0:
                                        newOfficeHour.day = "Monday";
                                        break;
                                    case 1:
                                        newOfficeHour.day = "Tuesday";
                                        break;
                                    case 2:
                                        newOfficeHour.day = "Wednesday";
                                        break;
                                    case 3:
                                        newOfficeHour.day = "Thursday";
                                        break;
                                    case 4:
                                        newOfficeHour.day = "Friday";
                                        break;
                                    default:
                                        break;
                                }
                                newOfficeHour.userID = BucGlobal.BucCurrentUser;
                                saveProgress = true;
                            }
                        }
                        if (saveProgress)
                        {
                            db.SaveChanges();
                        }
                    }  
                }
                else
                {
                    return PartialView();
                }
            }
            ModelState.Clear();
            return PartialView(bucInput);
        }

        public int ValidateHour(string str)
        {
            int hr;
            try
            {
                hr = Convert.ToInt32(str);
            }
            catch (Exception)
            {
                return -1;
            }

            if (hr >= 0 && hr <= 24)
            {
                return hr;
            }
            else
            {
                return -1;
            }
        }

        public int ValidateMin(string str)
        {
            int min;
            try
            {
                min = Convert.ToInt32(str);
            }
            catch (Exception)
            {
                return -1;
            }

            if (min >= 0 && min <= 60)
            {
                return min;
            }
            else
            {
                return -1;
            }
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