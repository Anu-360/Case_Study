using Microsoft.Extensions.Configuration;


namespace Project_Management.Utility
{

   
    internal static class DBConnection
    {
        private static IConfiguration _iconfiguration;

        static DBConnection()
        {
            GetAppSettingsFile();
        }

        private static void GetAppSettingsFile()
        {
            var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json");
            _iconfiguration = builder.Build();

        }

        public static string GetConnectionString()
        {
            return _iconfiguration.GetConnectionString("LocalConnectionString");
        }

    }
}
 

