using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace WebAppAutomation.PageObjects
{
    class HomePage
    {
        IWebDriver driver;

        IWebElement appButton => driver.FindElement(By.Id("aMyCSF"));
        IWebElement NavBar => driver.FindElement(By.XPath("//*[@id=\"navbar\"]/ul[1]"));
        IWebElement AssessmentBarChartTitle => driver.FindElement(By.XPath("//*[@id=\"assessmentsEntityBanner\"]/b"));
        IWebElement Notification => driver.FindElement(By.XPath("//*[@id=\"notificationHeader\"]/div/b"));
        IWebElement Buletines => driver.FindElement(By.XPath("//*[@id=\"welcomeContainer\"]/div[2]/div[2]/div[1]/b"));
        IWebElement CustomLibrary => driver.FindElement(By.XPath("//*[@id=\"assessmentsEntityBanner\"]/b"));
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

        public void NavBarMenus(List<string> navBars)
        {
           var navBarsElements =NavBar.FindElements(By.TagName("li"));
            foreach (IWebElement li in navBarsElements)
            {
                string text = li.FindElement(By.ClassName("nav-link")).Text;
                Assert.IsTrue(navBars.Contains(text));
            }
        }
        public void HomePageTexts(List<string> texts)
        {
            Assert.IsTrue(texts.Contains(AssessmentBarChartTitle.Text));
            Assert.IsTrue(texts.Contains(Notification.Text));
            Assert.IsTrue(texts.Contains(Buletines.Text));
            Assert.IsTrue(texts.Contains(CustomLibrary.Text));
        }

    }
}
