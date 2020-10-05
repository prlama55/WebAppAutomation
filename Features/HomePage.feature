@HomePage
@Browser:Chrome
@Browser:Firefox
Feature: HomePage
	In order to test static contents
	I successfully logged in
	I navigate to home page
	I check static contents

Background:
	Given I Navigate to the Login page '<Login_page>'
	When I enter Email and Password
	| Email              | Password    |
	| xxxxx@gmail.com | pw! |
	And I click on Login button
	Then I navigate to landing page
	| AppLandingPage                                |
	| <AppLanding_page> |
	And I click on app button

@regression
Scenario: Home page automation
	Given navigate to home page
	| HomePage                     |
	| <Home_page> |
	Then there should be nav bars
	| NavBars                 |
	| HOME                    |
	| REFERENCES              |
	| ANALYTICS               |
	| CORRECTIVE ACTION PLANS |
	| ADMINISTRATION          |
	| SEARCH                  |
	And the static texts are
	| Texts              |
	| YOUR NOTIFICATIONS |
	| ASSESSMENTS        |
	| CUSTOM LIBRARIES   |
	| BULLETINS          |

