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

        public EventBinder(TwisterParams Twister) {
            m_TwisterInputer = SingletonTwisterInputer.GetInstance();
            m_MainCameraMover = new SceneCameraMover(SceneView.lastActiveSceneView);

            m_TwisterInputer.AddTwisterEvents(Twister);
            Bind();

            //[TODO]
            /*
            Twister.ChangeTheNumberOfTwisterHandler.AddListener(() => {
                m_TwisterInputer.AddTwisterEvents(Twister);
                Bind();
            });
            */
        }

        //[TODO] refactor
        public void Bind() {
            m_TwisterInputer?.TwisterEvents[0]?.AddListener(m_MainCameraMover.MovePositionX);
            m_TwisterInputer?.TwisterEvents[1]?.AddListener(m_MainCameraMover.MovePositionY);
            m_TwisterInputer?.TwisterEvents[2]?.AddListener(m_MainCameraMover.MovePositionZ);
            m_TwisterInputer?.TwisterEvents[3]?.AddListener(m_MainCameraMover.ResetPosition);
            m_TwisterInputer?.TwisterEvents[3]?.AddListener(m_MainCameraMover.SetPositionGain);

            m_TwisterInputer?.TwisterEvents[4]?.AddListener(m_MainCameraMover.MoveRotationX);
            m_TwisterInputer?.TwisterEvents[5]?.AddListener(m_MainCameraMover.MoveRotationY);
            m_TwisterInputer?.TwisterEvents[6]?.AddListener(m_MainCameraMover.MoveRotationZ);
            m_TwisterInputer?.TwisterEvents[7]?.AddListener(m_MainCameraMover.ResetRotation);
            m_TwisterInputer?.TwisterEvents[7]?.AddListener(m_MainCameraMover.SetRotationGain);

            m_TwisterInputer?.TwisterEvents[15]?.AddListener(m_MainCameraMover.ChangeOrthographic);
        }

        public void Update(TwisterParams twister) {
            m_TwisterInputer?.Update(twister);
        }
    }
}