Feature: Global interaction with the game 
	In order to start and stop the new game
	As a player
	I want to be able to interact with the game

Background:
	Given I have a game

Scenario: Observing the new game
	When I do nothing
	Then the game should be blank

Scenario: Start a blank game
	Given the game is blank
	When I start the game
	Then the game should be running

Scenario: Pause the game
	Given the game is running
	When I pause the game
	Then the game should be pausing

Scenario: Resume the game
	Given the game is pausing
	When I resume the game
	Then the game should be running
