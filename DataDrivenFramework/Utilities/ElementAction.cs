using DataDrivenFramework.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

public class ElementAction
{
    private readonly IWebDriver _driver;
    private readonly WebDriverWait _wait;

    public ElementAction(IWebDriver driver)
    {
        _driver = driver;
        _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10)); // Adjust timeout as needed
    }

    public void ClickElement(By locator)
    {
        _wait.Until(ExpectedConditions.ElementToBeClickable(locator)).Click();
    }

    public void EnterText(By locator, string text)
    {
        var element = _wait.Until(ExpectedConditions.ElementIsVisible(locator));
        element.Clear();
        element.SendKeys(text);
    }

    public string GetElementText(By locator)
    {
        return _wait.Until(ExpectedConditions.ElementIsVisible(locator)).Text;
    }

    public bool IsElementDisplayed(By locator)
    {
        try
        {
            return _wait.Until(ExpectedConditions.ElementIsVisible(locator)).Displayed;
        }
        catch (NoSuchElementException)
        {
            return false;
        }
    }


    public WebDriverWait Wait()
    {
        return _wait;
    }
    
}
