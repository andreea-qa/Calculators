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
