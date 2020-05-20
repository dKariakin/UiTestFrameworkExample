@SomeExamples
Feature: Example of google test page testing

Scenario: First search result checking
	Given Google Main Page is opened
	And 'specflow' has been found
	When I click on the 1 Search result
	Then SpecFlow Main Page is opened