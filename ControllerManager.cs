/*
Built by Dr. Puzzler
Addon for AC and Unity UI for easy controller support
Check the readme for instructions on using
*/

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerManager : MonoBehaviour {

    PlayerInput input;
    AccessibilityManager manager;
    bool selectionCurrentlyMade = false;
    [SerializeField] List<ControllerInteractableElement> buttonsToInteractWith;
    int buttonsCount;
    int currentButton = 0;
    void Start() {
        input = GetComponent<PlayerInput>();
        manager = FindObjectOfType<AccessibilityManager>();
        buttonsCount = buttonsToInteractWith.Count - 1;
    }

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            selectionCurrentlyMade = false;
            foreach(ControllerInteractableElement e in buttonsToInteractWith) {
                e.Deselect();
            }
        }
        if (selectionCurrentlyMade) {
            AC.KickStarter.cursorManager.cursorDisplay = AC.CursorDisplay.Never;
            AC.KickStarter.playerCursor.ForceOffCursor = true;
        } else {
            AC.KickStarter.cursorManager.cursorDisplay = AC.CursorDisplay.Always;
            AC.KickStarter.playerCursor.ForceOffCursor = false;
        }
    }


    bool CheckSelection() {
        if (selectionCurrentlyMade)
            return false;
        buttonsToInteractWith[0].Select();
        selectionCurrentlyMade = true;
        return true;
    }
    public void OnLeft() {
        if (CheckSelection())
            return;
        buttonsToInteractWith[currentButton].Deselect();
        currentButton --;
        if (currentButton < 0) 
            currentButton = buttonsCount;
        buttonsToInteractWith[currentButton].Select();
        
    }
    public void OnRight() {
        if (CheckSelection())
            return;
        buttonsToInteractWith[currentButton].Deselect();
        currentButton ++;
        if (currentButton > buttonsCount) 
            currentButton = 0;
        buttonsToInteractWith[currentButton].Select();
    }
    public void OnSelect() {
        if (CheckSelection())
            return;
        buttonsToInteractWith[currentButton].Interact();
    }

    [SerializeField] AC.ActionList actionForBack;
    public void OnBack() {
        if (CheckSelection())
            return;
        if (actionForBack != null)
            actionForBack.Interact();
    }

    [SerializeField] AC.ActionList actionForEscape;
    public void OnEscape() {
        if (CheckSelection())
            return;
        if (actionForEscape != null)
            actionForEscape.Interact();
    }

    [SerializeField] AC.ActionList actionForMap;
    public void OnMap() {
        if (CheckSelection())
            return;
        if (actionForMap != null)
            actionForEscape.Interact();
    }
}