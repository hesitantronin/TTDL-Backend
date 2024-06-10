using TTDL_Backend.Models;

namespace TTDL_Backend.Services
{
    public interface IPatientservice
    {
        public bool LoginUser(string uname, string password);

        public bool RegisterUser(User user);
    }
}
