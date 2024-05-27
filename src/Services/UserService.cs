using TTDL_Backend.Models;

namespace TTDL_Backend.Services
{
    public class Userservice : IUserservice
    {
        public User GetUser()
        {
            return new User{};
        }

        public User RegisterUser(string Uname, string Password)
        {
            throw new NotImplementedException();
        }
    }
}