using System;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.FileSystemGlobbing.Internal.PathSegments;

namespace DataDrivenFramework.Utilities
{
    public static class ConfigReader
    {
        // Retrieves the URL from the configuration file

      
        public static IConfiguration Configuration { get; set; }

        static ConfigReader()
        {
            // Initialize the configuration object
            Configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile(@"C:\ProjectWorkspace\Automation Project\LiveC#Projects\DataDrivenFramework\Resources\Config\appsettings.json", optional: false, reloadOnChange: true)
                .Build();
        
        }
        public static string GetUrl()
        {
            return Configuration["ApplicationURL"];
        }

        // Retrieves the username from the configuration file
        public static string GetUsername()
        {
            return Configuration["Username"];
        }

        // Retrieves the password from the configuration file
        public static string GetPassword() => Configuration["Password"];      

        public static int GetImplicitWait =>   Convert.ToInt32(Configuration["ImplicitWait"]) ; // Implicit wait in seconds
        


        public static string GetBrowser => Configuration["Browser"];
        
    }

}
