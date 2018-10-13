using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TwisterForUnity.Input;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace TwisterForUnity.Editor {

    [System.Serializable]
    public class EventBinder {

        private SingletonTwisterInputer m_TwisterInputer;
        private SceneCameraMover m_MainCameraMover;

        public EventBinder() {
            m_TwisterInputer = SingletonTwisterInputer.GetInstance();
            m_MainCameraMover = new SceneCameraMover(SceneView.lastActiveSceneView);

            Bind();
        }

        public void Bind() {
            m_TwisterInputer?.TwisterEvent00.AddListener(m_MainCameraMover.MovePositionX);
            m_TwisterInputer?.TwisterEvent01.AddListener(m_MainCameraMover.MovePositionY);
            m_TwisterInputer?.TwisterEvent02.AddListener(m_MainCameraMover.MovePositionZ);
            m_TwisterInputer?.TwisterEvent03.AddListener(m_MainCameraMover.ResetPosition);
            m_TwisterInputer?.TwisterEvent03.AddListener(m_MainCameraMover.SetPositionGain);

            m_TwisterInputer?.TwisterEvent04.AddListener(m_MainCameraMover.MoveRotationX);
            m_TwisterInputer?.TwisterEvent05.AddListener(m_MainCameraMover.MoveRotationY);
            m_TwisterInputer?.TwisterEvent06.AddListener(m_MainCameraMover.MoveRotationZ);
            m_TwisterInputer?.TwisterEvent07.AddListener(m_MainCameraMover.ResetRotation);
            m_TwisterInputer?.TwisterEvent07.AddListener(m_MainCameraMover.SetRotationGain);

            m_TwisterInputer?.TwisterEvent15.AddListener(m_MainCameraMover.ChangeOrthographic);
        }

        public void Update(TwisterParams twister) {
            m_TwisterInputer.Update(twister);
        }
    }
}