/*
Built by Dr. Puzzler
Addon for AC and Unity UI for easy controller support
Check the readme for instructions on using
*/

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class ControllerManager : MonoBehaviour {

    PlayerInput input;
    bool selectionCurrentlyMade = false;
    [SerializeField] List<ControllerInteractableElement> buttonsToInteractWith;
    int buttonsCount;
    [SerializeField] int currentButton = 0;
    void Start() {
        input = GetComponent<PlayerInput>();
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
        
        foreach (ControllerInteractableElement e in buttonsToInteractWith) {
            if (e.isActiveAndEnabled) {
                e.Select();
                currentButton = buttonsToInteractWith.IndexOf(e);
                selectionCurrentlyMade = true;
                return true;
            }
        }
        return true;
    }
    public void OnLeft() {
        if (CheckSelection())
            return;
        if (buttonsToInteractWith[currentButton].isActiveAndEnabled)
            buttonsToInteractWith[currentButton].Deselect();
        currentButton --;
        if (currentButton < 0) 
            currentButton = buttonsCount;

        if (buttonsToInteractWith[currentButton].isActiveAndEnabled)
            buttonsToInteractWith[currentButton].Select();
        else
            OnLeft();
        
    }
    public void OnRight() {
        if (CheckSelection())
            return;
        if (buttonsToInteractWith[currentButton].isActiveAndEnabled)
            buttonsToInteractWith[currentButton].Deselect();

        currentButton ++;
        if (currentButton > buttonsCount) 
            currentButton = 0;
        
        if (buttonsToInteractWith[currentButton].isActiveAndEnabled)
            buttonsToInteractWith[currentButton].Select();
        else
            OnRight();
    }
    public void OnSelect() {
        if (CheckSelection())
            return;
        buttonsToInteractWith[currentButton].Interact();
    }

    [SerializeField] AC.ActionList actionForBack;
    [SerializeField] AC.ActionListAsset actionAssetForBack;
    public void OnBack() {
        if (CheckSelection())
            return;
        if (actionForBack != null)
            actionForBack.Interact();
        else if (actionAssetForBack != null)
            actionAssetForBack.Interact();
    }

    [SerializeField] AC.ActionList actionForEscape;
    [SerializeField] AC.ActionListAsset actionAssetForEscape;
    public void OnEscape() {
        if (CheckSelection())
            return;
        if (actionForEscape != null)
            actionForEscape.Interact();
        else if (actionAssetForEscape != null)
            actionAssetForEscape.Interact();
    }

    [SerializeField] AC.ActionList actionForMap;
    [SerializeField] AC.ActionListAsset actionAssetForMap;
        public void OnMap() {
        if (CheckSelection())
            return;
        if (actionForMap != null)
            actionForEscape.Interact();
        else if (actionAssetForMap != null)
            actionAssetForMap.Interact();
    }
}