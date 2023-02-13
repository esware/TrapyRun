# TrapyRunClone
Trapy run game is a runner game.In my game, we try to save our basic mechanical character by escaping from the enemies coming after us, the place where our character runs collapses after a while, using this feature we try to pull our enemies to the collapsed places.


![Screenshot 2023-02-13 080445](https://user-images.githubusercontent.com/48649947/218376735-f5a994a1-9895-49da-ad9e-fe9fe35692e7.png) 
![tr](https://user-images.githubusercontent.com/48649947/218377491-c942692f-8999-4737-980b-ecdf5684cf7b.png)


Object Pooling is a great way to optimize your projects and reduce the load on the CPU when you need to quickly create and destroy GameObjects. It's a good practice and design pattern to keep in mind to help free up the CPU's processing power to tackle more important tasks and not be overwhelmed by repetitive creation and destruction calls.Instantiate game objects during gameplay and destroying them when they die could have negatively impacted performance .That's why I used the object pooling design pattern in this tutorial. 

![image](https://user-images.githubusercontent.com/48649947/218376693-a3fab685-7f41-44c4-8ef2-ab2416ec4ee0.png)

Another issue that can affect performance is the platform the player is on. The platform is made up of hundreds of individual pieces, for each frame there wouldn't be a good way to check if they are in contact with the character. Therefore, every tile on the platform is initially in an idle state.

![image](https://user-images.githubusercontent.com/48649947/218379112-3ce198a3-e13d-48f4-a9dd-dbdd847a5d1e.png)
![ezgif com-video-to-gif](https://user-images.githubusercontent.com/48649947/218379538-8b5fc509-3bed-467d-a3b3-890e36aed882.gif)
