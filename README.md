# FastFoodFrenzy

Design Document: https://docs.google.com/document/d/1LEbpRQLCe0r5HXCz9P28s9qdZUO2kae4InZcFk603Nc/edit?usp=sharing

Game Pitch Presentation: https://docs.google.com/presentation/d/1RiOO_XcF798fW0oohXUHgdEOtb93tYHzK0_BRA0F89M/edit?usp=sharing

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

