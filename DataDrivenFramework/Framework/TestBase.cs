using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using con = DataDrivenFramework.Utilities.ConfigReader;
using DataDrivenFramework.Utilities;


namespace DataDrivenFramework.Framework
{
    public class TestBase : IDisposable
        {
        protected IWebDriver Driver;
      
    
         static string startupPath = Environment.CurrentDirectory;


        [OneTimeSetUp]
        public void SetUp()
        {
           
            // Initialize the WebDriver based on the browser specified in the configuration
            InitializeDriver(ConfigReader.GetBrowser);
            // Navigate to the URL specified in the configuration
             NavigateToUrl(ConfigReader.GetUrl());

            // Initialize the ExtentReports object
           LoggerClass.logger.Info("Starting the test setup.");
            
        }

        public void InitializeDriver(string browser)
        {
            switch (browser.ToLower())
            {
                case "chrome":
                    Driver = new ChromeDriver();
                    break;
                case "firefox":
                    Driver = new FirefoxDriver();
                    break;
                case "edge":
                    Driver = new EdgeDriver();
                    break;
                default:
                    Driver = new ChromeDriver();
                    break;
            }

            Driver.Manage().Window.Maximize();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(con.GetImplicitWait);
        }

        public void NavigateToUrl(string url)
        {
            if (Driver == null)
            {
                throw new InvalidOperationException("Driver is not initialized. Call InitializeDriver() first.");
            }

            Driver.Navigate().GoToUrl(url);
        }



        // public void SetupReport()
        // {
        //     // Initialize the ExtentReports object
        //     string reportPath  = startupPath.Replace("bin\\Debug\\net8.0", "Resources\\Reports\\ExtentReport.html"); 
        //     var htmlReporter = new ExtentHtmlReporter(reportPath);
        //     htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Standard;
        //     extent = new ExtentReports();
        //     extent.AttachReporter(htmlReporter);
        //     extent.AddSystemInfo("Host Name", "Automation Test");
        //     extent.AddSystemInfo("Environment", "QA");
        // }


        [OneTimeTearDown]
        // This method is called once after all tests in the class have run
        // It is used to clean up resources, such as closing the browser
        public void TearDown()
        {
            if (Driver != null)
            {
                Driver.Quit();
                Dispose();
            }
            
           LoggerClass.logger.Info("Ending the test setup.");
        }
        public void Dispose()
        {
            Driver.Dispose();
        }
    }
}