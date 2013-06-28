@wip
Feature: Interaction with the current piece
	In order to play the game
	As a player
	I want to be able to move, rotate and drop the current piece

Background: 
	Given I have a game
	And the game is running
	And there is a current piece

###############################################
# Movements
Scenario: Move piece to the left
	Given the current piece has space to the left
	When I invoke "move left"
	Then the current piece moves by one column to the left

Scenario: Do nothing when piece cannot move to the left
	Given the current piece has no space to the left
	When I invoke "move left"
	Then the current piece does not move

Scenario: Move piece to the right
	Given the current piece has space to the right
	When I invoke "move right"
	Then the current piece moves by one column to the right

Scenario: Do nothing when piece cannot move to the right
	Given the current piece has no space to the right
	When I invoke "move right"
	Then the current piece does not move

Scenario: Drop the piece
	Given there is no obstacle under the piece
	When I invoke "drop"
	Then the current piece is on the bottom

###################################################
# Rotations
Scenario Outline: Rotate piece
	Given the current piece has orientation <oldOrientation>
	#And the piece has place to rotate <direction>
	When I invoke "rotate <direction>"
	Then the current piece has orientation <newOrientation>

	Examples: 
	| oldOrientation | direction        | newOrientation |
	| Up             | Clockwise        | ToTheRight     |
	| Up             | CounterClockwise | ToTheLeft      |
	| ToTheRight     | Clockwise        | Down           |
	| ToTheRight     | CounterClockwise | Up             |
	| Down           | Clockwise        | ToTheLeft      |
	| Down           | CounterClockwise | ToTheRight     |
	| ToTheLeft      | Clockwise        | Up             |
	| ToTheLeft      | CounterClockwise | Down           |
