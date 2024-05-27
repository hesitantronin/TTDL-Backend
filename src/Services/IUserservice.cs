using TTDL_Backend.Models;

namespace TTDL_Backend.Services
{
    public interface IUserservice
    {
        public User? GetUserByUname(string uname);

        public bool RegisterUser(string Uname, string Password);
    }
}
