using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Serialization;
using MongoDB.Bson;
using System;

namespace DataDrivenFramework.Utilities
{
    public static class Reporting
    {
        private static ExtentReports extent;
        private static ExtentTest test;

        private static string testCategory;
        static string startupPath = Environment.CurrentDirectory;

         static Reporting()
        {
            // Initialize the ExtentReports object

               // Initialize the ExtentReports object
            string reportPath  = startupPath.Replace("bin\\Debug\\net8.0", "Resources\\Reports\\ExtentReport.html"); 
            var htmlReporter = new AventStack.ExtentReports.Reporter.ExtentHtmlReporter(reportPath);
            htmlReporter.Config.Encoding = "utf-8";
            htmlReporter.Config.Theme = Theme.Standard;
            htmlReporter.Config.DocumentTitle = "Automation Test Report";
            htmlReporter.Config.ReportName = "Automation Test Report";        
            // Attach the HTML reporter to the ExtentReports object
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            extent.AddSystemInfo("Host Name", "Abhishek Singh");
            extent.AddSystemInfo("Environment", "QA");  
        }

         public static void CreateTest(string testName)
        {
            
            test = extent.CreateTest(testName);  

            var categoryProperty = TestContext.CurrentContext.Test.Properties.Get("Category");
            testCategory = categoryProperty != null ? categoryProperty.ToString() : "No Category";      
            test.AssignCategory(testCategory?? "No Category");

        }

        public  static void LogInfo(string testName)
        {
            //test.Log(Status.Info, message);
            test.Info("Test Started: " + testName);

        }

        public static void StatusInfo(string message)
        {
            test.Log(Status.Info, message);
        }


        public  static void LogPass(string message)
        {
          //  test.Pass(message);
            test.Log(Status.Pass, message);
        }

        public static  void LogFail(string message)
        {
            test.Fail(message);
        }

        public static void LogSkip(string message)
        {
            test.Skip(message);
        } 

        public static  void LogWarning(string message)
        {
            test.Log(Status.Warning, message);
        }

        public static void LogError(string message)
        {
            test.Log(Status.Error, message);
        }

        public static  void Addscreenshot(string screenshotBase64)
        {
          //  test.AddScreenCaptureFromBase64String(screenshotBase64, "Screenshot");
            test.Log(Status.Info, "Screenshot: ", MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshotBase64).Build());

        }
         
        public static void EndReport()
        {
            extent.Flush();
        }

       





    }
}