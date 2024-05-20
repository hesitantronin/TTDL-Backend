namespace TTDL_Backend.Services
{
    public class Userservice : IUserservice
    {
        public User GetUser()
        {
            return new(1, "Boe");
        }

        public User RegisterUser(string user)
        {
            return new(2, user);
        }
        
    }
}