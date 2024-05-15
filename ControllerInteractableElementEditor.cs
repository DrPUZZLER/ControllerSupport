/*
Built by Dr. Puzzler
Addon for AC and Unity UI for easy controller support
Check the readme for instructions on using
*/

#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System;

[CustomEditor(typeof(ControllerInteractableElement))]
public class ControllerInteractableElementEditor : Editor {
    public override void OnInspectorGUI() {
        base.OnInspectorGUI();
        ControllerInteractableElement baseElement = (ControllerInteractableElement)target;

        EditorGUILayout.Space(10);
        string[] options = new string[2] {"Unity UI Button", "Adventure Creator Hotspot"};
        baseElement.isHotspot = EditorGUILayout.Popup("Button Mode", baseElement.isHotspot, options);

        EditorGUILayout.Space(10);
        
        if (baseElement.isHotspot == 0) {
            baseElement.buttonToInteractWith = (Button)EditorGUILayout.ObjectField("Button To Interact With", baseElement.buttonToInteractWith, typeof(Button), true);
            EditorGUILayout.LabelField("Leave blank to get the button component on this GameObject");

            EditorGUILayout.Space(10);

            baseElement.imageToDisplay = (Image)EditorGUILayout.ObjectField("Image To Display", baseElement.imageToDisplay, typeof(Image), true);
            EditorGUILayout.LabelField("Leave blank to get the image component on this GameObject");

            EditorGUILayout.Space(10);
            baseElement.fade = EditorGUILayout.Toggle("Fade Image", baseElement.fade);

        } else if (baseElement.isHotspot == 1) {
            baseElement.hotspotToInteractWith = (AC.Hotspot)EditorGUILayout.ObjectField("Hotspot To Interact With", baseElement.hotspotToInteractWith, typeof(AC.Hotspot), true);
            EditorGUILayout.LabelField("Leave blank to get the hotspot component on this GameObject");

            EditorGUILayout.Space(10);

            baseElement.spriteToDisplay = (SpriteRenderer)EditorGUILayout.ObjectField("Sprite To Display", baseElement.spriteToDisplay, typeof(SpriteRenderer), true);
            EditorGUILayout.LabelField("Leave blank to get the sprite renderer component on this GameObject");

            EditorGUILayout.Space(10);
            baseElement.fade = EditorGUILayout.Toggle("Fade Sprite", baseElement.fade);
        }
        if (baseElement.fade) {
            EditorGUILayout.Space(10);
            baseElement.timeToFade = EditorGUILayout.Slider("Time to fade", baseElement.timeToFade, 0, 5);
        }
        
        baseElement.deselectWhenInteract = EditorGUILayout.Toggle("Hide icon when selected", baseElement.deselectWhenInteract);

        EditorGUILayout.Space(10);
        baseElement.playAudioOnSelect = EditorGUILayout.Toggle("Play sound on select", baseElement.playAudioOnSelect);
        if (baseElement.playAudioOnSelect) {
            baseElement.source = (AudioSource)EditorGUILayout.ObjectField("Audio Source", baseElement.source, typeof(AudioSource), true);
            EditorGUILayout.LabelField("Leave blank to get the audio source component on this GameObject");
            baseElement.linkAudioToAC = EditorGUILayout.Toggle("Link volume to AC SFX Volume", baseElement.linkAudioToAC);
        }
        
    }
}
#endif