@UI
Feature: Initial screen
  Shows a welcome message and allows to start a new game

@UI
Scenario: Welcome message
  Given I start the application
  Then I should see the message "Welcome to Tennis 2.0"

@UI
Scenario: Game start
  Given I start the application
	When I start the game with "Federer" and "Nadal"
  Then I should see the message "Federer vs Nadal"

@UI
Scenario: First player validation
  Given I start the application
	When I start the game with "" and "Nadal"
  Then I should see the error message "You should input a name for the first player"

@UI
Scenario: Second player validation
  Given I start the application
	When I start the game with "Carlos" and ""
  Then I should see the error message "You should input a name for the second player"
