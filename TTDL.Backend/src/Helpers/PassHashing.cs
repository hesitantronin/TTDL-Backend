namespace TTDL_Backend.Helpers
{
    // Maybe unnecessary abstraction, but thats ok eheheh :)
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