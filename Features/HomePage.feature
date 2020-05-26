@HomePage
@Browser:Chrome
@Browser:Firefox
Feature: HomePage
	In order to test static contents
	I successfully logged in
	I navigate to home page
	I check static contents

Background:
	Given I Navigate to the Login page 'https://demo.mycsf.net/Portal/Home/Login'
	When I enter Email and Password
	| Email              | Password    |
	| actu4205@gmail.com | Hitrust123! |
	And I click on Login button
	Then I navigate to landing page
	| AppLandingPage                                |
	| https://demo.mycsf.net/Portal/Home/AppLanding |
	And I click on app button

@regression
Scenario: Home page automation
	Given navigate to home page
	| HomePage                     |
	| https://demo.mycsf.net/Home3 |
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

