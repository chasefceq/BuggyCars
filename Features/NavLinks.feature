Feature: NavLinks
	Verify if links are accessible

Scenario: Navigate back to homepage from Overall Rating
	Given I launch the application
	When I Navigate to any pagename
	| PageName       |
	| Overall Rating |
	Then I should be able to navigate back to my homepage

Scenario: Navigate back to homepage from Popular Model
	Given I launch the application
	When I Navigate to any pagename
	| PageName      |
	| Popular Model |
	Then I should be able to navigate back to my homepage

Scenario: Navigate back to homepage from Popular Make
	Given I launch the application
	When I Navigate to any pagename
	| PageName     |
	| Popular Make |
	Then I should be able to navigate back to my homepage