# Perfect Pixel Camera With Zoom Tools
For 2D Games with the Unity Game Engine.

## Installation

Copy the `PixelPerfectCameraWithZoomControls` folder into your `Assets` folder.

## Sample Project
Clone this repository and open the `PixelPerfectCameraWithZoomControls` as a project with Unity, then hit the Play button to activate play mode to see it in action.
- 3 Sprite examples will display with pixel densities:
  - 32 pixels per unit in the upper left
  - 64 pixels per unit in the upper right
  - 128 pixelse per unit across the botom
- Scroll the mouse wheel when in play mode to zoom in and out.
- Click the buttons to demo each of the controls available with the `PerfectPixelWithZoom` class.

## Simple Use:

Drag the `PerfectPixelWithZoom.cs` script onto your Main Camera.

Go to the `Perfect Pixel With Zoom` component and edit the Fields.
- Pixels Per Unit - This should be the same value used for all of the sprites in your scene.
- Zoom Scale Max - Sets the upper limit of zoom.
- Zoom Scale Start - Sets the initial zoom scale on Start.
- Smoov Zoom - Toggle on to smooth the transition between zoom levels.
- Smoov Zoom Duration - Time in seconds it takes the smoothed zoom to go from the current value to the next.
