# ***FYP Diary*** 

This is a diary that will document my progress of the development of my game. 

<br>

## **Term 1**

<br>

- ***Week 1-7*** <br>
The first weeks were used to carry out research and lay the groundwork for my project. As I had never used a game engine such as Unity before, I took a few weeks to familiarise myself with the engine and with C#, the language used by Unity (which was also new to me).  In addition, I also dedicated some time to study the basics of game development as a whole in order to understand what kind of approach I should take towards my FYP.

<br>

- ***Week 8*** 
    - *Monday, 19:15* - Pushed my empty project to my repository together with a new created .gitignore file.

<br>

- ***Week 9*** 
    - *Monday, 21:17* - Designed my own first sprite for an initial spaceship (may be subject to change) in a pixel editor. Added it to my Unity project as well as some basic code to implement left and right movement with the A and D keys.

    - *Thursday, 16:02* - Started drafting my interim report. Planned for some of it contents: part of the project plan will be used, such as the planning and the risk assessment. I will update my aims for the game and include these diary entries too.

<br>

 - ***Week 10*** 
    - *Wednesday, 15:14* - Noticed an issue with the sprite movement that caused the sprite to slide a little after letting go of the key instead of coming to a full stop. This was solved by changing Input.GetAxis() to Input.GetAxisRaw(), as the first one returned a float instead of either 1 or 0, causing the sprite to slide. <br>
    Also started the implementation of the spaceship's bullet mechanics. Only one bullet implemented so far with a simple script to spawn it and make it travel across the screen. I will add a timer to delete bullets after a few seconds. <br>
    Sprites need reworking as I would like to keep them as 16, or maybe 32 bits.

    - *Thursday, 15:45* - Implemented bullet shooting mechanics for one gun, player can now move and shoot. The bullets are deleted after one second to not fill the memory. I will add a power up for multiple guns later on. <br>
    Started designing an enemy sprite.

    - *Friday, 20:48* - Finished designing the enemy sprite. Implemented code for the enemy to spawn at the top of the screen and slowly move towards the left. Upon reaching the end of the screen, it will move one level down and start moving the opposite direction at x1.25 its initial speed. The speed will keep increasing after every "level".
    Redesigned spaceship sprite.

    - *Sunday, 15:21* - Player's bullets can now kill enemies. 2 rows of enemies spawn and move like previously described, fire bullets at the player randomly and on a cooldown. Collision is handled by Unity box collider. Moving background has also been implemented. Enemies seem to "fall" through the screen sometimes, will need fixing.

<br>

 - ***Week 11*** 
    - *Wednesday, 18:09* - Structured the report and wrote the following sections: Abstract, Game Overview, Methodology, Tools, Visual Design.