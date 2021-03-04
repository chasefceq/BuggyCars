Feature: Vote
	Vote Cars Rating

Scenario: Vote Model Link
	Given I launch the application
	And Register and Login
	| UserName | FirstName | LastName | Password    | ConfirmPass |
	| random   | Kobe      | Vinski   | Qwerty1234! | Qwerty1234! |
	When I select the model and input my comments
	| VotingType     |  Comment  |
	| Popular Model  | 안녕하세요 |
	And I click vote
	Then I can see the success message displayed
	And I Cannot vote again on the same model

Scenario: Vote via Popular Make Link
	Given I launch the application
	And Register and Login
	| UserName | FirstName | LastName | Password    | ConfirmPass |
	| random   | Leo       | Carp     | Qwerty1234! | Qwerty1234! |
	When I select the model and input my comments
	| VotingType   | Comment	 |
	| Popular Make | 안녕하세요   |
	And I click vote
	Then I can see the success message displayed
	And I Cannot vote again on the same model

Scenario: Unable to vote without logging in - From Popular Model
	Given I launch the application
	When I select the model and try to vote
	| VotingType    |
	| Popular Model |
	Then I can see the message prompting me to login to vote

Scenario: Unable to vote without logging in - From Popular Make
	Given I launch the application
	When I select the model and try to vote
	| VotingType   |
	| Popular Make |
	Then I can see the message prompting me to login to vote
