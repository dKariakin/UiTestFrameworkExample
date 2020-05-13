Feature: Example of google test page testing 

Background: 
Given Google Main Page is opened
And 'specflow' has been found

Scenario: First search result checking
When I click on the 1 search result
Then SpecFlow Main Page is opened