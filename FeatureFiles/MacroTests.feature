Feature: MacroTests

Background:
	Given I go to the Macro Calculator
	
@MacroCalculator
Scenario: Verify the correct minimum protein ammount is calculated
	Given I enter the following data:
		| attribute | value    |
		| height    | 163      |
		| weight    | 55       |
		| age       | 23       |
		| gender    | Female   |
	And I press Calculate
	When I navigate to Create Your Own tab
	And I move the protein slider to the Minimum
	Then the protein value should be 60

	@MacroCalculator
Scenario: Verify the correct maximum protein ammount is calculated
	Given I enter the following data:
		| attribute | value    |
		| height    | 163      |
		| weight    | 55       |
		| age       | 23       |
		| gender    | Female   |
	And I press Calculate
	When I navigate to Create Your Own tab
	And I move the protein slider to the Maximum
	Then the protein value should be 161
