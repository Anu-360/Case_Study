using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.Win32;

using System.Text.RegularExpressions;


namespace Project_Management.Model
{
    public class User
    {
        string username;
        string password;
        string email;

        public string Username
        {
            get { return username; }
            set { username = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public User() { }

        public static bool IsValidEmail(string email)
        {
           
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

           
            Regex regex = new Regex(pattern);

           
            return regex.IsMatch(email);
        }
    }
}
    

    

