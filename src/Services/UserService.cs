using TTDL_Backend.Models;

namespace TTDL_Backend.Services
{
    public class Userservice : IUserservice
    {
        private readonly T_DbContext _DbContext;

        public Userservice(T_DbContext dbContext)
        {
            _DbContext = dbContext;
        }

        public User? GetUserByUname(string uname)
        {
            User result =_DbContext.Users.FirstOrDefault(u => u.Uname == uname);

            return result;
        }

        public bool RegisterUser(User user)
        {
            User newUser = user;

            try
            {
                _DbContext.Users.Add(newUser);
                _DbContext.SaveChanges();
                return true;
            }

            catch (Exception ex)
            {
                System.Console.WriteLine($"Error adding user to db: {ex}");
                return false;
            }
        }
    }
}