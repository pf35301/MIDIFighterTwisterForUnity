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

        [SerializeField]
        private TwisterParams m_Twister;
        [SerializeField]
        private EventBinder m_Binder;

        private const string TWISTERFIELDTEXT = "Twister Params Object";
        private const string SAVEBUTTONTEXT = "Save";
        private const string LOADBUTTONTEXT = "Load";

        private const string TWISTERPARAMSPREFSKEY = "TWISTER_PARAMATER";

        [MenuItem("Window/MIDI Fighter Twister")]
        private static void Open() {
            var window = GetWindow<MidiFighterTwisterWindow>();

            window.Init();
        }

        private void Init() {
            m_Binder = new EventBinder();
        }

        private void OnGUI() {
            m_Twister = EditorGUILayout.ObjectField(TWISTERFIELDTEXT, m_Twister, typeof(TwisterParams), false) as TwisterParams;

            var defaultColor = GUI.backgroundColor;

            if (GUILayout.Button(SAVEBUTTONTEXT)) {
                saveInspectorConfig();
            }

            if (GUILayout.Button(LOADBUTTONTEXT)) {
                loadInspectorConfig();
            }

            if (m_Twister != null) {
                m_Twister.MovePositionGain = EditorGUILayout.Slider("MovePositionGain", m_Twister.MovePositionGain, m_Twister.MovePositionGainMin, m_Twister.MovePositionGainMax);
                m_Twister.MoveRotationGain = EditorGUILayout.Slider("MoveRotationGain", m_Twister.MoveRotationGain, m_Twister.MoveRotationGainMin, m_Twister.MoveRotationGainMax);
            }
        }

        private void saveInspectorConfig() {
            int id = m_Twister.GetInstanceID();
            EditorPrefs.SetInt(TWISTERPARAMSPREFSKEY, id);
        }

        private void loadInspectorConfig() {
            int id = EditorPrefs.GetInt(TWISTERPARAMSPREFSKEY);
            m_Twister = EditorUtility.InstanceIDToObject(id) as TwisterParams;
        }

        private void Update() {

            if(m_Twister == null) {
                return;
            }

            m_Binder.Update(m_Twister);
        }
    }
}

