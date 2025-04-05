
using DataDrivenFramework.Framework;
using OpenQA.Selenium;
using logA = DataDrivenFramework.Utilities.LoggerClass;



namespace DataDrivenFramework.TestScripts
{
    public class LoginTest : TestBase
    {
        
        
        [Test]
        public void TC01_LoginAsManager()
        {
            
           logA.LogInfo("Manager Login Test");
            logA.LogInfo("Starting the login test.");

            Thread.Sleep(2000);
            Driver.FindElement(By.CssSelector("body > div.ng-scope > div > div.ng-scope > div > div.borderM.box.padT20 > div:nth-child(5) > button")).Click();
            Thread.Sleep(7000);

            
        }
    }
}