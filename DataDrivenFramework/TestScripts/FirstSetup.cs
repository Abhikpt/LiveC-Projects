

// namespace DataDrivenFramework.TestScripts;

// [SetUpFixture]
// public class FirstSetup
// {

//     [OneTimeSetUp]

//     public void RunBeforeAnyTests()
//     {
//         // Initialize the WebDriver based on the browser specified in the configuration
//         TestBase.InitializeDriver(con.GetBrowser);

//         // Navigate to the URL specified in the configuration
//         TestBase.NavigateToUrl(con.GetUrl());

//         // Interact with the web page using the ElementAction class
//         TestBase.elementHelper = new ElementAction(TestBase.Driver);

//         // Log the start of the test suite execution  
//         LoggerClass.LogInfo("------------------- Test Suit Execution Started ----------------------------");
//     }
    
//         [OneTimeTearDown]
//         // This method is called once after all tests in the class have run, to clean up resources.
//         public void TearDown()
//         {
                       
//             LoggerClass.LogInfo("------------------- All the tests suit have been executed ------------------");
//             LoggerClass.LogInfo("---------------------------------------------------------------------------");  
//             if (Driver != null)   Dispose();         
//         }




// }