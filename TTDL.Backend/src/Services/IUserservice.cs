using TTDL_Backend.Models;

namespace TTDL_Backend.Services
{
    public interface IUserservice
    {
        public User? GetUserByUname(string uname);

        public bool LoginUser(string uname, string password);

        public bool RegisterUser(User user);
    }
}
