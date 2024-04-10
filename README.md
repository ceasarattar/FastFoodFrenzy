# FastFoodFrenzy

Design Document: https://docs.google.com/document/d/1LEbpRQLCe0r5HXCz9P28s9qdZUO2kae4InZcFk603Nc/edit?usp=sharing

Game Pitch Presentation: https://docs.google.com/presentation/d/1RiOO_XcF798fW0oohXUHgdEOtb93tYHzK0_BRA0F89M/edit?usp=sharing

4/10/24 Update:
---------------------

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



4/3/24 update:
---------------------
- Dining Area: Added to simulate a more realistic restaurant environment, complete with tables and seating arrangements to accommodate customer NPCS.
- Visual Enhancements: Updated textures and lighting to improve the aesthetic appeal and ambiance of the restaurant; added new light sources.
- Prefabs: Introduced various new prefabs such as order kiosk, cash register, counters, and cookware to populate the restaurant.
- Map Layout: Adjusted to add complexity to the game environment.
- Mecanim Animations: Utilized to animate the door (Ceasar) and NPC (door opens and closes on left click, NPC sitting and waiting for food).
- NPC AI Construct: Implemented using a Finite State Machine to determine NPC behaviors, including standing idle, transitioning to an angry state when the timer runs low (Kevin), and movement around the dining area (Michelle).

Summary:
Added dining area with seats and tables
Updated visuals
-Added new wall textures
-Added new prefabs to create restaurant environment
-Order kiosk, cash register, counters, cookware
-Added new light sources
Changed player visuals
-Chef character
Changed map layout to add complexity
Added mecanim to door
-Animated to open and close on left click
Added NPC AI construct
-NPC stands happily, after timer goes below 100 seconds the animation changes to be angry
-FSM decides what state to be in
-WIP of NPC movement, walking around the dining area, sitting


Future Updates:
------------
- Complete NPC movement implementation, including pathfinding and interaction with the environment.
- Refine NPC AI behaviors to include more states and interactions with players.
- Continuously iterate on visuals and environment design to enhance immersion and gameplay experience.

