
using DataDrivenFramework.Framework;
using OpenQA.Selenium;
using DataDrivenFramework.Utilities;



namespace DataDrivenFramework.TestScripts
{
    public class LoginTest : TestBase
    {       
        
        [Test]
        public void TC01_LoginAsManager()
        {
            Thread.Sleep(3000);
           
            Driver.FindElement(By.CssSelector("body > div.ng-scope > div > div.ng-scope > div > div.borderM.box.padT20 > div:nth-child(5) > button")).Click();
            
            bool isAddCustomerDiplayed = elementHelper.IsElementDisplayed(By.CssSelector("body > div.ng-scope > div > div.ng-scope > div > div.center > button:nth-child(1)"));
            Assert.IsTrue(isAddCustomerDiplayed, "Login button is not displayed.");
            
            // LoggerClass.LogError("Error in clicking the button: " + e.Message);
            // TestContext.CurrentContext.Result.Outcome.Status.Equals(NUnit.Framework.Interfaces.TestStatus.Failed);
        
            Thread.Sleep(7000);            
        }
    }
}