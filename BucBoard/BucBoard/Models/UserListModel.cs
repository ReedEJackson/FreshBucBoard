using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BucBoard.Models
{
    public class UserListModel
    {
        public List<User> Teachers { get; set; }

        public UserListModel()
        {

        }
        public UserListModel(List<User> inputList)
        {
            Teachers.AddRange(inputList);
        }
    }
}