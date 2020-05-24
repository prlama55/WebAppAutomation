@login
@Browser:Chrome
Feature: Login
	In order to manage system
	As a user
	I want to be able to login to the dashboard

@regression @loginSuccess
Scenario: Successful Login by User
	Given I Navigate to the Login page 'https://demo.mycsf.net/Portal/Home/Login'
	When I enter Email and Password
	| Email              | Password    |
	| actu4205@gmail.com | Hitrust123! |
	And I click on Login button
	Then the header 'MY APPLICATIONS' Should be seen on the Dashboard Page 
	And I navigate to landing page
	| AppLandingPage                                |
	| https://demo.mycsf.net/Portal/Home/AppLanding |
	And I click on app button
	And I navigate to home page
	| HomePage                     |
	| https://demo.mycsf.net/Home3 |

@regression @loginFail
Scenario: Invalid Email and Password
	Given I Navigate to the Login page 'https://demo.mycsf.net/Portal/Home/Login'
	When I enter Email and Password
	| Email              | Password    |
	| actu42051@gmail.com | Hitrust12321! |
	And I click on Login button
	Then the error message 'Incorrect username or password.'
