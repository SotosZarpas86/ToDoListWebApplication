using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Models
{
    public class UserModel
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public List<TasksModel> Tasks { get; set; }
    }
}
