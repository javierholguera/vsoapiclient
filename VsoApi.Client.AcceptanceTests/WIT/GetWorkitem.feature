Feature: GetWorkitem
	In order manage information about work items
	As an API consumer
	I want to be able get information about a work item by its ID

@mytag
Scenario: Get a work item by ID
	Given There is a work item with ID 89
	When I get the work item details from the team project
	Then the result is defined
	And the work item is a task
	And its title is 'Add E2E testing using SpecFlow'
	And it is assigned to 'Javier Holguera'
	And its state is 'Active'
	And it doesn't contain information about relations

Scenario: Get a work item with its relations by ID
	Given There is a work item with ID 89
	When I get the work item details with its relations from the team project
	Then the result is defined
	And the work item contains a list of 2 relations
	And I can get information about each work item in the relation
