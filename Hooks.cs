using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using TechTalk.SpecFlow;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Gherkin.Model;
using System;

namespace WebAppAutomation
{
    [Binding]
    public sealed class Hooks
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks
        //Global Variable for Extend report
        private static ExtentTest featureName;
        private static ExtentTest scenario;
        private static ExtentReports extentReport;

        private readonly IObjectContainer objectContainer;
        private readonly ScenarioContext scenarioContext;
        private IWebDriver driver;

        public Hooks(IObjectContainer _objectContainer, ScenarioContext _scenarioContext)
        {
            objectContainer = _objectContainer;
            scenarioContext = _scenarioContext;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            scenario = featureName.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
            scenarioContext.TryGetValue("Browser", out var browser);
            switch (browser)
            {
                case "Firefox":
                    driver = new FirefoxDriver();
                    break;
                default:
                    ChromeOptions option = new ChromeOptions();
                    driver = new ChromeDriver(option);
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

        [BeforeTestRun]
        public static void BeforeTest()
        {
            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(@"D:\Projects\Automation\WebAppAutomation\Reports\index.html");
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            extentReport = new ExtentReports();
            extentReport.AttachReporter(htmlReporter);
        }
        [AfterTestRun]
        public static void AfterTest()
        {
            extentReport.Flush();
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            featureName = extentReport.CreateTest<Feature>(featureContext.FeatureInfo.Title);
        }

        [AfterStep]
        public static void AfterSteps()
        {
            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();
            if (ScenarioContext.Current.TestError == null)
            {
                switch (stepType)
                {
                    case "Given":
                        scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
                        break;
                    case "When":
                        scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
                        break;
                    case "Then":
                        scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text);
                        break;
                    case "And":
                        scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text);
                        break;
                    default:
                        break;

                }
            }
            else if (ScenarioContext.Current.TestError != null)
            {
                switch (stepType)
                {
                    case "Given":
                        scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.InnerException);
                        break;
                    case "When":
                        scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.InnerException);
                        break;
                    case "Then":
                        scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
                        break;
                    default:
                        break;

                }
            }
            else
            {
                switch (stepType)
                {
                    case "Given":
                        scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
                        break;
                    case "When":
                        scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
                        break;
                    case "Then":
                        scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
                        break;
                    default:
                        break;

                }

            }

        }
    }
}
