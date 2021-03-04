Feature: Register
	Register with Buggy Cars Rating

@registercorrectdetails
Scenario: Register with correct details
	#steps
	Given I launch the application
	And click the Register link
	And I enter the register my details with random username
	| UserName | FirstName | LastName | Password    | ConfirmPass |
	| random   | Steph     | Fhel     | Qwerty1234! | Qwerty1234! |
	When I click the Register button
	Then I should see success message displayed
	Then I can Login successfully using the newly registered user


@registerusernameexist
Scenario: Register with incorrect password - Username already taken
	#steps
	Given I launch the application
	And click the Register link
	And I enter the register my details
	| UserName | FirstName | LastName | Password    | ConfirmPass |
	| chase    | Rayze     | Korn     | Qwerty1234! | Qwerty1234! |
	When I click the Register button
	Then I should see username error message displayed


Scenario: Register with incorrect password - Minumum password
	#steps
	Given I launch the application
	And click the Register link
	And I enter the register my details
	| UserName | FirstName | LastName | Password | ConfirmPass |
	| chase    | Rayze     | Korn     | 123      | 123         |
	When I click the Register button
	Then I should see minimum field error message displayed

Scenario: Register with incorrect password - Password do not match
	#steps
	Given I launch the application
	And click the Register link
	And I enter the register my details
	| UserName | FirstName | LastName | Password | ConfirmPass |
	| chase    | Rayze     | Korn     | Qwerty!  | Qwertyuiop  |
	Then I should see password do not match error message displayed	