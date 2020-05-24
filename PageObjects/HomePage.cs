using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Threading;

namespace WebAppAutomation.PageObjects
{
    class HomePage
    {
        IWebDriver driver;

        IWebElement appButton => driver.FindElement(By.Id("aMyCSF"));
        IWebElement NavBar => driver.FindElement(By.XPath("//*[@id=\"navbar\"]/ul[1]"));
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
            driver.Navigate().GoToUrl(homePageUrl);
        }

        public void getNavBars(List<string> navBars)
        {
            var navBarsElements=NavBar.FindElements(By.TagName("li"));
            Console.WriteLine("navBars=====", navBars);
            //foreach (var li in navBarsElements)
            //{
            //    Assert.IsTrue(navBars.Contains(li.FindElement(By.TagName("a")).Text));
            //}
        }
    }
}
