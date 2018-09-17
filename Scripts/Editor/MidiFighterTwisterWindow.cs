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

        private const string twisterFieldLabelText = "Twister Params Object";
        private const string moveGainFieldLabelText = "Camera Move Gain";
        private const string toggleEnableLabelText = "Enable";
        private const string toggleDisableLabelText = "Disable";

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

            TwisterInputer.TwisterEvent04.AddListener(mainCameraMover.MoveRotationX);
            TwisterInputer.TwisterEvent05.AddListener(mainCameraMover.MoveRotationY);
            TwisterInputer.TwisterEvent06.AddListener(mainCameraMover.MoveRotationZ);
        }

        private void OnGUI() {

            var isEnableLabelText = isEnableTwister ? toggleEnableLabelText : toggleDisableLabelText;
            var isEnableLabelColor = isEnableTwister ? Color.green : Color.red;

            twister = EditorGUILayout.ObjectField(twisterFieldLabelText, twister, typeof(TwisterParams), false) as TwisterParams;

            GUI.backgroundColor = isEnableLabelColor;
            if (GUILayout.Button(isEnableLabelText) && twister != null) {

                isEnableTwister = !isEnableTwister;
            }
        }

        private void Update() {

            if (isEnableTwister) {
                TwisterInputer.Update(twister);
            }
        }
    }
}

