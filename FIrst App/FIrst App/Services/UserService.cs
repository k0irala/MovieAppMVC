using System.Runtime.ConstrainedExecution;
using FIrst_App.Data;
using FIrst_App.Enums;
using FIrst_App.Models;

namespace FIrst_App.Services
{
    public class UserService(MovieContext dbContext)
    {
        public const int USER_ROLE = (int)Roles.User;
        public const int ADMIN_ROLE = (int)Roles.Admin;
        public bool getUser(UserModel user)
        {
            bool existingUser = dbContext.user.Any(x => x.Username == user.Username && x.Password == user.Password && x.Roles == USER_ROLE);
            return existingUser;
        }

        public bool getAdmin(UserModel user)
        {
            bool existingAdmin = dbContext.user.Any(x => x.Username == user.Username && x.Password == user.Password && x.Roles == ADMIN_ROLE);
            return existingAdmin;
        }
    }
}
