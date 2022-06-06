using System;
namespace Core.Utilities.Security.Naming
{
    public class Naming
    {
        public static string CreateUserName(string firstName,string lastName)
        {
            var firstLetter = char.ToLower(firstName[0]);

            var last = FirstCharacterToLower(lastName);

            var number = Number();

            string userName = firstLetter + last + number;

            return userName;


        }

        public static string FirstCharacterToLower(string str)
        {
            if (String.IsNullOrEmpty(str) || Char.IsLower(str, 0))
            {
                return str;
            }

            return Char.ToLowerInvariant(str[0]) + str.Substring(1);
        }

        public static string Number()
        {
            Random random = new Random();
            string value = Convert.ToString(random.Next(0, 100));
            return value;
        }
    }
}
