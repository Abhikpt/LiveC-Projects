using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using con = DataDrivenFramework.Utilities.ConfigReader;
using DataDrivenFramework.Utilities;
using Microsoft.Extensions.Logging;
using NUnit.Framework.Interfaces;
using AventStack.ExtentReports.Model;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter.Configuration;
using AventStack.ExtentReports.Reporter;


namespace DataDrivenFramework.Framework ;

   
    public class TestBase : IDisposable
    {
        protected static IWebDriver Driver;
        protected ElementAction elementHelper;               
        public static string ProjectPath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;

        private static string _excelFilePath = ProjectPath + "\\Resources\\Data\\CustomerData.xlsx";
           
        public static ExcelUtility  excelUtil = new ExcelUtility(_excelFilePath);   
      
        


        [OneTimeSetUp]
        public void SetUp()
        {           

            // Initialize the WebDriver based on the browser specified in the configuration
            InitializeDriver(con.GetBrowser);            
            // Navigate to the URL specified in the configuration
            NavigateToUrl(con.GetUrl());   

            // Interact with the web page using the ElementAction class
            elementHelper = new ElementAction(Driver);

           // Log the start of the test suite execution  
           LoggerClass.LogInfo("------------------- Test Suit Execution Started ----------------------------");   
           
         
        
        }
       

        [SetUp]
        public void TestStart()
        {
            var testName = TestContext.CurrentContext.Test.Name;
            LoggerClass.LogInfo($"Starting Test: {testName}");

            // extentReport  
          //    test = extent.CreateTest(testName);
          //    test.Info($"Starting test: {testName}"); 

            Reporting.CreateTest(testName);
            Reporting.LogInfo(testName);
        }

        

        [TearDown]
        public void TestCompletion()
        {
            var testName = TestContext.CurrentContext.Test.Name;
            var testStatus = TestContext.CurrentContext.Result.Outcome.Status;
            LoggerClass.LogInfo($"Completed Test: {testName} with Status: {testStatus}");

            // extentReport
            if (testStatus == TestStatus.Failed)
            {
                string screenshotBase64 = CaptureScreenshot();
                Reporting.LogFail( "Test Failed " + TestContext.CurrentContext.Result.Message);
            //    Reporting.Addscreenshot(screenshotBase64);
                Reporting.Addscreenshot(screenshotBase64);
            }
            else if (testStatus == TestStatus.Skipped)
            {
               Reporting.LogSkip("Test Skipped. " + testName);
            }
            else if (testStatus == TestStatus.Passed)
            {
               Reporting.LogPass("Test Passed Successfully. " + testName); 
            }
            else
            {
                Reporting.LogWarning("Test Status Unknown. " + testName);

            }

            // flush the reports in html file
            Reporting.EndReport(); 
        }



          [OneTimeTearDown]
        // This method is called once after all tests in the class have run, to clean up resources.
        public void TearDown()
        {
                       
            LoggerClass.LogInfo("------------------- All the tests suit have been executed ------------------");
            LoggerClass.LogInfo("---------------------------------------------------------------------------");  
            if (Driver != null)   Dispose();  
        }
        
        public void Dispose()
        {
            Driver.Dispose();
            NLog.LogManager.Shutdown(); 
          
        }












        public void InitializeDriver(string browser)
        {
            Driver = browser.ToLower() switch
            {
                "chrome" => new ChromeDriver(),
                "firefox" => new FirefoxDriver(),
                "edge" => new EdgeDriver(),
                _ => new ChromeDriver(),
            };
            Driver.Manage().Window.Maximize();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(con.GetImplicitWait);
        }

        public void NavigateToUrl(string url)
        {
            if (Driver == null)
            {
                LoggerClass.LogError("Driver is not initialized. Call InitializeDriver() first.");
                throw new InvalidOperationException("Driver is not initialized. Call InitializeDriver() first.");
            }

            Driver.Navigate().GoToUrl(url);
        }


         private static string CaptureScreenshot()
        {
            try
            {
                Screenshot screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
                screenshot.SaveAsFile(ProjectPath + "\\Resources\\Reports\\error"+ GetDateString +".jpg");
                return screenshot.AsBase64EncodedString;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception while capturing screenshot: " + ex.Message);
                return ex.Message;
            }
            
        }
        private static string GetDateString => DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
       
    



      
    }
