using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebAppAutomation.Utilities;
using BoDi;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace WebAppAutomation.Hooks
{
    [Binding]
    public class Hook
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks
        private readonly IObjectContainer objectContainer;
        private readonly ScenarioContext scenarioContext;
        private IWebDriver driver;

        public Hook(IObjectContainer _objectContainer, ScenarioContext _scenarioContext)
        {
            objectContainer = _objectContainer;
            scenarioContext = _scenarioContext;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            scenarioContext.TryGetValue("Browser", out var browser);
            switch (browser)
            {
                case "Firefox":
                    driver = new FirefoxDriver();
                    break;
                default:
                    driver = new ChromeDriver();
                    break;
            }
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);           
            scenarioContext.ScenarioContainer.RegisterInstanceAs<IWebDriver>(driver);
            objectContainer.RegisterInstanceAs<IWebDriver>(driver);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}
