# Lukasz Bednarek's Unity Learn Tutorial Compilation

This is the master directory of all Unity Learn tutorials worked on & completed by Lukasz Bednarek.

## Unity Essentials
https://learn.unity.com/pathway/unity-essentials?uv=2021.3

Designed for anyone new to Unity, this guided learning journey is your first step toward gaining the background, context, and skills you need to confidently 
create in the Unity Editor and bring your vision to life. Experience hands-on learning as you discover what’s possible with Unity and unlock free assets to 
support you in creating your best projects. Completing this Pathway will equip you with the foundation you need to further your learning and specialize in your 
area of interest.

### Skills
Absolute Beginner Project Setup & Settings
* Install the Unity Editor for the first time
* Create and manage projects in the Unity Hub

Unity Editor Essentials
* Identify and use essential features of the Unity Editor.
* Create and Manage Scenes
* Navigate in 3D space in the Scene view
* Navigate in 2D space in the Scene view

Real-time Industry Essentials
* Understand Unity’s history and role within the industries that rely on real-time creation.
* Describe the real-time production cycle

Scene Building Essentials
* Identify the default elements in a new Scene
* Create GameObjects
* Manipulate GameObjects
* Work with components and Scripts
* Change the appearance of GameObjects
* Implement basic physics for GameObjects

Publishing
* Create and share a basic build

Absolute Beginner Job preparation
* Prepare yourself for the job search
* Create a portfolio, enabling you to pursue a job in real-time development
* Cultivate professional attitudes
* Plan your Unity learning journey by setting goals
* Practice continuous personal and professional growth

### Explore Unity
Learn what Unity is and how it’s used while creating simple 2D and 3D real-time experiences from scratch. This mission will guide you from first install of the Unity editor to creating your first Unity projects to play and share with others.

###### How to get the Publish button for WebGL projects: https://answers.unity.com/questions/1823468/publish-button-for-webgl-project-is-not-available.html

#### Foundations of Real-time 3D
https://learn.unity.com/project/essentials-of-real-time-3d?uv=2021.3&pathwayId=5f7bcab4edbc2a0023e9c38f&missionId=5f777d9bedbc2a001f6f5ec7

In this learning project, you will be introduced to some of the essential tasks of an artist, game developer, or other creator of interactive 3D experiences. 
You’ll explore the 3D capabilities and features of Unity, starting with creating and manipulating 3D objects. You will learn about components, which give you 
control over the ways objects look and behave. You will control lighting effects and experiment with Materials, which give 3D objects a realistic appearance.

Created a single scene of an environment made up of 3D GameObjects where a ball has collision and interacts with gravity to reach a final destination. 
I learned how to:
* make basic geometry in a 3D environment,
* use materials on a GameObject (attach to its collider) to have custom physics (bouncy ball),
* apply imported material assets to all GameObjects,
* change colour of directional light,
* change camera view in 3D,
* build & deploy a WebGL app on Unity Play.
* edit the prefab GameObject & variants of it

Link to demo on Unity Play: https://play.unity.com/mg/other/lava-challenge-16

#### Essentials of Programming in Unity
https://learn.unity.com/project/essentials-of-programming-in-unity?uv=2021.3&pathwayId=5f7bcab4edbc2a0023e9c38f&missionId=5f777d9bedbc2a001f6f5ec7

This learning project will give you a sample of the essential tasks of a Unity programmer. These tasks can also be useful in any other role when you want to customize the ways GameObjects behave. Although many tasks in Unity don’t require programming, it can also be helpful to understand these fundamentals.

In these tutorials, you will create a simple script and add it to a GameObject as a component. You will be introduced to the Integrated Development Environment (IDE) that comes with Unity, and explore the default script that every Unity programmer starts from. You will change a GameObject using a script to get a glimpse of the possibilities of scripting for your own projects.

I expanded upon the previous lava challenge project and added behaviours only possible with script components attached to GameObjects.
I learned how to:
* increment/decrement GameObjects position, rotation, and scale
* practice applying behaviours in an 3D environment

#### Essentials of Real-time Audio
https://learn.unity.com/project/essentials-of-real-time-audio?uv=2021.3&pathwayId=5f7bcab4edbc2a0023e9c38f&missionId=5f777d9bedbc2a001f6f5ec7

In this learning project, you’ll start in a pre-made 3D project where you can explore and experiment with audio in Unity. In addition to setting background music, you will experience the ways that Unity simulates the ways sound behaves in a 3D space. 

I imported a playable scene and edited aspects of volume within it. I added a bird that moves between 2 points and chirps random audio clips outside the house to utilise 3D audio.
I learned how to:
* implement 3D audio (use rolloff to adjust volume around audio source)
* find audio from the asset store
* programmatically control sound

Link to demo on Unity Play: https://play.unity.com/mg/other/outputs-x

#### Essentials of Real-time 2D
https://learn.unity.com/project/essentials-of-real-time-2d?uv=2021.3&pathwayId=5f7bcab4edbc2a0023e9c38f&missionId=5f777d9bedbc2a001f6f5ec7

In this learning project, you will be introduced to some of the essential tasks of an artist, game developer, or other creator of interactive 2D experiences. You’ll build on your knowledge of real-time 3D creation while experiencing the simplicity and requirements of the 2D environment. 2D creation is not only useful for creating 2D games, but also for building user interfaces in many types of projects.

Downloading the Unity Assets has issues. Below is the thread containing fixes to common issues:
https://forum.unity.com/threads/2d-game-kit-official-thread.517249/page-11

I learned that:
* a Rigidbody component controls how the GameObject interacts with gravity and air density
* a collider component controls how the GameObject interacts with other objects
* handle collision between objects
* 2D physics
* put together a 2D mini-project
