@login
@Browser:Chrome
Feature: Login
	In order to manage system
	As a user
	I want to be able to login to the dashboard

@regression @loginSuccess
Scenario: Successful Login by User
	Given I Navigate to the Login page '<Login_URL>'
	When I enter Email and Password
	| Email              | Password    |
	| xxxxx@gmail.com | pw! |
	And I click on Login button
	Then the header '<Header_title>' Should be seen on the Dashboard Page 
	And I navigate to landing page
	| AppLandingPage                                |
	| <AppLanding_url> |
	And I click on app button
	And I navigate to home page
	| HomePage                     |
	| <Home_page>|

@regression @loginFail
Scenario: Invalid Email and Password
	Given I Navigate to the Login page '<Login_URL>'
	When I enter Email and Password
	| Email              | Password    |
	| xxxxx@gmail.com | pw! |
	And I click on Login button
	Then the error message 'Incorrect username or password.'
