namespace TTDL_Backend.Helpers
{
    public class PasswordHasher
    {
        public static string Hash(string passToHash)
        {
            var Hashed = BCrypt.Net.BCrypt.HashPassword(passToHash);

            return Hashed;
        }

        public static bool Check(string passToCheck, string hash)
        {
            bool result = BCrypt.Net.BCrypt.Verify(passToCheck, hash);

            return result;
        }
    }
}