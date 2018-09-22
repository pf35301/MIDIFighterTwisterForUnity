using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiJack;
using TwisterForUnity.Extensions;
using TwisterForUnity.Input;

#if UNITY_EDITOR
using UnityEditor;
#endif


namespace TwisterForUnity.Editor {
    public sealed class MidiFighterTwisterWindow : EditorWindow {

        private TwisterParams twister;
        private EventBinder binder;

        private bool isEnableTwister = false;
        private bool isInitialized = false; 

        private const string twisterFieldText = "Twister Params Object";
        private const string toggleEnableText = "Enable";
        private const string toggleDisableText = "Disable";
        private const string saveButtonText = "Save";
        private const string loadButtonText = "Load";

        private const string TwisterParamsPrefsKey = "TWISTER_PARAMATER";

        [MenuItem("Window/MIDI Fighter Twister")]
        private static void Open() {
            var window = GetWindow<MidiFighterTwisterWindow>();

            window.Init();
        }

        private void Init() {
            binder = new EventBinder();
            isInitialized = true;
        }

        private void OnGUI() {

            var isEnableLabelText = isEnableTwister ? toggleEnableText : toggleDisableText;
            var isEnableLabelColor = isEnableTwister ? Color.green : Color.red;

            twister = EditorGUILayout.ObjectField(twisterFieldText, twister, typeof(TwisterParams), false) as TwisterParams;

            var defaultColor = GUI.backgroundColor;

            if (GUILayout.Button(saveButtonText)) {
                saveInspectorConfig();
            }

            if (GUILayout.Button(loadButtonText)) {
                loadInspectorConfig();
            }

            GUI.backgroundColor = isEnableLabelColor;
            if (GUILayout.Button(isEnableLabelText) && twister != null) {

                isEnableTwister = !isEnableTwister;
            }

            GUI.backgroundColor = defaultColor;

            if (twister != null) {
                twister.MovePositionGain = EditorGUILayout.Slider("MovePositionGain", twister.MovePositionGain, twister.MovePositionGainMin, twister.MovePositionGainMax);
                twister.MoveRotationGain = EditorGUILayout.Slider("MoveRotationGain", twister.MoveRotationGain, twister.MoveRotationGainMin, twister.MoveRotationGainMax);
            }
        }

        private void saveInspectorConfig() {
            int id = twister.GetInstanceID();
            EditorPrefs.SetInt(TwisterParamsPrefsKey, id);
        }

        private void loadInspectorConfig() {
            int id = EditorPrefs.GetInt(TwisterParamsPrefsKey);
            twister = EditorUtility.InstanceIDToObject(id) as TwisterParams;
        }

        private void Update() {
            if (isInitialized == false) {
                Init();
            }

            if(twister == null) {
                return;
            }

            binder.Update(twister);
        }
    }
}

