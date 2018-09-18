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
        private SceneCameraMover mainCameraMover;

        private bool isEnableTwister = false;

        private const string twisterFieldText = "Twister Params Object";
        private const string toggleEnableText = "Enable";
        private const string toggleDisableText = "Disable";
        private const string saveButtonText = "Save";
        private const string loadButtonText = "Load";

        private const string TwisterParamsPrefsKey = "TWISTER_PARAMATER";

        public TwisterInputer TwisterInputer;

        [MenuItem("Window/MIDI Fighter Twister")]
        static void Open() {
            GetWindow<MidiFighterTwisterWindow>();
        }

        private void Awake() {
            TwisterInputer = new TwisterInputer();
            mainCameraMover = new SceneCameraMover(SceneView.lastActiveSceneView);

            TwisterInputer.TwisterEvent00.AddListener(mainCameraMover.MovePositionX);
            TwisterInputer.TwisterEvent01.AddListener(mainCameraMover.MovePositionY);
            TwisterInputer.TwisterEvent02.AddListener(mainCameraMover.MovePositionZ);
            TwisterInputer.TwisterEvent03.AddListener(mainCameraMover.ResetPosition);

            TwisterInputer.TwisterEvent04.AddListener(mainCameraMover.MoveRotationX);
            TwisterInputer.TwisterEvent05.AddListener(mainCameraMover.MoveRotationY);
            TwisterInputer.TwisterEvent06.AddListener(mainCameraMover.MoveRotationZ);
            TwisterInputer.TwisterEvent07.AddListener(mainCameraMover.ResetRotation);
        }

        private void OnGUI() {

            var isEnableLabelText = isEnableTwister ? toggleEnableText : toggleDisableText;
            var isEnableLabelColor = isEnableTwister ? Color.green : Color.red;

            twister = EditorGUILayout.ObjectField(twisterFieldText, twister, typeof(TwisterParams), false) as TwisterParams;

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

            if (isEnableTwister) {
                TwisterInputer?.Update(twister);
            }
        }
    }
}

