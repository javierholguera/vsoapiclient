Feature: GetWorkitems
	In order manage information about work items
	As an API consumer
	I want to be able to get lists of work items

@mytag
Scenario: Get list of work items by IDs
	Given There are work items with IDs 89, 90 and 91
	When I get these work items from the team project
	Then the result contains 3 work items
