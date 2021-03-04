Feature: Login
	Login to Buggy Cars Rating
@correctlogin
Scenario: Login to Buggy Cars Rating site with correct password
	Given I launch the application
	And I enter the following details
	| UserName | Password  |
	| skyreign | Chasec20. |
	When I click the login button
	Then I should see my Profile link

@incorrectlogin
Scenario: Login to Buggy Cars Rating site with wrong details
	Given I launch the application
	And I enter the following details
	| UserName | Password |
	| skyreign | 1234     |
	When I click the login button
	Then login failed