using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using TechTalk.SpecFlow;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Gherkin.Model;
using System;
using AventStack.ExtentReports.Reporter.Configuration;

namespace WebAppAutomation
{
    [Binding]
    public sealed class Hooks
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks
        //Global Variable for Extend report
        private static FeatureContext _featureContext;
        private static ScenarioContext _scenarioContext;
        private static ExtentReports _extentReport;
        private static ExtentHtmlReporter _extentHtmlReporter;
        private static ExtentTest _feature;
        private static ExtentTest _scenario;
        private readonly IObjectContainer _objectContainer;
        private IWebDriver _driver;

        public Hooks(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeTestRun]
        public static void BeforeTest()
        {
            string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string actualPath = path.Substring(0, path.LastIndexOf("bin"));
            string projectPath = new Uri(actualPath).LocalPath;
            Console.WriteLine("projectPath=====", projectPath);
            _extentHtmlReporter = new ExtentHtmlReporter(projectPath);
           _extentHtmlReporter.Config.Theme = Theme.Standard;
            _extentReport = new ExtentReports();
            _extentReport.AttachReporter(_extentHtmlReporter);
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            if (featureContext != null)
            {
                _featureContext = featureContext;
                _feature = _extentReport.CreateTest<Feature>(featureContext.FeatureInfo.Title);
            }
        }

        [BeforeScenario]
        public void BeforeScenario(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;

            if (scenarioContext != null)
            {
                _scenarioContext = scenarioContext;
                _scenario = _feature.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
            }
            scenarioContext.TryGetValue("Browser", out var browser);
            Console.WriteLine("browser===", browser);
            switch (browser)
            {
                case "Firefox":
                    _driver = new FirefoxDriver();
                    break;
                default:
                    ChromeOptions option = new ChromeOptions();
                    _driver = new ChromeDriver(option);
                    break;
            }
            //driver.Manage().Window.Maximize();
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _objectContainer.RegisterInstanceAs<IWebDriver>(_driver);
        }

        [AfterStep]
        public static void AfterSteps()
        {
            ScenarioBlock scenarioBlock = _scenarioContext.CurrentScenarioBlock;
            switch (scenarioBlock)
            {
                case ScenarioBlock.Given:
                    if (_scenarioContext.TestError != null)
                        _scenario.CreateNode<Given>(_scenarioContext.TestError.Message).Fail("\n" + _scenarioContext.TestError.StackTrace);
                    else
                        _scenario.CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text).Pass("");
                    break;
                case ScenarioBlock.When:
                    if (_scenarioContext.TestError != null)
                        _scenario.CreateNode<When>(_scenarioContext.TestError.Message).Fail("\n" + _scenarioContext.TestError.StackTrace);
                    else
                        _scenario.CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text).Pass("");
                    break;
                case ScenarioBlock.Then:
                    if (_scenarioContext.TestError != null)
                        _scenario.CreateNode<Then>(_scenarioContext.TestError.Message).Fail("\n" + _scenarioContext.TestError.StackTrace);
                    else
                        _scenario.CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text).Pass("");
                    break;
                default:
                    if (_scenarioContext.TestError != null)
                        _scenario.CreateNode<And>(_scenarioContext.TestError.Message).Fail("\n" + _scenarioContext.TestError.StackTrace);
                    else
                        _scenario.CreateNode<And>(_scenarioContext.StepContext.StepInfo.Text).Pass("");
                    break;

            }
        }


        [AfterScenario]
        public void AfterScenario()
        {
            _driver.Quit();
           // _driver.Dispose();
        }

        [AfterTestRun]
        public static void AfterTest()
        {
            _extentReport.Flush();
        }
    }
}
