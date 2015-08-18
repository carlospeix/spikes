@UI
Feature: Juego
	In order to keep the game evolution
	As an umpire
	I wish to signal points and see the board updated

@UI
Scenario: Game starts 0 - 0
	Given I start the game with two players
	Then the result should be "0 - 0"
