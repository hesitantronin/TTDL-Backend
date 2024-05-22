using TTDL_Backend.Models;

namespace TTDL_Backend.Services
{
    public interface IUserservice
    {
        public User GetUser();

        public User RegisterUser(string Uname, string Password);
    }
}
