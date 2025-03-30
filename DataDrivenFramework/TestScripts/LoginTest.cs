
using DataDrivenFramework.Framework;
using OpenQA.Selenium;

namespace DataDrivenFramework.TestScripts
{
    public class LoginTest : TestBase
    {
        [Test]
        public void LoginAsManager()
        {

            Driver.FindElement(By.CssSelector("body > div.ng-scope > div > div.ng-scope > div > div.borderM.box.padT20 > div:nth-child(5) > button")).Click();
            Thread.Sleep(2000);



            
        }
    }
}