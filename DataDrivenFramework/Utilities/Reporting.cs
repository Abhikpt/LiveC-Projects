using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;

namespace AutomationProject.Utilities
{
    public class Reporting
    {
        private static ExtentReports extent;
        private static ExtentTest test;
        static string startupPath = Environment.CurrentDirectory;

        public static void StartReport()
        {
            // Initialize the ExtentReports object

            string reportPath  = startupPath.Replace("bin\\Debug\\net8.0", "Resources\\Reports\\ExtentReport.html"); 
            var htmlReporter = new ExtentHtmlReporter(reportPath);
          //  htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Standard;
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            extent.AddSystemInfo("Host Name", "Abhishek Singh");
            extent.AddSystemInfo("Environment", "QA");
        }

        public static void StartTest(string testName)
        {
            test = extent.CreateTest(testName);
        }

        public static void LogInfo(string message)
        {
            test.Log(Status.Info, message);
        }

        public static void LogPass(string message)
        {
            test.Log(Status.Pass, message);
        }

        public static void LogFail(string message)
        {
            test.Log(Status.Fail, message);
        }

        public static void EndReport()
        {
            extent.Flush();
        }
    }
}