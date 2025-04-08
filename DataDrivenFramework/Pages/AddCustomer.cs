using System;
using DataDrivenFramework.Framework;
using DataDrivenFramework.Utilities;
using OpenQA.Selenium;
using Excel = Microsoft.Office.Interop.Excel;


namespace DataDrivenFramework.Pages;
    public class AddCustomer : TestBase
    {  
        // Path to the Excel file
       public   By firstNameField = By.CssSelector("body > div.ng-scope > div > div.ng-scope > div > div.ng-scope > div > div > form > div:nth-child(1) > input");
      public   By lastNameField = By.CssSelector("body > div.ng-scope > div > div.ng-scope > div > div.ng-scope > div > div > form > div:nth-child(2) > input"); 
      public   By postCodeField = By.CssSelector("body > div.ng-scope > div > div.ng-scope > div > div.ng-scope > div > div > form > div:nth-child(3) > input"); 
    




    }