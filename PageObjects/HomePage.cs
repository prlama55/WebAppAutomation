using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Threading;

namespace WebAppAutomation.PageObjects
{
    class HomePage
    {
        IWebDriver driver;

        IWebElement appButton => driver.FindElement(By.Id("aMyCSF"));
        public string GetPageUrl => driver.Url;
        public string GetPageTitle => driver.Title;
        public HomePage(IWebDriver _driver)
        {
            driver = _driver;
        }

        public void ClickButton()
        {
            appButton.Click();
        }

        public void NavigateToHomePage(string homePageUrl)
        {
            
        }
    }
}
