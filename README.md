# FastFoodFrenzy

Design Document: https://docs.google.com/document/d/1LEbpRQLCe0r5HXCz9P28s9qdZUO2kae4InZcFk603Nc/edit?usp=sharing

Game Pitch Presentation: https://docs.google.com/presentation/d/1RiOO_XcF798fW0oohXUHgdEOtb93tYHzK0_BRA0F89M/edit?usp=sharing


Beta Release:
- Included an opening scene to make the game feel more complete. (Start menu with a start button)
- Added an instructions screen after opening screen to give the player directions
- Included shaders on wooden counters, on kitchen appliances (Fridge, stove, and etc.), and on the dining room floor to add visual contrast.
- Added a custom shader to food items for a more realistic look
- Added a shader to the tray
- Added a cook character model to the player
- Added mecanim animations for jogging, walking backwards and crouching
- Moved serving tray to front counter (play testers would go to front counter first)
- Implemented an end screen with credits
- Added more appliances/visuals to empty corner
- Fixed slight inconsistencies in walls
- Added a credits scene when game orders hit the limit (currently set at 2)
- Adjust counter height to work with new character model
- Adjusted pick up distance for easier interactions
- Added instructions when in range to pick up item



UI Design:
Before - UI text elements were in red which did not match
After - Changed the color of the elements to white to match the theme - Ceasar

Before - Kitchen walls and floor had no textures
After - Added textures to walls and floor - Kevin

Before - There was no indicator of where the character's pickup area is at on the screen
After- We added a small black square in the middle of the screen to help the player identify where the player can pick up items at - Kevin

Before - Player couldn't pick up food items when they are dropped on floor
After - Added a crouch feature so that the player can crouch to pick up dropped items - Kevin

Before - Picking up items had a large area so sometimes a different item would be picked up
After - Made the pick up area smaller to make picking up items more precise - Michelle

Before - Some items like the cookie, hotdog, and pretzel were a bit small
After - enlarged food items to increase visibility and accessibility by the player - Michelle

Before - Back corner of the kitchen did not have a light so there was poor visibility
After- Added a light source in the back of the kitchen to increase visibility - Ceasar

Before - Not all walls were completely closed, causing gaps in the walls
After - Realigned walls to make sure there are no gaps - Michelle

Before - There were no instructions on how to control the character / play and complete the game
After - Added (in a .txt file) instructions on how to move the character and interact with the items, and how to play and complete the game - Ceasar

Sound Design:
Game Title - Chef Life, A Restaurant Simulator
Kevin - 
Main menu music - In the main menu, the acoustic guitar music impacts the visual of a kitchen in the background by giving it a relaxed/restaurant feel.

Trailer music - After the player starts the game, there is a trailer with upbeat music while a preview of the game is given. The jazzy/upbeat music helps make the gameplay create a more exciting feeling.

Ceasar - 
Music during instructions - The music when the instructions are on screen is decreased in volume. This balance is to help the player better focus on reading the instructions rather than having loud music playing.

Sounds Effects - There are different sound effects for each event like washing dishes, walking , cooking. These different sounds help enhance the immersion of the player when they are performing each task. It makes the player feel more involved as the sound correlates with the task.

Michelle - 
No music - When the player interacts with dialogue with an NPC there is no music. Having no music most likely helps the player read and comprehend the dialogue easier

Different Background music - For the various missions in the game there is different background music being played. The variety of sound tracks allows the gameplay to not feel repetitive and mundane.



Implemented sounds - 
Added ambient noise - This sound was implemented because it was just silent before and the ambient noise makes the player feel like they are in a fast food restaurant.

Added background music in the dining area - Having an upbeat elevator music helps create a more relaxing mood for the player.

Added cooking and cutting noise in the kitchen area - Including these sound effects were ultimately accepted because we wanted to make the player feel more immersed with the actions they were performing in game.

Picking up and setting down food item sounds  - We accepted this sound effect because we wanted to create an extra indicator to the player to when they are picking up an item and when they drop it. This also ensures more clarity for the player.

