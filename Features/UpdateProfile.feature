Feature: Update Profile
		Update Profile details

Scenario: Update Profile with correct details
	Given I launch the application
	And Register and Login
	| UserName | FirstName | LastName | Password    | ConfirmPass |
	| random   | Rayze     | Korn     | Qwerty1234! | Qwerty1234! |
	When I navigate to Profile
	And I update my details
	| Name  | Surname | Gender | Age | Address    | Phone    | Hobby       | Cpass       | Npass     | Conpass   |
	| Aespa | Cnblue  | Female | 16  | My Address | 38207434 | Video Games | Qwerty1234! | Chasec29. | Chasec29. |
	When I click the Save button
	Then I should see my details successfully updated
