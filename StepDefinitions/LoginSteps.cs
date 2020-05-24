using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using WebAppAutomation.PageObjects;

namespace WebAppAutomation.StepDefinitions
{
    [Binding]
    public class LoginSteps
    {
        LoginPage loginPage;
        HomePage homePage;
        public LoginSteps(IWebDriver driver)
        {
            loginPage = new LoginPage(driver);
            homePage = new HomePage(driver);
        }
        
        [Given(@"I Navigate to the Login page '(.*)'")]
        public void GivenINavigateToTheLoginPage(string loginPageUrl)
        {
            loginPage.NavigateToLoginPage(loginPageUrl);
        }

        [When(@"I enter Email and Password")]
        public void WhenIEnterEmailAndPassword(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            string email = (string)data.Email;
            string password = (string)data.Password;
            loginPage.EnterEmailAndPassword(email, password);
        }

        [When(@"I click on Login button")]
        public void WhenIClickOnLoginButton()
        {
            loginPage.ClickButton();   
        }
        
        [Then(@"the header '(.*)' Should be seen on the Dashboard Page")]
        public void ThenTheHeaderShouldBeSeenOnTheDashboardPage(string headerName)
        {
            loginPage.NavigateToDashboard(headerName);
        }

        [Then(@"the error message '(.*)'")]
        public void ThenTheErrorMessage(string errorMessage)
        {
            loginPage.CheckErrorMessageIsDisplayed();
            Assert.AreEqual(errorMessage, loginPage.GetErrorMessage());
        }


        [Then(@"I navigate to landing page")]
        public void ThenINavigateToLandingPage(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            string langingPageUrl = data.AppLandingPage;
            Assert.AreEqual(langingPageUrl, loginPage.GetPageUrl);
            loginPage.GetPageUrl.Should().Be(langingPageUrl);
        }

        [Then(@"I click on app button")]
        public void ThenIClickOnAppButton()
        {
            homePage.ClickButton();
        }


        [Then(@"I navigate to home page")]
        public void ThenINavigateToHomePage(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            string homePageUrl = data.HomePage;
            Assert.AreEqual(homePageUrl, homePage.GetPageUrl);
            homePage.GetPageUrl.Should().Be(homePageUrl);
        }


    }
}
 