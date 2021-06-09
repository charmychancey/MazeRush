# Game Basic Information #

## Summary ##

**A paragraph-length pitch for your game.**

## Gameplay Explanation ##

**In this section, explain how the game should be played. Treat this as a manual within a game. It is encouraged to explain the button mappings and the most optimal gameplay strategy.**


**If you did work that should be factored in to your grade that does not fit easily into the proscribed roles, add it here! Please include links to resources and descriptions of game-related material that does not fit into roles here.**

# Main Roles #

Your goal is to relate the work of your role and sub-role in terms of the content of the course. Please look at the role sections below for specific instructions for each role.

Below is a template for you to highlight items of your work. These provide the evidence needed for your work to be evaluated. Try to have at least 4 such descriptions. They will be assessed on the quality of the underlying system and how they are linked to course content. 

*Short Description* - Long description of your work item that includes how it is relevant to topics discussed in class. [link to evidence in your repository](https://github.com/dr-jam/ECS189L/edit/project-description/ProjectDocumentTemplate.md)

Here is an example:  
*Procedural Terrain* - The background of the game consists of procedurally-generated terrain that is produced with Perlin noise. This terrain can be modified by the game at run-time via a call to its script methods. The intent is to allow the player to modify the terrain. This system is based on the component design pattern and the procedural content generation portions of the course. [The PCG terrain generation script](https://github.com/dr-jam/CameraControlExercise/blob/513b927e87fc686fe627bf7d4ff6ff841cf34e9f/Obscura/Assets/Scripts/TerrainGenerator.cs#L6).

You should replay any **bold text** with your relevant information. Liberally use the template when necessary and appropriate.

## User Interface

**Describe your user interface and how it relates to gameplay. This can be done via the template.**

## Movement/Physics

**Describe the basics of movement and physics in your game. Is it the standard physics model? What did you change or modify? Did you make your movement scripts that do not use the physics system?**

## Animation and Visuals

**List your assets including their sources and licenses.**

**Describe how your work intersects with game feel, graphic design, and world-building. Include your visual style guide if one exists.**

## Input

(Main-Role: Chance Lau)
*Command Pattern Input Design* - A command pattern was used to implement actions by the main player object. By implementing a IPlayerCommand interface, I created a MovePlayer command to handle input for player movement in a 2-D fashion, and a UseFlashlight command to handle input for using the flashlight in our game. By creating a command pattern-inspired design, we would easily be able to add more input-actions to our player in the future. This was especially desirable, because we initially had a lot of stretch goals for additional tools(such as a drill to break walls) that would be an additional command to link to input(unfortunately we did not have enough time to implement our stretch goal of the drill). This system was inspired by the command pattern as covered in Week 1 and 2 of the course. [The MovePlayer script that implements IPlayerCommand](https://github.com/charmychancey/MazeRush/blob/1088587fead009209b523d08964a05bb872d0666/MazeRush/Assets/Scripts/MovePlayer.cs#L7).

Since the Input role was minimal in our project, I spent a lot of time all around in the other parts/roles in the project.

See the "Assistance/Odds and Ends" heading for more details on my contributions.

*Keyboard*

*Joystick/Controller*

## Assistance/Odds and Ends
(Continued Main-Role: Chance Lau)

*Game Logic - Dynamic Flashlight* - An aesthetic as well as technical centerpiece to the game, the flashlight is a spot light attached to the player object that grows in range when the appropriate input is held down. Calls to player controller script is made each frame to modify the range of the flashlight. The flashlight is essential, because it is the player's primary source of scouting information about the layout of the maze. It is part of the main gameplay loop. This system is based on ECS189L Week 4's topic of game mechanics. [The UseFlashlight script](https://github.com/charmychancey/MazeRush/blob/2898cc0d8c863a00daa57c56b7f925a392bf96ca/MazeRush/Assets/Scripts/UseFlashlight.cs#L8).

*UI - Exposition Scene and System/Interface* - The lore/story for the game is presented as textbox messages on a phone. This was achieved using a phone gameobject overlayed with a UI for the textbox and animation. The exposition system uses a Controller that loads up Expositions(which contain strings) in a queue. Each Exposition represents a separate "message" on the phone in-game. When the player clicks the "next" button on the UI-layer, the current Exposition is dequeued, the in-game message updates, and the animation plays. I created custom animations in the Unity Animation involving changes in transform and alpha values and created transition states in the Unity Animator. This Exposition system was inspired by component design patterns as covered in Week 4 of ECS189L. [The ExpositionController script](https://github.com/charmychancey/MazeRush/blob/2898cc0d8c863a00daa57c56b7f925a392bf96ca/MazeRush/Assets/Scripts/ExpositionController.cs#L11).

## Game Logic

**Document what game states and game data you managed and what design patterns you used to complete your task.**

# Sub-Roles

## Audio

**List your assets including their sources and licenses.**

**Describe the implementation of your audio system.**

**Document the sound style.** 

## Gameplay Testing

**Add a link to the full results of your gameplay tests.**

**Summarize the key findings from your gameplay tests.**

## Narrative Design

**Document how the narrative is present in the game via assets, gameplay systems, and gameplay.** 

## Press Kit and Trailer

**Include links to your presskit materials and trailer.**

**Describe how you showcased your work. How did you choose what to show in the trailer? Why did you choose your screenshots?**



## Game Feel

(Sub-Role: Chance Lau)

*Dynamic Background Audio* - Initially, the background music was static in terms of volume. I changed it so that the player would feel a greater sense of urgency as they ran out of battery. After the update, the background music changes volume based on how much charge remains in the phone's battery. The volume distribution follows an exponential curve, so that as the battery depletes, the music gets louder faster. Minimum volume is marked at the initial battery charge when the player loads in, and maximum volume is marked when the player is nearly at 0% battery remaining. This design intersects with ECS189L Week 4's topic of game mechanics and the topic of game feel covered in ECS189L Week 7. [The dynamic mechanism/logic from the backgroud audio function](https://github.com/charmychancey/MazeRush/blob/2898cc0d8c863a00daa57c56b7f925a392bf96ca/MazeRush/Assets/Scripts/PlayerController.cs#L149).

*Battery-Drain Tweaks* - Initially, the battery was draining too slowly to create an appropritate sense of urgency. I increased the general drain rate, and started the player off with a lower initial, remaining battery charge. There was also an imbalance between the passive and active drain rates of the phone's flashlight. The default range drained the battery too slowly while the max range drained the battery too fast. This meant that we had to give enough charge to allow the player to feasibly utilize the flashlight's active mode, but then that would give the player way too much time if they decided to solve the maze by brute force. Thus, to make the game feel more practical and believable, I decreased the difference in drain rates between the two extremes by changing the drain rate formula. This tweak was made in consideration of topic of game feel as covered in ECS189L Week 7. [The battery script for the phone/flashlight](https://github.com/charmychancey/MazeRush/blob/2898cc0d8c863a00daa57c56b7f925a392bf96ca/MazeRush/Assets/Scripts/DefaultBattery.cs#L5).