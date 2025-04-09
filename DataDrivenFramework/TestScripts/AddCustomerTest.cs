using OpenQA.Selenium;
using DataDrivenFramework.Pages;


namespace DataDrivenFramework.Framework
{

    [TestFixture]
    public class AddCustomerTest : AddCustomer
    {    

        [Test]
        public void TC01_OpentheCustomerPage()
        {   
             Thread.Sleep(3000); 
            elementHelper.ClickElement(By.CssSelector("body > div.ng-scope > div > div.ng-scope > div > div.borderM.box.padT20 > div:nth-child(5) > button"));
            bool isAddCustomerDiplayed = elementHelper.IsElementDisplayed(By.CssSelector("body > div.ng-scope > div > div.ng-scope > div > div.center > button:nth-child(1)"));
            Assert.IsTrue(isAddCustomerDiplayed, "Login button is not displayed.");
            Thread.Sleep(2000);             
            // Click on the "Add Customer" button
            elementHelper.ClickElement(By.CssSelector("body > div.ng-scope > div > div.ng-scope > div > div.center > button:nth-child(1)"));
          
        }


        [Test, TestCaseSource(nameof(GetCustomerData))]
        public void TC02_VerifyAddCustomer(string firstName, string lastName, string postCode, string address)
        {

             // Method to fill in the customer details and submit the form
            elementHelper.EnterText(firstNameField, firstName);
            elementHelper.EnterText(lastNameField, lastName);
            elementHelper.EnterText(postCodeField, postCode);
            Thread.Sleep(2000);     
        }




          public static IEnumerable<object[]> GetCustomerData()
            {                
                return excelUtil.ReadExcelData("Customer");
            }
    }
}