using OpenQA.Selenium;
using TechTalk.SpecFlow;
using WebAppAutomation.PageObjects;
using TechTalk.SpecFlow.Assist;
using System;
using System.Collections.Generic;
using WebAppAutomation.Utilities;

namespace WebAppAutomation.StepDefinitions
{
    [Binding]
    public sealed class HomePageSteps
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef
        HomePage homePage;
        public HomePageSteps(IWebDriver driver)
        {
            homePage = new HomePage(driver);
        }

        [Given(@"navigate to home page")]
        public void GivenNavigateToHomePage(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            string homePageUrl = data.HomePage;
            homePage.NavigateToHomePage(homePageUrl);
        }

        [Then(@"there should be nav bars")]
        public void ThenThereShouldBeNavBars(Table table)
        {
            var navBars = TableExtensions.ToArray(table);
            homePage.NavBarMenus(navBars);
            Console.WriteLine(navBars);
        }

        [Then(@"the static texts are")]
        public void ThenTheStaticTextsAre(Table table)
        {
            var texts = TableExtensions.ToArray(table);
            homePage.HomePageTexts(texts);
            Console.WriteLine(texts);
        }

    }
}
