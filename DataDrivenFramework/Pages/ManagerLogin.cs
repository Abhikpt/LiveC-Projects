
using DataDrivenFramework.Framework;
using OpenQA.Selenium;

namespace DataDrivenFramework.Pages
{

    public class ManagerLogin : TestBase
    {

        
       
        public void OpenManagerLoginPage()
        {   
            Driver.FindElement(By.CssSelector("body > div.ng-scope > div > div.ng-scope > div > div.borderM.box.padT20 > div:nth-child(5) > button")).Click();
            Thread.Sleep(7000);
        }
    }
}