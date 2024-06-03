/*
Built by Dr. Puzzler
Addon for AC and Unity UI for easy controller support
Check the readme for instructions on using
*/

using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(PlayerInput))]
public class ControllerSubtitles : MonoBehaviour {

    PlayerInput input;
    bool selectionCurrentlyMade = false;
    void Start() {
        input = GetComponent<PlayerInput>();
    }

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            selectionCurrentlyMade = false;
        }
        if (selectionCurrentlyMade) {
            AC.KickStarter.cursorManager.cursorDisplay = AC.CursorDisplay.Never;
            AC.KickStarter.playerCursor.ForceOffCursor = true;
        } else {
            AC.KickStarter.cursorManager.cursorDisplay = AC.CursorDisplay.Always;
            AC.KickStarter.playerCursor.ForceOffCursor = false;
        }
    }

    public void OnSelect() {
        if (!selectionCurrentlyMade)
            selectionCurrentlyMade = true;
    }
}