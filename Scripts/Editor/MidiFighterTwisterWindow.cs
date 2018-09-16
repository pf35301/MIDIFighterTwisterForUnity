using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiJack;
using TwisterForUnity;

#if UNITY_EDITOR
using UnityEditor;
#endif


namespace TwisterForUnity {
    public class MidiFighterTwisterWindow : EditorWindow {

        private TwisterParams twister;

        [MenuItem("Window/MIDI Fighter Twister")]
        static void Open() {
            GetWindow<MidiFighterTwisterWindow>();
        }

        private void OnGUI() {
            twister = EditorGUILayout.ObjectField(null, typeof(TwisterParams), false) as TwisterParams;
        }
    }
}

