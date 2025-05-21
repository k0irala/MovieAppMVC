using FIrst_App.Data;
using FIrst_App.Models;

namespace FIrst_App.Services
{
    public class UserService(MovieContext dbContext)
    {
        public bool getUser(UserModel user)
        {
            var existingUser = dbContext.user.Select(x => x.Id == user.Id && x.Password == user.Password);
            if (existingUser != null)
            {
                return true;
            }
            return false;
        }
    }
}
