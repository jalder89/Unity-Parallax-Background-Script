# Unity-Parallax-Background-Script
A simple C# script for setting up a parallax background effect in Unity.

# Usage
The script works off a layer system where your background sprites are children of a layer game object.
1. Add an empty game object to your unity project using a name that makes sense to you.
2. Add your background sprite for that layer as a child. You may use more than one sprite, the script will automatically detect extra children.
3. Add the Parallax script to the layer object
4. Set the scroll speed
5. Set the sprite offset if needed
6. Repeat for each layer you require

When working with this script you will probably want to dedicate each layer to a single element of your background. For instance, clouds that scroll at the same speed go in the same layer object. Buildings that scroll at a different speed go in another layer object.
