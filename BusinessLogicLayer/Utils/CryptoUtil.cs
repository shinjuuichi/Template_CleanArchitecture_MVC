namespace BusinessLogicLayer.Utils
{
    public class CryptoUtil
    {
        public static string EncryptPassword(string? password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public static bool IsPasswordCorrect(string? password, string? passwordHashed)
        {
            return !string.IsNullOrEmpty(password)
                && !string.IsNullOrEmpty(passwordHashed)
                && BCrypt.Net.BCrypt.Verify(password, passwordHashed);
        }
    }
}
