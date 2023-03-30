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
    - *Sunday, 19:42* - Refactored the enemy movement code to make it more readable and make the moving smoother. Fixed the issues with the score not updating/displaying as well as the player spaceship not being destroyed on collision. Turns out, with the spaceship being a kinematic body, collisions were not being registered correctly; this was fixed by enabling "On Trigger" for the spaceship game object. The score was not getting updated on collision because I currently have multiple duplicated of the enemy game object, hence the score was set to 0 for all and kept resetting to that upon collision of one. This was fixed by making the score variable static. However, this enemy system will need to be changed to prefabs instead of multiple entities to simplify and to take up less memory.
    This work was done slowly ober the course of multiple weeks as I have been busy with other modules.


<br>

 - ***Week 24*** 
    - *Friday, 10:13* - Refactored the enemy system by implementing an enemy spawner using prefabs instead of simply duplicating the same game object multiple times in the scene. This allows the game to spawn multiple enemies only while the game is running and delete them as soon as they are destroyed. The score system was updated accordingly to work with the new system.
    Designed a simple start button sprite and implemented a rudimental start screen: just a background with the start button displayed, which will on click load the main scene, immediately starting a game. <br>
    I struggled for way too long to make the score system work correctly... The problem was a very annoying combination of not having the text object as a prefab and not having that prefab linked to the correct variable. I plan to get the start screen done soon, the I will procede to implement the next levels. <br>
    Code definitely needs more comments.

    - *Sunday, 09:24*  - Implemented a lives system for the player. The player will now have 3 lives available, which will be shown as heart sprites on the bottom right of the screen. Upon detecting collision from an enemy bullet, the player will lose one life and a sprite will disappear. After losing the last life, the player spaceship is destroyed and a basic game over screen is shown. This screen features a "play again", which will restart the game scene, and a "main menu" button, which for now just loads the start screen. <br>
    Sprites for the lives and a few power-ups have been designed and added to assets. I will next try to implement the power-up system.

<br>

 - ***Week 25*** 
    - *Tuesday, 20:49* - Implemented an initial power up system. So far, the two implemented power ups are a shield power up and a plus-one-life power up. The former grants the player a shield which makes it invulnerable to enemy bullets for 3 seconds. This is done by having collision detection disabled while the shield is active (the spaceship sprite is also replaced by a "shielded" alternate sprite for the duration). The latter instead simply lets the player gain back one life lost. If the player already has all 3 lives nothing will happen. Working on this power up allowed me to optimise LivesManager.cs by having heart sprites set to active/inactive instead of destroying them when a life is lost.
    All power ups spawn at the top of the screen and fall down slowly. The player can "catch" them as they fall and they are equipped upon collision with the spaceship. A gun power up is also currently in the game but it cannot be equipped for now. It will allow the player to have 2 guns, increasing fire rate. A score increasing power up will be implenented as well.

<br>

- ***Week 26*** 
    - *Monday, 20:14* - Finished implementing the power up system. The last two power ups are a score increaser (adds 10 to the score) and a gun power up that equips the player spaceship with two guns instead of one. Also changed the power up spawn interval so fewer power ups are spawned. To fix: the score power up can only be picked up if there are enemies on the screen, since it calls Enemy.cs and does so by searching for an object in the scene called "Enemy" and then accessing its components. Might fix this by having the power up reference Enemy.cs in a different way.
    A sprite for the first boss has been designed and added to assets, code for it will be added to EnemySpawner.cs next.

    - *Wednesday, 18:58* - Tried to implement the boss spawning. A lot of trial and error but I still have not found a good way to do this. I have tried classifying enemies by enemy type and having switch cases for each type (i.e. once no more enemies of type "Basic" where detected in the scene, switch to spawn enemies of type "Boss"). This overcomplicated the Enemy.cs and EnemySpawner.cs way too much and did not seem to work. I am now trying an approach by creating a different class for spawning the boss. The enemy type mechanic might need to be reimplemented cause the boss is currently not spawing at the correct time.

<br>

- ***Week 27***
    - *Thursday, 15:27* - I have been away from my main computer, hence I have only been able to work on sprites for new enemies and possibly different bullets. These will probably be committed and effectively added to the game next week once I am back.

<br>

- ***Week 28***
    - *Monday, 08:00* - Completed the boss implementation by refactoring parts of the initial code: the solution to my problem was so much simpler than I thought (as it usually happens...), I just needed to make the BossSpawner count the amount of objects with the "Enemy" tag or "Boss" tag (not to spawn infinite bosses) and then run the SpawnBoss() method. The boss now moves like the enemies but shoots 3 bullets at a time in a cone every 5 seconds, and has 50 hp.
    Also fixed the score power up issues by making a separate score manager script, so the score updates are no longer dependent on the enemy script.
    Finally, made a few tweaks to the game in general, like bullet cooldowns and sprites, basic enemies hp, power up durations, etc... to improve playability.
    Designs from last week have been added to the assets. Also started setting up a possible "character select screen". Not sure if I will actually implement that as it seems like it would be a little complicated when switching to the shielded spaceship sprite.

    - *Tuesday, 07:47* - Drafted part of the report, about 7k words (including the current diary). Also implemented the second boss and second enemy wave by refactoring the method used for the first boss. The code had to be put in the update method of BossSpawner.cs, which is not the greatest for memory space, but it should work fine.

    - *Wednesday, 11:52* - Created a system to keep track of the player highest score and display it at the end. Gave me no end of problems for quite a while because I was getting a NullPointerException in DisplayScore.cs and I thought it was because I was not referencing ScoreManager.cs correctly, but turns out I had accidentally assigned the script to one of the buttons as well, which was trying to reference the class without having it assigned... I also fixed the buttons hit box as it was way larger than the actual button. Made a possible final boss sprite, I do not know its attack pattern yet. The third enemy wave now spawns too.

    - *Thursday, 10:50* - Last day... All current code has been commented and cleaned up, added a "quit game" button and some visual things to the start screen, created a victory screen and the final boss now spawns after the third wave. The draft of the final report is almost complete (~11k words written). To do: finish the final boss implementation, complete missing sections in the report (development final part, add all new classes, complete visual design with sprites, conclusion and self evaluation), figure out export and installation of the game, make the demo video, have some coffee.
    Unfortunately I think the character selection will remained unimplemented, as I do not think I will have enough time to test it and I would much rather have a fully functioning program, even if with less features. It will however be mentioned in the report. 