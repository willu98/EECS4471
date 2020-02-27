The scene has various objects that depict a launcher that launches a bowling ball at various targets are varying sizes. There are four bowling pin targets that utilize a cube type collider, and a box game object that uses a few cube colliders.
All targets have rigid bodies, however, the the box object has isKinematic set on, so that the collision with the projectile does not cause it to move.

The launcher can toggle between rotation and translation by pressing T for translate and R for rotate. The launcher can be moved/translated using the WASD keys, and rotation along the y axis is acheived by clicking A and D.
To change the rotation of the projectile, the up and down arrow keys are used to rotate about the X axis. However, by switching to the head gaze position, we can rotate in all directions to adjust the trajectory 
of the projectile by using the head rotations of the HMD. In head gaze mode, you can also see the general direction that the projectile will fly in, as there is a cube object acting as a 'crosshair'. In order to launch the projectile, 
we must press the speace bar. And to change the force that will launch the projectile, we use the F key to increment 5N up and left shift and F to increment 5N down. And to change the torque that acting on the projectile, 
we use the T key to increment 5N up and left shift and T to increment 5N down. Force and torque are displayed in the console.
Upon launching, the crosshair object disssapears after launch and comes back after resetting by pressing Q. There are also various views that can be changed through by pressing the left and right arrow keys, 
one is a full view from the back, then a side view, then head gaze view, then you may view the projectile from the targets point of view, which watches the projectile as t flies.

the bowling pins used in the scene were found in the unity asset store from the free product: Bowling kegel & Ball