# Perfect Pixel Camera With Zoom Tools
For 2D Games with the Unity Game Engine.

## Description
There's a lot of shenanigans when it comes to working with pixel perfect display of sprites in Unity, especially when you're rolling your own perfect pixel solution. You can use this to avoid displaying irregularly rectangular pixels.

This camera component:
- Automatically adjusts to screen height even after changing the display size.
- Sets an appropriate scale on the camera based on a desired level of zoom.
- Comes with zoom controls.
- Optional smooth zooming between zoom levels over a duration.

## Installation
Clone or download this repository to your machine.
Copy the `Assets/PixelPerfectCameraWithZoomControls` folder into your `Assets` folder.
**Note:**The only absolutely required script should be the `PerfectPixelWithZoom.cs`.

## Demo Project:
Clone this repository and open the `Pixel-Perfect-Camera-With-Zoom-Controls` as a project with Unity, then bring the `Pixel Perfect Camera With Zoom Controls` scene into the Hierarchy. Disable any other scenes and hit the Play button to activate play mode to see it in action.
- 3 Sprite examples will display with pixel densities:
  - 32 pixels per unit in the upper left
  - 64 pixels per unit in the upper right
  - 128 pixelse per unit across the botom
- Scroll the mouse wheel when in play mode to zoom in and out.
- Click the buttons to demo each of the controls available with the `PerfectPixelWithZoom` class.

## Simple Use:
Add the `PerfectPixelWithZoom.cs` script to your Main Camera.

Add the `Zoom.cs` sample to the Main Camera or another game object.

Link the Main Camera with `PerfectPixelWithZoom` to the `ppwzCamera` field in the `Zoom.cs` component.

Add Some Sprite Objects to the Scene.

Go to the `Perfect Pixel With Zoom` component on the Main Camera and edit the Fields.
- Pixels Per Unit - This should be the same value used for all of the sprites in your scene.
- Zoom Scale Max - Upper limit of zoom.
- Zoom Scale Start - Initial zoom scale on Start.
- Smoov Zoom - Toggle on/off the smooth transition between zoom levels.
- Smoov Zoom Duration - The time in seconds it takes the zoom transition to go from the current scale to the next.

Enter Play mode and scroll the mouse wheel back and forth.

## Advanced Info:
Attach the `PerfectPixelWithZoom.cs` as a component to the desired Camera.

### Control via Button/Toggle triggers
Be sure an Event System is in place or the buttons won't work.
Add an On Click () or On Value Changed (boolean) to the list in the inspector.
Link the Camera containing the `PerfectPixelWithZoom` component.
Select functions (methods) from the `PerfectPixelWithZoom` list.

### Control via code
Cache the `PerfectPixelWithZoom` Object with `GetComponent<PerfectPixelWithZoom>()` in your script.
Call any of the public properties and methods in your script to adjust the Camera.

### Properties
- **currentZoomScale** - Returns the current zoom scale. *Note:* Can possibly return a value between transitions instead of whole number depending on if the smooth transition is actively happening.

### Public Methods
- **SetPixelsPerUnit(int)** - This should be the same value used for all of the sprites in your scene.
- **SetZoomScaleMax(int)** - Sets the upper limit of zoom.
- **SetSmoovZoomDuration(float)** - Set the time in seconds it takes the zoom transition to go from the current scale to the next.
- **SetZoom(float)** - Set the current zoom level.
- **SetZoomImmediate(float)** - Set the current zoom immediately skipping the smooth transition.
- **ZoomIn()** - Increment the zoom scale to the next whole number capped to ZoomScaleMax.
- **ZoomOut()** - Decrement the zoom scale to the next whole number limited to to 1.
