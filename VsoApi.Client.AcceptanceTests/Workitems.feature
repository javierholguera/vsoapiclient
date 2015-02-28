Feature: Workitems
	In order manage information about work items
	As an API consumer
	I want to be able to get lists of work items, get details of a work item, create a workitem and update a work item

@mytag
Scenario: Get list of workt items by IDs
	Given There are work items with IDs 69, 70 and 71
	When I get all available work items in the team project
	Then the result contains 3 work items
