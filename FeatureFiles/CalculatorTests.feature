Feature: Calculate Calories
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

Background:
	Given I select the Metric system

@calories
Scenario Outline: Calculate calories in metric system
	Given I enter the following data:
		| attribute | value    |
		| height    | <height> |
		| weight    | <weight> |
		| age       | <age>    |
		| gender    | <gender> |
	When I press Calculate
	Then the result should be <expected result> on the screen

	Examples:
		| age | height | weight | gender | expected result |
		| 30  | 162    | 57     | Female | 1,863           |
		| 30  | 183    | 75     | Male   | 2,562           |

@calories
Scenario: Calculate calories in metric system for a very active person
	Given I enter the following data:
		| attribute | value  |
		| height    | 162    |
		| weight    | 57     |
		| age       | 30     |
		| gender    | Female |
	And I select Very Active from the activity dropdown
	When I press Calculate
	Then the result should be 2,193 on the screen