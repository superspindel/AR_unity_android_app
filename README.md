# D0020E - Swag Industrial Intelligence Platform ( SIIP )

Intro
This application is built to help and motivate workers in dangerous industrial environments perform repetitive tasks. It uses some game design concepts like experience points, achievements and badges to create a sense of accomplishment and progression. With the help of augmented reality workers can receive remote support for difficult tasks. 

How to use
To test the GUI, go to Assets/Scenes and open the _Main scene in unity. The app can be navigated with the bottom panel. The icons represent the following pages from left to right: Profile page, Available tasks, Active tasks and Extra menu. 

Profile Page
In the profile page the user can check their experience points (XP), achievements and badges earned so far. The achievements and badges can be clicked for more information. 

Available Tasks
Tasks that are yet to be assigned to a user is listed here. By clicking on a task, the user is provided with additional information about that task. The user can select several tasks by clicking the checkbox and then add the selected tasks to active tasks by clicking "Add tasks". 

Active Tasks
When tasks are added to active tasks they are assigned to the user that added them and cannot be taken by another user. By clicking the task in this list, the task is expanded to show that tasks subtasks. 

Extra Menu
The extra menu contains Support, Account, Help and Leaderboard. The support has two options: Remote and MAP.

Remote Support (AR)
In the extra menu go to support and press remote to start the camera. To test this feature you will need the included QR-code-sample.jpg in the project folder. Point the camera to the QR code and it will create a virtual modell of a laptop (not visible) and by clicking the screen arrows will appear on the surface you placed the QR code. The correct placement of the QR code will take some experimentation but it should be placed to the left of the mousepad and should also be roughly the same size as the mousepad. The Laptop that was modelled was a macbook pro 15". You can clear all arrows by clicking "Clear Arrows". Paint will create a fading line where the user swipes its finger. 

To be able to connect you must have the server and the webb application up and running. JATKO skriv mer här. 

Map 
Built in in the application is a 3D map. The map is a modell of "A-huset" at Luleå tekniska universitet. The movement of the dots on the map is scripted and serves only as a concept to be able to follow you own position some day. You can switch between different camera angles. 



