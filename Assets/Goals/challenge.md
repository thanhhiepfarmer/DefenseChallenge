# Unity Programmer Code Back-End Challenge

## Game

### Player

* can drag 1 turret into a `Placement`
* can see current points
* can level up turret with points
    * 2 points to level-up first turret level
    * each time level-up require double amount of points
    * each time level-up double turret damage

### Turret

* can automatically aim & fire at enemy
* damage start at 1 HP

### Enemy

* spawn periodically from `Starting Indicator`
* delay time between spawn should be configurable
* enemy try to move in shortest distance from `Start Indicator` > `Mid Indicator` > `End Indicator`
* enemy start with 1 HP
* new spawn increase HP by 1 for every 10 enemy killed
* each enemy kill reward player with 1 point

### Menu

Have some basic functions:

* new game.
* save current game into file.
* load saved game from file.

## Note

* Enemy & Turret has been pre-made (to some extends) in `Prefabs` directory.
* Developer take on this challenge can change any aspect of this project as they see fit.
* Master project created in Unity 2019.4.1f1
