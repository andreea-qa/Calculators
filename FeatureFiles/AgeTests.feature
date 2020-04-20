Feature: AgeTests

Background:
	Given I go to the Age Calculator

@Age
Scenario: Verify that the correct age is calculated using dropdowns
Given I enter the birth date 3/1/1999 from the dropdowns
And the current date is 04/11/2020
When I press Calculate
Then the age should be 21 years 1 months 10 days

@Age
Scenario: Verify that the correct age is calculated using the calendar
Given I enter the birth date 01/03/1999 from the calendar
And the current date is 04/11/2020
When I press Calculate
Then the age should be 21 years 1 months 10 days

@Age @NegativeTests
Scenario: Verify that the correct message is displayed when the birth date is in the future
Given I enter the birth date 1 week ahead
When I press Calculate
Then I should see the Date of birth needs to be earlier than the age at date. message