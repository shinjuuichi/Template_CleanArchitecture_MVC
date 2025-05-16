namespace BusinessLogicLayer.Utils
{
    public static class StringUtil
    {
        private const int PASSWORD_LENGTH = 16;

        public static string GenerateRandomPassword()
        {
            const string upperCase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string lowerCase = "abcdefghijklmnopqrstuvwxyz";
            const string digits = "0123456789";
            const string specialCharacters = "@#$%^&";

            Random random = new();

            char[] passwordChars = new char[PASSWORD_LENGTH];
            passwordChars[0] = upperCase[random.Next(upperCase.Length)];
            passwordChars[1] = lowerCase[random.Next(lowerCase.Length)];
            passwordChars[2] = digits[random.Next(digits.Length)];
            passwordChars[3] = specialCharacters[random.Next(specialCharacters.Length)];

            string allCharacters = upperCase + lowerCase + digits + specialCharacters;
            for (int i = 4; i < PASSWORD_LENGTH; i++)
            {
                passwordChars[i] = allCharacters[random.Next(allCharacters.Length)];
            }

            return new string([.. passwordChars.OrderBy(c => random.Next())]);
        }
    }
}
