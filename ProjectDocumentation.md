# Game Basic Information #

## Summary ##
You are a screen-addicted student stuck in a maze (Shields Library) studying late at night, and you’ve lost track of the time. Your phone is about to run out of battery, and you need to find an outlet before your phone dies. Eduroam is down again and you have no data, so you won't be able to contact the outside world for help. The library lights have gone out already, so the only source of light you have left at your disposal is your phone’s flashlight. You’ll need to manage your power very carefully if you want to escape with your life find that outlet. Your phone’s flashlight can be made brighter to increase your range of sight, at the expense of lowering your battery faster. If your phone battery dies before you find the outlet, you will be stuck in the library’s labyrinth without any source of light to navigate, thus losing the game.

## Gameplay Explanation ##

Controls:
- WASD or joystick/thumbstick for movement
- "Fire1" (e.g. left click mouse button) for flashlight active mode

Recommended Strategy:
- The player will start out at a random location in the maze. The player's first priority should be to find the location of the outlet. Use the flashlight's active mode to expand range-of-sight and locate the outlet. 
- After finding the outlet, use the flashlight to scout out the path leading to the outlet. Memorize the path, and turn on off the flashlight's active mode to conserve battery.
- Follow the memorized path, and repeat the previous steps as necessary.


**If you did work that should be factored in to your grade that does not fit easily into the proscribed roles, add it here! Please include links to resources and descriptions of game-related material that does not fit into roles here.**
See "Assistance/Odds and Ends" heading.
-Chance Lau

# Main Roles #

Your goal is to relate the work of your role and sub-role in terms of the content of the course. Please look at the role sections below for specific instructions for each role.

Below is a template for you to highlight items of your work. These provide the evidence needed for your work to be evaluated. Try to have at least 4 such descriptions. They will be assessed on the quality of the underlying system and how they are linked to course content. 

*Short Description* - Long description of your work item that includes how it is relevant to topics discussed in class. [link to evidence in your repository](https://github.com/dr-jam/ECS189L/edit/project-description/ProjectDocumentTemplate.md)

Here is an example:  
*Procedural Terrain* - The background of the game consists of procedurally-generated terrain that is produced with Perlin noise. This terrain can be modified by the game at run-time via a call to its script methods. The intent is to allow the player to modify the terrain. This system is based on the component design pattern and the procedural content generation portions of the course. [The PCG terrain generation script](https://github.com/dr-jam/CameraControlExercise/blob/513b927e87fc686fe627bf7d4ff6ff841cf34e9f/Obscura/Assets/Scripts/TerrainGenerator.cs#L6).

You should replay any **bold text** with your relevant information. Liberally use the template when necessary and appropriate.

## User Interface

(Main-Role: Risa Sathe)

Implementation of the main menu, quit game, lose game, and win game scenes were designed and implemented to enhance user interface. This was done to provide players a better sense of visual representation of our game. 
[main menu script](https://github.com/charmychancey/MazeRush/blob/main/MazeRush/Assets/Scripts/Mainmenu.cs),
[losegame and win game script](https://github.com/charmychancey/MazeRush/blob/main/MazeRush/Assets/Scripts/LoseGame.cs),
[scenes](https://github.com/charmychancey/MazeRush/tree/main/MazeRush/Assets/_Scenes).

A health bar was also implemented to show the battery level of the phone, so that the player knows how much battery is left to find a power outlet as soon as possible before the player dies. This was inspired from the healthbar used in assignment 4. [health bar script](https://github.com/charmychancey/MazeRush/blob/main/MazeRush/Assets/HealthBar.cs)

In addition, the overall environment was also implemented, such as the flooring to make it look similar to the floor in the library.

## Assistance/Odds and Ends

(Continued Main-Role: Risa Sathe)

* _Animation_: Assited in implementing player animation, and also assisted in player movement and motion.  

## Movement/Physics

(Main-Role: Donald Lieu)

*Standard Physics Movement* - Our game uses the standard Unity physics model for movement. We apply forces to the player while input is being recieved and allow the physics system to control the release period of our movement curve. We shortened the "release" period of the movement curve to make the controls feel more crisp by adjusting the drag field of the rigidbody. At the same time, the "release" period is still long enough so that it feels like the character has some weight behind them without sliding around. [movement script](https://github.com/charmychancey/MazeRush/blob/1f19f84134bd99e4587d8c9f43490f60e696a70a/MazeRush/Assets/Scripts/MovePlayer.cs)

## Assistance/Odds and Ends
(Continued Main-Role: Donald Lieu)

*Cursor-tracking* - I wrote the [code](https://github.com/charmychancey/MazeRush/blob/1f19f84134bd99e4587d8c9f43490f60e696a70a/MazeRush/Assets/Scripts/LightController.cs#L51-L56) that returns the cursor's angle relative to the player. This is used for the rotation of the flashlight and player model.
*Flashlight rotation* - The flashlight source needs to be rotated to follow the cursor for responsive controls. (https://github.com/charmychancey/MazeRush/blob/1f19f84134bd99e4587d8c9f43490f60e696a70a/MazeRush/Assets/Scripts/LightController.cs#L59)
*Maze-generation* - The entire premise of the game requires that the player be stuck in a confusing environment. What better environment to be confused in than a maze? Our controller uses random depth first traversal or "recursive backtracking" as the generation algorithm. Once the maze data is generated, we algorithmically shape the map and spawn the wall prefabs in to create the maze. The walls could be any size, so we must scale them correctly by considering their bounds in the Renderer or Collider component. Additionally, some prefabs have their pivot located away from the center. The controller considers this and wraps the prefab in an empty parent object so that the scaling can be done according to their center. This system is based on the procedural content generation portion of the course. [source](https://github.com/charmychancey/MazeRush/blob/1f19f84134bd99e4587d8c9f43490f60e696a70a/MazeRush/Assets/Scripts/MazeGenerationController.cs)
*Double-sided Bookshelf* - The bookshelf prefab we used was one-sided so I fixed this for a more consistent feel across the map. This was fixed by creating a new parent object and dublicating the prefab. Surprisingly, this created a bug in our maze generation controller because the parent object doesn't contain a Collider component. As a hotfix, we simply look for any collider in the children and use those values for the scaling.

## Animation and Visuals

(Main-Role: Mirthala Lopez)

**List your assets including their sources and licenses.**

1. [Toony Tiny People Demo](https://assetstore.unity.com/packages/3d/characters/toony-tiny-people-demo-113188) - [License](https://unity3d.com/legal/as_terms?_ga=2.170576864.196383405.1623199583-255437453.1617059752)

2. [Snaps Office Prototypes](https://assetstore.unity.com/packages/3d/environments/snaps-prototype-office-137490) - [License](https://unity3d.com/legal/as_terms?_ga=2.170576864.196383405.1623199583-255437453.1617059752)

3. [Survival Kit Lite](https://assetstore.unity.com/packages/3d/props/tools/survival-kit-lite-92549#content) - [License](https://unity3d.com/legal/as_terms?_ga=2.170576864.196383405.1623199583-255437453.1617059752)

4. [Free Phone](https://assetstore.unity.com/packages/3d/props/free-phone-181455) - [License](https://unity3d.com/legal/as_terms?_ga=2.170576864.196383405.1623199583-255437453.1617059752)

*Character Design* - The 'Toony Tiny People' asset from the Unity Store included characters from a zombie-related game. The somewhat dirty and disheveled appearance of the character adds to the ominious feel of our game. Additionally, the character prefab had a hand container in which we were able to use the 'Free Phone' asset to make it look like the character was holding up a phone with the flashlight pointing outwards.

*Environment Design* - After implementing the maze walls, we decided against using the wall prefabs within the 'Snaps Office Prototype' asset (All the walls would appear vertical). We settled for using materials from the same asset to let the walls look blank and dreary. The portable battery items that can be found across the map use the battery prefab from the 'Survival Kit' asset. In addition, our outlet prefab uses material from the same asset. 

## Assistance/Odds and Ends

(Continued Main-Role: Mirthala Lopez)

*UI - Exposition Scene* - I added an extra notification box to appear with a 'Battery Low!' message to give the player a small sense of panic. I implemented the notification so that when the box was clicked, it would disable the notification box and enable the exposition boxes, leading to the overall Exposition scene. 

## Input

(Main-Role: Chance Lau)

*Command Pattern Input Design* - A command pattern was used to implement actions by the main player object. By implementing a IPlayerCommand interface, I created a MovePlayer command to handle input for player movement in a 2-D fashion, and a UseFlashlight command to handle input for using the flashlight in our game. By creating a command pattern-inspired design, we would easily be able to add more input-actions to our player in the future. This was especially desirable, because we initially had a lot of stretch goals for additional tools(such as a drill to break walls) that would be an additional command to link to input(unfortunately we did not have enough time to implement our stretch goal of the drill). This system was inspired by the command pattern as covered in Week 1 and 2 of the course. [The MovePlayer script that implements IPlayerCommand](https://github.com/charmychancey/MazeRush/blob/1088587fead009209b523d08964a05bb872d0666/MazeRush/Assets/Scripts/MovePlayer.cs#L7).

Since the Input role was minimal in our project, I spent a lot of time all around in the other parts/roles in the project.

See the "Assistance/Odds and Ends" heading for more details on my contributions.

*Keyboard*

## Assistance/Odds and Ends

(Continued Main-Role: Chance Lau)

*Game Logic - Dynamic Flashlight* - An aesthetic as well as technical centerpiece to the game, the flashlight is a spot light attached to the player object that grows in range when the appropriate input is held down. Calls to player controller script is made each frame to modify the range of the flashlight. The flashlight is essential, because it is the player's primary source of scouting information about the layout of the maze. It is part of the main gameplay loop. This system is based on ECS189L Week 4's topic of game mechanics. [The UseFlashlight script](https://github.com/charmychancey/MazeRush/blob/2898cc0d8c863a00daa57c56b7f925a392bf96ca/MazeRush/Assets/Scripts/UseFlashlight.cs#L8).

*UI - Exposition Scene and System/Interface* - The lore/story for the game is presented as textbox messages on a phone. This was achieved using a phone gameobject overlayed with a UI for the textbox and animation. The exposition system uses a Controller that loads up Expositions(which contain strings) in a queue. Each Exposition represents a separate "message" on the phone in-game. When the player clicks the "next" button on the UI-layer, the current Exposition is dequeued, the in-game message updates, and the animation plays. I created custom animations in the Unity Animation involving changes in transform and alpha values and created transition states in the Unity Animator. This Exposition system was inspired by component design patterns as covered in Week 4 of ECS189L. [The ExpositionController script](https://github.com/charmychancey/MazeRush/blob/2898cc0d8c863a00daa57c56b7f925a392bf96ca/MazeRush/Assets/Scripts/ExpositionController.cs#L11).


## Game Logic

(Main-Role: Andrew Lam)

*Battery Management System and Flashlight* - The battery component is attached to the PlayerController and is responsible for the main gameplay loop, as its level will need to be managed by the player or else they will lose the game once it runs out. It has a passive linear drain based on what the DrainRate value has been set to, and to add a tradeoff for turning up the brightness of the flashlight, the DrainRate is increased by a factor of the current flashlight's level. The PlayerController calls the methods to manage the battery every frame within its Update() function, which other components can also use to update their states (e.g. the battery display UI). There is also logic for portable battery powerups to increase the current level of the battery upon colliding with them. [DefaultBattery Script](https://github.com/charmychancey/MazeRush/blob/main/MazeRush/Assets/Scripts/DefaultBattery.cs)

*Win/Lose Condition Logic* - The PlayerController also manages the win/lose conditions of the game, as a check for running out of battery will cause the game to transition to the "You Lose" scene, and the player colliding with the "Outlet" object will transition to the "You Win" screen. The check for whether the battery has run out is also called within the Update() function so that the game state is updated immediately. [Win Check](https://github.com/charmychancey/MazeRush/blob/1f19f84134bd99e4587d8c9f43490f60e696a70a/MazeRush/Assets/Scripts/PlayerController.cs#L101) and [Lose Check](https://github.com/charmychancey/MazeRush/blob/1f19f84134bd99e4587d8c9f43490f60e696a70a/MazeRush/Assets/Scripts/PlayerController.cs#L190)

# Sub-Roles

## Audio

(Sub-Role: Risa Sathe)

Assets used were 
[amb_deep_space3 and amb_run_end for background music](https://assetstore.unity.com/packages/audio/sound-fx/horror-elements-112021),
[footstep_Tile_walk_4  for player footsteps ](https://assetstore.unity.com/packages/audio/sound-fx/foley/footsteps-essentials-189879 ),
[sfx lamp wave for flashlight sound](https://assetstore.unity.com/packages/audio/sound-fx/lamp-wave-85404),
[Game over sound](https://assetstore.unity.com/packages/audio/sound-fx/voices/a-voice-over-for-game-over-132171 ),
[another game over sound](https://assetstore.unity.com/packages/audio/sound-fx/horror-elements-112021),
[and win game sound](https://youtu.be/DQweLHdlVWo).

Audio was implemented to enhance the game feel to make it more exciting. Therefore a background sound was implemented to give a spooky feel, as the game is set in such a way that the player is all alone in shields library with no source of light around. To amplify that effect, a "horror" sound effect was used. Further, to improve sound effects, footstep sounds were implemented for the animated character. In addition, a sound effect was given for the flashlight to help the player understand that the light level is increasing and there is still hope to win. 
[All audios](https://github.com/charmychancey/MazeRush/tree/main/MazeRush/Assets/Audio).

A win game audio was provided which is an upbeat sound to celbrate the victory of the player. 
A lose game audio that was implemented which provides a sense of gloominess and also a sense of terror to align with the sound style of this game. 

Overall, the sound style of this game is omnious.

## Gameplay Testing

**Add a link to the full results of your gameplay tests.**
https://docs.google.com/spreadsheets/d/1O8HVkgdB76xU3Y4JfA_ys92TtVN9dAo-P3gaGdQ1VdA/edit?usp=sharing

**Summarize the key findings from your gameplay tests.**
- MVP features are fully functional
- Windows and Mac compatible
- The experimental number of batteries spawned per maze is 0.9 in 10 trials, close to the expected number of 1.

## Narrative Design

**Document how the narrative is present in the game via assets, gameplay systems, and gameplay.** 

## Press Kit and Trailer

(Sub-role: Andrew Lam)

[Press kit](https://charmychancey.github.io/MazeRush/build/product/index.html)
[Trailer](https://www.youtube.com/watch?v=RDxi44YU0K0)

We wanted to showcase the narrative behind our game to make it more engaging to players while also making sure that it tied directly to the actual gameplay. In addition, we wanted to highlight the most significant features that made our game interesting, such as the relationship between the flashlight to navigate the maze and your battery level, as well as the random maze generation for each playthrough.

## Game Feel

(Sub-Role: Chance Lau)

*Dynamic Background Audio* - Initially, the background music was static in terms of volume. I changed it so that the player would feel a greater sense of urgency as they ran out of battery. After the update, the background music changes volume based on how much charge remains in the phone's battery. The volume distribution follows an exponential curve, so that as the battery depletes, the music gets louder faster. Minimum volume is marked at the initial battery charge when the player loads in, and maximum volume is marked when the player is nearly at 0% battery remaining. This design intersects with ECS189L Week 4's topic of game mechanics and the topic of game feel covered in ECS189L Week 7. [The dynamic mechanism/logic from the backgroud audio function](https://github.com/charmychancey/MazeRush/blob/2898cc0d8c863a00daa57c56b7f925a392bf96ca/MazeRush/Assets/Scripts/PlayerController.cs#L149).

*Battery-Drain Tweaks* - Initially, the battery was draining too slowly to create an appropritate sense of urgency. I increased the general drain rate, and started the player off with a lower initial, remaining battery charge. There was also an imbalance between the passive and active drain rates of the phone's flashlight. The default range drained the battery too slowly while the max range drained the battery too fast. This meant that we had to give enough charge to allow the player to feasibly utilize the flashlight's active mode, but then that would give the player way too much time if they decided to solve the maze by brute force. Thus, to make the game feel more practical and believable, I decreased the difference in drain rates between the two extremes by changing the drain rate formula. This tweak was made in consideration of topic of game feel as covered in ECS189L Week 7. [The battery script for the phone/flashlight](https://github.com/charmychancey/MazeRush/blob/2898cc0d8c863a00daa57c56b7f925a392bf96ca/MazeRush/Assets/Scripts/DefaultBattery.cs#L5).
