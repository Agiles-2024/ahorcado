Feature: Ahorcado

  Scenario: Successfully Guessing a Letter
    Given I navigate to the game page with word "ciudad"
    When I enter the letter "a"
    Then I should see the message "Letra 'a' encontrada!"

  Scenario: Unsuccessfully Guessing a Letter
    Given I navigate to the game page with word "ciudad"
    When I incorrectly enter the letter "t"
    Then I should see the message "Letra 't' no encontrada."

  Scenario: Winning the Game Guessing The Whole Word
    Given I navigate to the game page with word "test"
    When I enter the word "test"
    Then I should see the message "¡Ganaste!"

  Scenario: Winning the Game inputting letter by letter
    Given I navigate to the game page with word "test"
    When I enter the letters "t,e,s"
    Then I should see the message "¡Ganaste!"

  Scenario: Losing the Game inputting letter by letter
    Given I navigate to the game page with word "test"
    When I enter the letters "a,c,v,b,w,r"
    Then I should see the message "¡Perdiste!"