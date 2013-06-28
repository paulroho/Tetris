Feature: Automatic behaviour of the game
	In order to add thrill to playing the game
	As a time ticker
	I want to automatically move the game towards its end

Background: 
	Given I have a game
	And the game is running

Scenario: Observe initial state
	When I do not tick
	Then the game has no current piece

Scenario: Throw new piece on the game
	Given there is no current piece
	When I tick
	Then a new piece is put into the game
	And the piece is on the top row
# ToDo: On a unit test level, ensure that the kind (shape, colour) as well as the orientation and position of the new piece are random