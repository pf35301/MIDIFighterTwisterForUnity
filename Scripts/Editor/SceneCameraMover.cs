using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace TwisterForUnity.Editor {
    public sealed class SceneCameraMover {

        private SceneView mainSceneView;
        private Vector3 right = new Vector3(1, 0, 0);
        private Vector3 up = new Vector3(0, 1, 0);
        private Vector3 front = new Vector3(0, 0, 1);

        public SceneCameraMover(SceneView sceneView) {
            this.mainSceneView = sceneView;
            Debug.Log(sceneView.name);
        }

        public void MovePositionX(TwisterParams TwisterParameter, RollDirection rollDirection) {
            Debug.Log("posX");
            Debug.Log(mainSceneView);
            Debug.Log(new Vector3(TwisterParameter.MovePositionGain * DirectionSign(rollDirection), 0, 0));
            mainSceneView.pivot += new Vector3(TwisterParameter.MovePositionGain * DirectionSign(rollDirection), 0, 0); 
        }

        public void MovePositionY(TwisterParams TwisterParamter, RollDirection rollDirection) {
            Debug.Log("posY");
            mainSceneView.pivot += new Vector3(0, TwisterParamter.MovePositionGain * DirectionSign(rollDirection), 0);
        }

        public void MovePositionZ(TwisterParams TwisterParameter, RollDirection rollDirection) {
            Debug.Log("posZ");
            mainSceneView.pivot += new Vector3(0, 0, TwisterParameter.MovePositionGain * DirectionSign(rollDirection));
        }

        public void MoveRotationX(TwisterParams TwisterParameter, RollDirection rollDirection) {
            Debug.Log("rotX");
            mainSceneView.rotation = Quaternion.AngleAxis(TwisterParameter.MoveRotateGain * DirectionSign(rollDirection), right) * mainSceneView.rotation;
        }

        public void MoveRotationY(TwisterParams TwisterParameter, RollDirection rollDirection) {
            Debug.Log("rotY");
            mainSceneView.rotation = Quaternion.AngleAxis(TwisterParameter.MoveRotateGain * DirectionSign(rollDirection), up) * mainSceneView.rotation;        }

        public void MoveRotationZ(TwisterParams TwisterParameter, RollDirection rollDirection) {
            Debug.Log("rotZ");
            mainSceneView.rotation = Quaternion.AngleAxis(TwisterParameter.MoveRotateGain * DirectionSign(rollDirection), front) * mainSceneView.rotation;        }

        private int DirectionSign(RollDirection rollDirection) {
            int sign = -1;
            if (rollDirection == RollDirection.Right) {
                sign = 1;
            }

            return sign;
        }
    }
}
