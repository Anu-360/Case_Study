using Project_Management.Dao;
using Project_Management.Model;

namespace Project_Management.Service
{
    internal class UserService
    {
        readonly ProjectRepositoryImpl projectrepositoryImpl;
        public UserService()
        {
            projectrepositoryImpl = new ProjectRepositoryImpl();
        }
        public bool Login(string username, string password)
        {
            bool userlogin = projectrepositoryImpl.Login(username,password);
            if(userlogin==true) 
            {
                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine("Login Successful!");
                return true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine("Invalid username or password. Try again!");
                return false;
            }
        }
        public void RegisterUser(string username, string password, string email)
        {

            if (projectrepositoryImpl.Login(username, password) == true)
            {
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine("Username already exists. Please Login !");

            }
            else
            {

                User newUser = new User
                {
                    Username = username,
                    Password = password,
                    Email = email

                };


                projectrepositoryImpl.AddUser(newUser);
                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine("Registration successful.Login Now!");
            }
          
        }
    }
}

