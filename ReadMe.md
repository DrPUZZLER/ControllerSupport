Built by Dr. Puzzler
Addon for AC and Unity UI for easy controller support

Dependencies:
Requires the Adventure Creator Plugin for Unity (paid)
Requires DOTween (free)
Requires New Input System AND Old Inpust System (free)


YT Tutorial:

Instructions:
For each set of buttons you wish to cycle through, add a Controller Manager component to an empty game object.
Add a player Input Asset, and use the provided input action asset (you'll need to replicate the actions if you want to use your own action asset)
Make sure that the behaviour is set to 'Send Messages'

On each button or hotspot you wish to cycle through, add a Controller Interactable Element component.
Once done, add it to the list in your Controller Manager. The order in this list will determine the order buttons are cycled through.
Fill out the Controller Interactable Element as it instructs.
That should be all! Feel free to reach out on Discord if you are having issues.