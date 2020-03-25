Feature: Calculate Calories
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario Outline: Calculate calories in metric system
	Given I select the Metric system
	And I enter the age <age>
	And I enter the height <height>
	And I enter the weight <weight>
	And I select the gender <gender>
	When I press Calculate
	Then the result should be <expected result> on the screen

	Examples:
		| age | height | weight | gender | expected result |
		| 30  | 162    | 57     | Female | 1,863           |
		| 30  | 183    | 75     | Male   | 2,562           |

Scenario: Calculate calories in metric system for a very active person
	Given I select the Metric system
	And I enter the age 30
	And I enter the height 162
	And I enter the weight 57
	And I select the gender Female
	And I select Very Active from the activity dropdown
	When I press Calculate
	Then the result should be 2,193 on the screen