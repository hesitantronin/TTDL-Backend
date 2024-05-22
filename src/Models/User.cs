namespace TTDL_Backend.Models
{
    public class User
    {
        public Guid user_id { get; set; }
        public string uname { get; set; }

        public string password { get; set; }

        public User(string Uname, string Password)
        {
            user_id = Guid.NewGuid();
            uname = Uname;
            password = Password;
        }

    }
}
