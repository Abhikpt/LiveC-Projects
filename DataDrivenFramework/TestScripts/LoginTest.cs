
using DataDrivenFramework.Framework;
using OpenQA.Selenium;
using DataDrivenFramework.Utilities;
using AventStack.ExtentReports.Model;



namespace DataDrivenFramework.TestScripts
{

    [TestFixture]
    public class LoginTest : TestBase
    {       
        
        [Test, Category("SmokeTest")]
        public void TC01_LoginAsBankManager()
        {
            Thread.Sleep(3000);
            Driver.FindElement(By.CssSelector("body> div.ng-scope > div > div.ng-scope > div > div.borderM.box.padT20 > div:nth-child(5) > button")).Click();
            
            bool isAddCustomerDiplayed = elementHelper.IsElementDisplayed(By.CssSelector("body > div.ng-scope > div > div.ng-scope > div > div.center > button:nth-child(1)"));
            Assert.IsTrue(isAddCustomerDiplayed, "Login button is not displayed.");
            
            Thread.Sleep(7000);            
        }
    }
}