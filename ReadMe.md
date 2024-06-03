Built by Dr. Puzzler
Addon for AC and Unity UI for easy controller support

Dependencies:
Requires the Adventure Creator Plugin for Unity (paid)
Requires DOTween (free)
Requires New Input System AND Old Inpust System (free)


YT Tutorial: https://youtu.be/ixQlYXZMjH0

Instructions:
For each set of buttons you wish to cycle through, add a Controller Manager component to an empty game object.
Add a player Input Asset, and use the provided input action asset (you'll need to replicate the actions if you want to use your own action asset)
Make sure that the behaviour is set to 'Send Messages'

On each button or hotspot you wish to cycle through, add a Controller Interactable Element component.
Once done, add it to the list in your Controller Manager. The order in this list will determine the order buttons are cycled through.
Fill out the Controller Interactable Element as it instructs.
That should be all! Feel free to reach out on Discord if you are having issues.


Update 3/6/24
IMPORTANT IF YOU WANT IT TO WORK WITH SUBTITLES:
To use it with subtitles then in the old input manager, create a new input named SkipSpeech, and set the positive button to whatever button you want to map subtitles to
(I use joystick button 0 (button south), which correlates with the select button in the template mapping, but you can use whatever you like)
The ControllerSubtitles Script can be added to the subtitles menu to control the current state of the mouse cusor, but is not a required component to get the subtitles to work
with controller.

The system now also works when some button objects are disabled, it will simply skip them and move to the next active button.