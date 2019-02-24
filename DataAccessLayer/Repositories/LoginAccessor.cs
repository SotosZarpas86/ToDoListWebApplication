using DataAccessLayer;
using DataLayer.Entities;
using System;
using System.Linq;

namespace DataLayer.Repositories
{
    public class LoginAccessor : ILoginAccessor
    {
        public User Login(User user)
        {
            try
            {
                using (var ctx = new ToDoListContext())
                {
                    var result = ctx.Users.SingleOrDefault(u => u.Username.Equals(user.Username) && u.Password.Equals(user.Password));
                    if (result.UserID != 0)
                    {
                        user.UserID = result.UserID;
                        user.Tasks = ctx.Tasks.Where(t => t.UserId == result.UserID).ToList();
                    }
                        
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return user;
        }
    }
}
