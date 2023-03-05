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


<br>

## **Term 2**

I was not able to work on my project as much as I had wanted to during the first weeks of Term 2 due to various circumstances (working on assignments for other modules, my job, etc...). I will however carry out the rest of the work in the remaining time I have.

<br>

 - ***Week 23*** 
    - *Sunday, 19:42* - Reworked the enemy movement code to make it more readable and make the moving smoother. Fixed the issues with the score not updating/displaying as well as the player spaceship not being destroyed on collision. Turns out, with the spaceship being a kinematic body, collisions were not being registered correctly; this was fixed by enabling "On Trigger" for the spaceship game object. The score was not getting updated on collision because I currently have multiple duplicated of the enemy game object, hence the score was set to 0 for all and kept resetting to that upon collision of one. This was fixed by making the score variable static. However, this enemy system will need to be changed to prefabs instead of multiple entities to simplify and to take up less memory.
    This work was done slowly ober the course of multiple weeks as I have been busy with other modules.


<br>

 - ***Week 24*** 
    - *Friday, 10:13* - Implemented an enemy spawner system using prefabs instead of simply duplicating the same game object multiple times in the scene. This allows the game to spawn multiple enemies only while the game is running and delete them as soon as they are destroyed. The score system was updated accordingly to work with the new system.
    Designed a simple start button sprite and implemented a rudimental start screen: just a background with the start button displayed, which will on click load the main scene, immediately starting a game. <br>
    I struggled for way too long to make the score system work correctly... The problem was a very annoying combination of not having the text object as a prefab and not having that prefab linked to the correct variable. I plan to get the start screen done soon, the I will procede to implement the next levels. <br>
    Code definitely needs more comments.

    - *Sunday, 09:24*  - Implemented a lives system for the player. The player will now have 3 lives available, which will be shown as heart sprites on the bottom right of the screen. Upon detecting collision from an enemy bullet, the player will lose one life and a sprite will disappear. After losing the last life, the player spaceship is destroyed and a basic game over screen is shown. This screen features a "play again", which will restart the game scene, and a "main menu" button, which for now just loads the start screen. <br>
    Sprites for the lives and a few power-ups have been designed and added to assets. I will next try to implement the power-up system.