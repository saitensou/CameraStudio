# Installation
To install Cam Studio:
1. Create a new GameObject with script  [`CamCoordinator.cs`](../CamStudio/CamCoordinator.cs)
2. Add the cameras to the camera list, and set the main camera
3. For each camera, if it is using `cinemachine`, set its layer different from each other to avoid having same camera
4. Additionally, for the `cinemachine` cameras, adding script  [`VirtualCamCoordinator.cs`](../CamStudio/VirtualCamCoordinator.cs) will let it switch camera by triggering