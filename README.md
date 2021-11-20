# BowlingDoubleGame
net5, UoW, factory, SQL ioc Mongo, Singleton, 5 sec cache, EF, unit testing


# Logic of the Game
Based on a real game we have two availabe chances to complete a general game.
That is the reason the general model is based like:
1. GameSetup (General game configuration/rules, includes player reference and is the root of games)
2. Game (Two chances for each GameSetup)
3. Player (Person who performs the game)
