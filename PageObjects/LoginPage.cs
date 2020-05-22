using OpenQA.Selenium;
using NUnit.Framework;
using WebAppAutomation.Utilities;
using System.Threading;
using System;

namespace WebAppAutomation.PageObjects
{
    class LoginPage
    {
        IWebDriver driver;
        Waits waits;
        public LoginPage(IWebDriver _driver)
        {
            driver = _driver;
            waits = new Waits();
        }

        IWebElement emailField => driver.FindElement(By.Id("IDToken1"));
        IWebElement passwordField => driver.FindElement(By.Id("IDToken2"));
        IWebElement loginButton => driver.FindElement(By.Id("buttonLogin"));
        IWebElement headerTitle => driver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div[1]/h2"));
       
        IWebElement invalidLogin => driver.FindElement(By.CssSelector("body > div:nth-child(1) > form > div.field-validation-error"));
        public string GetPageUrl => driver.Url;
        public string GetPageTitle => driver.Title;

        public void EnterEmailAndPassword(string email, string password)
        {
            emailField.SendKeys(email);
            passwordField.SendKeys(password);
            Thread.Sleep(2000);
        }

        public void ClickButton()
        {
           loginButton.Click();
        }

        public void NavigateToDashboard(string headerName)
        {
            string textValue = headerTitle.Text;
            Assert.AreEqual(headerName, textValue);
        }
        
        public void NavigateToLoginPage(string loginPageUrl)
        {
            driver.Navigate().GoToUrl(loginPageUrl);
        }

        public void CheckErrorMessageIsDisplayed()
        {
            Assert.IsTrue(invalidLogin.Displayed);
        }

        public string GetErrorMessage()
        {
            return waits.WaitForElement(driver, invalidLogin).Text;
        }
    }
}
