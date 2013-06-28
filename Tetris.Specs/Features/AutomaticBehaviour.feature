Feature: Automatic behaviour of the game
	In order to add thrill to playing the game
	As a time ticker
	I want to automatically move the game towards its end

Background: 
	Given I have a game
	And the game is running

Scenario: Throw new piece on the game
	Given there is no current piece
	When I tick
	Then a new piece is put into the game
