using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebAppAutomation.Utilities
{
    public class Waits
    {
        public IWebElement WaitForElement(IWebDriver driver, IWebElement element)
        {
            DefaultWait<IWebDriver> fluientWait = new DefaultWait<IWebDriver>(driver);
            fluientWait.Timeout = TimeSpan.FromSeconds(5);
            fluientWait.PollingInterval = TimeSpan.FromMilliseconds(500);
            fluientWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            if (fluientWait.Until(x => element.Displayed))
                return element;
            else
                return null;
        }

        public void WaitForWebDriver(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            Func<IWebDriver, bool> waitForElement = new Func<IWebDriver, bool>((IWebDriver webDriver) =>{
                return true;
            });
            wait.Until(waitForElement);
        }
    }
}
