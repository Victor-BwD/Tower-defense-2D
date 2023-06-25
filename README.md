I was inspired by the game BloonsTD6, where hordes of balloons come and you need to pop them with various towers.

The game starts off paused, allowing you to purchase any tower you wish to deploy in the game. To start the hordes from coming, you need to press the "Play" button.

It begins with 4 weaker enemies, 3 medium ones, and 2 strong ones, and this pattern repeats infinitely. When the player eliminates a unit, they receive coins and score.

Coins are used to purchase new units, while the score represents your performance during the game and will display your highest score at the end.

I attempted to balance the towers, allowing players to place only 5 towers throughout the entire game, and it's not possible to remove towers once they are placed.

The enemies do not follow a predefined path; they simply start from point A and move towards point B, which is the white line called the "goal."

I didn't use Unity's canvas system because I find it cumbersome to work with Unity's UI system. Instead, I utilized more C# action systems and OnMouseDown.

In the game, there are 3 types of towers:
- The Turret: It fires projectiles and is the only tower that deals damage in the game.
- The Slow Tower: It slows down enemy movement when it releases its "wave" periodically, and enemies that pass through it are slowed down.
- The Castle Tower: It buffs nearby towers, increasing their rate of fire.

There are 3 types of enemies:
- The Capsule Enemy: It is the weakest enemy, dealing 10 damage and having 22 health. It also gives the least amount of coins and score.
- The Ghost Enemy: It is a medium-level enemy in the game, dealing 20 damage and having 45 health.
- The Diamond Enemy: It is the strongest enemy, dealing 30 damage to the player and having 60 health.

The player will have to work to prevent the enemies from reaching the white line and thus losing health, using only turret towers or switching between them.

As I mentioned, to start the game, the player needs to click on "Play." There is also a pause button, allowing the player to pause the game, and clicking it again resumes the game from where it left off.

When the player runs out of lives, the game over screen appears, and the player can press the "restart" button to start the scene again.

To create the store system, I used the C# Task class to make an asynchronous function and respawn the object as soon as the player pulls the tower from the store.

I aimed to create a very demonstrative version, an MVP, to refine over time. I tried to follow the SOLID principles and best practices of OOP during the development process.
