Feature: Calculate Calories
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

Background:
	Given I go to the Calories Calculator
	And I select the Metric system

@Calories
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

@Calories
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

@Calories @NegativeTests
Scenario Outline:  Verify that the correct error message is displayed when mandatory values are missing
	Given I enter the following data:
		| attribute | value    |
		| height    | <height> |
		| weight    | <weight> |
		| age       | <age>    |
		| gender    | <gender> |
	When I press Calculate
	Then I should see the <error> message

	Examples:
		| age | height | weight | gender | error                                    |
		|     | 162    | 57     | Female | Please provide an age between 15 and 80. |
		| 30  |        | 75     | Male   | Please provide positive height value.    |
		| 30  | 183    |        | Male   | Please provide positive weight value.    |

@Calories @NegativeTests
Scenario Outline:  Verify that the correct error message is displayed when invalid values are entered
	Given I enter the following data:
		| attribute | value    |
		| height    | <height> |
		| weight    | <weight> |
		| age       | <age>    |
		| gender    | <gender> |
	When I press Calculate
	Then I should see the <error> message

	Examples:
		| age | height | weight | gender | error                                    |
		| 14  | 162    | 57     | Female | Please provide an age between 15 and 80. |
		| 81  | 162    | 57     | Female | Please provide an age between 15 and 80. |
		| 0   | 162    | 57     | Female | Please provide an age between 15 and 80. |
		| a   | 162    | 57     | Female | Please provide an age between 15 and 80. |
		| -1  | 162    | 57     | Female | Please provide an age between 15 and 80. |
		| 30  | 0      | 75     | Male   | Please provide positive height value.    |
		| 30  | a      | 75     | Male   | Please provide positive height value.    |
		| 30  | -1     | 75     | Male   | Please provide positive height value.    |
		| 30  | 182    | 0      | Male   | Please provide positive weight value.    |
		| 30  | 180    | a      | Male   | Please provide positive weight value.    |
		| 30  | 182    | -1     | Male   | Please provide positive weight value.    |