using TTDL_Backend.Services;

namespace TTDL_Backend.Tests.Services
{
    public class Testuserservice : IUserservice
    {

        public User GetUser() => new(1 , "TESTUSER");

        public User RegisterUser(string user = "kees") => new(1, user);

        public string isEndpointOnline(int responseCode)
        {
            if(responseCode != 200) return "this endpoint is currently not availabele...";

            return "this endpoint is ready!";
        }
    }
}
