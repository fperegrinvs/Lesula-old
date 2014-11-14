Feature: Getting a task to execute in the correct order
    As a system administrator
	I would like to be able to queue tasks to be executed by the map/reducer
	So I can add a task to be executed and don't need to worry if any task is running

Scenario: There's no task in the queue
	Given The queue is empty
	When the system searches for an task
	Then no task is executed

Scenario: There's a new task in the queue and the lastest one still executing with no empty slot
	Given The queue has a new task
	And the lastest task still running
	And there's no slot left in the lastest task
	When the system searches for an task
	Then executes the new task

Scenario: There's a new task in the queue and the lastest one still executing an empty slot
	Given The queue has a new task
	And the lastest task still running
	And there's an slot left in the lastest task
	When the system searches for an task
	Then allocates slots from the lastest task
