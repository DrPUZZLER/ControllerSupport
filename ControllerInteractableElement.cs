/*
Built by Dr. Puzzler
Addon for AC and Unity UI for easy controller support
Check the readme for instructions on using
*/

using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ControllerInteractableElement : MonoBehaviour {

    [HideInInspector] public int isHotspot = 0;
    [HideInInspector] public Button buttonToInteractWith;
    [HideInInspector] public Image imageToDisplay;
    [HideInInspector] public AC.Hotspot hotspotToInteractWith;
    [HideInInspector] public SpriteRenderer spriteToDisplay;
    [HideInInspector] public bool fade = true;
    [HideInInspector] public float timeToFade = 0.25f;
    [HideInInspector] public bool deselectWhenInteract = true;
    [HideInInspector] public AudioSource source;
    [HideInInspector] public bool playAudioOnSelect = true;
    [HideInInspector] public bool linkAudioToAC = true;



    bool currentlySelected = false;
    void Start() {
        if (isHotspot == 0) {
            if (buttonToInteractWith == null)
                buttonToInteractWith = GetComponent<Button>();

            if (imageToDisplay == null)
                imageToDisplay = GetComponent<Image>();
        } else {
            if (hotspotToInteractWith == null)
                hotspotToInteractWith = GetComponent<AC.Hotspot>();

            if (spriteToDisplay == null)
                spriteToDisplay = GetComponent<SpriteRenderer>();
        }
        if (source == null) {
            source = GetComponent<AudioSource>();
        }
        
    }
    public void Select() {
        if (currentlySelected)
            return;

        if (isHotspot == 0) {
            imageToDisplay.enabled = true;
            if (fade) {
                imageToDisplay.DOFade(0, 0);
                imageToDisplay.DOFade(1, timeToFade);
            }
        } else {
            spriteToDisplay.enabled = true;
            if (fade) {
                spriteToDisplay.DOFade(0, 0);
                spriteToDisplay.DOFade(1, timeToFade);
            }
        }
        if (playAudioOnSelect && source != null) {
            if (linkAudioToAC) {
                source.volume = AC.Options.GetSFXVolume();
            }
            source.Play();
        }
        
        currentlySelected = true;
    }
    public void Deselect() {
        if (!currentlySelected)
            return;

        if (isHotspot == 0) {
            if (fade) {
                imageToDisplay.DOFade(1, 0);
                imageToDisplay.DOFade(0, timeToFade);
            }
            imageToDisplay.enabled = false;
        } else {
            if (fade) {
                spriteToDisplay.DOFade(1, 0);
                spriteToDisplay.DOFade(0, timeToFade);
            }
            spriteToDisplay.enabled = false;
        }
        
        currentlySelected = false;
    }
    public void Interact() {
        if (isHotspot == 0) {
            buttonToInteractWith.onClick.Invoke();
            if (deselectWhenInteract)
                Deselect();
        } else {
            hotspotToInteractWith.RunUseInteraction();
            if (deselectWhenInteract)
                Deselect();
        }
        
    }
}
