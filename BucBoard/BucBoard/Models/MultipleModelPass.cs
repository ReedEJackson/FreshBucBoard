using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BucBoard.Models
{
    public class MultipleModelPass
    {
        public UserListModel MyUserListModel { get; set; }
        public User MyUser { get; set; }
        public Calendar MyCalendar { get; set; }
        public Event MyEvent { get; set; }

        public MultipleModelPass()
        {

        }
    }
}