using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using con = DataDrivenFramework.Utilities.ConfigReader;
using DataDrivenFramework.Utilities;
using Microsoft.Extensions.Logging;


namespace DataDrivenFramework.Framework
{
    public class TestBase : IDisposable
        {
        protected IWebDriver Driver;
        protected ElementAction elementHelper;
        public static string ProjectPath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;

        private static string _excelFilePath = ProjectPath + "\\Resources\\Data\\CustomerData.xlsx";
           
        public static ExcelUtility  excelUtil = new ExcelUtility(_excelFilePath);   
      
        


        [OneTimeSetUp]
        public void SetUp()
        {           
            // Initialize the WebDriver based on the browser specified in the configuration
            InitializeDriver(ConfigReader.GetBrowser);
            // Navigate to the URL specified in the configuration
            NavigateToUrl(ConfigReader.GetUrl());            
            // Interact with the web page using the ElementAction class
            elementHelper = new ElementAction(Driver);
            // Initialize the ExcelUtility class with the path to the Excel file
         


           LoggerClass.LogInfo("------------------- Test Suit Execution Started ----------------------------");   
           
        }


        [SetUp]
        public void TestStart()
        {
            var testName = TestContext.CurrentContext.Test.Name;
            LoggerClass.LogInfo($"Starting Test: {testName}");
        }

        [TearDown]
        public void TestCompletion()
        {
            var testName = TestContext.CurrentContext.Test.Name;
            var testStatus = TestContext.CurrentContext.Result.Outcome.Status;
            LoggerClass.LogInfo($"Completed Test: {testName} with Status: {testStatus}");
        }



          [OneTimeTearDown]
        // This method is called once after all tests in the class have run, to clean up resources.
        public void TearDown()
        {
                       
            LoggerClass.LogInfo("------------------- All the tests suit have been executed ------------------");
            LoggerClass.LogInfo("---------------------------------------------------------------------------");  
            if (Driver != null)   Dispose();         
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



      
        public void Dispose()
        {
            Driver.Dispose();
            NLog.LogManager.Shutdown(); 
        }
    }
}