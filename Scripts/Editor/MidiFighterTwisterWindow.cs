using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiJack;
using TwisterForUnity;

#if UNITY_EDITOR
using UnityEditor;
#endif


namespace TwisterForUnity.Editor {
    public sealed class MidiFighterTwisterWindow : EditorWindow {

        private TwisterParams twister;
        private Camera sceneCamera;

        private float moveGain = 1.0f;
        private bool isEnableTwister = false;

        private const string twisterFieldLabelText = "Twister Params Object";
        private const string moveGainFieldLabelText = "Camera Move Gain";
        private const string toggleEnableLabelText = "Enable";
        private const string toggleDisableLabelText = "Disable";

        private TwisterInputer inputer;

        [MenuItem("Window/MIDI Fighter Twister")]
        static void Open() {
            GetWindow<MidiFighterTwisterWindow>();
        }

        private void Awake() {
            sceneCamera = SceneView.lastActiveSceneView.camera;
            inputer = new TwisterInputer();
        }

        private void OnGUI() {

            var isEnableLabelText = isEnableTwister ? toggleEnableLabelText : toggleDisableLabelText;
            var isEnableLabelColor = isEnableTwister ? Color.green : Color.red;

            twister = EditorGUILayout.ObjectField(twisterFieldLabelText, twister, typeof(TwisterParams), false) as TwisterParams;

            moveGain = EditorGUILayout.FloatField(moveGainFieldLabelText, moveGain);

            GUI.backgroundColor = isEnableLabelColor;
            if (GUILayout.Button(isEnableLabelText)) {

                isEnableTwister = !isEnableTwister;
            }
        }

        private void Update() {
            inputer.Twister = twister;

            if (isEnableTwister) {
                inputer.Update();
            }
        }
    }
}

