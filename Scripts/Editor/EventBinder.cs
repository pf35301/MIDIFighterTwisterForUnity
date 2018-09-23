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

        private SingletonTwisterInputer twisterInputer;
        private SceneCameraMover mainCameraMover;

        public EventBinder() {
            twisterInputer = SingletonTwisterInputer.GetInstance();
            mainCameraMover = new SceneCameraMover(SceneView.lastActiveSceneView);

            Bind();
        }

        public void Bind() {
            twisterInputer?.TwisterEvent00.AddListener(mainCameraMover.MovePositionX);
            twisterInputer?.TwisterEvent01.AddListener(mainCameraMover.MovePositionY);
            twisterInputer?.TwisterEvent02.AddListener(mainCameraMover.MovePositionZ);
            twisterInputer?.TwisterEvent03.AddListener(mainCameraMover.ResetPosition);
            twisterInputer?.TwisterEvent03.AddListener(mainCameraMover.SetPositionGain);

            twisterInputer?.TwisterEvent04.AddListener(mainCameraMover.MoveRotationX);
            twisterInputer?.TwisterEvent05.AddListener(mainCameraMover.MoveRotationY);
            twisterInputer?.TwisterEvent06.AddListener(mainCameraMover.MoveRotationZ);
            twisterInputer?.TwisterEvent07.AddListener(mainCameraMover.ResetRotation);
            twisterInputer?.TwisterEvent07.AddListener(mainCameraMover.SetRotationGain);

            twisterInputer?.TwisterEvent15.AddListener(mainCameraMover.ChangeOrthographic);
        }

        public void Update(TwisterParams twister) {
            twisterInputer.Update(twister);
        }
    }
}