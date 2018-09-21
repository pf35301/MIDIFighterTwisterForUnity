using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TwisterForUnity.Extensions;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace TwisterForUnity.Editor {
    public sealed class SceneCameraMover {

        private SceneView mainSceneView;

        public SceneCameraMover(SceneView sceneView) {
            this.mainSceneView = sceneView;
        }

        public void MovePosition(TwisterParams TwisterParameter, byte rollData, Vector3 Ratio) {
            //Debug.Log(Ratio);
            var rollDirection = EnumConverter.ToEnum<RollDirection>(rollData);

            switch (rollDirection) {
                case RollDirection.PressDown:
                    mainSceneView.pivot = new Vector3(reverseFlag(Ratio.x) * mainSceneView.pivot.x, 
                                                      reverseFlag(Ratio.y) * mainSceneView.pivot.y,
                                                      reverseFlag(Ratio.z) * mainSceneView.pivot.z);
                    break;
                case RollDirection.Right:
                case RollDirection.Left:
                    mainSceneView.pivot += Ratio * TwisterParameter.MovePositionGain * DirectionSign(rollDirection);
                    break;
            }
        }

        public void MovePositionX(TwisterParams TwisterParameter, byte rollData) {
            //Debug.Log("posX");
            var rollDirection = EnumConverter.ToEnum<RollDirection>(rollData);

            switch (rollDirection) {
                case RollDirection.PressDown:
                    mainSceneView.pivot = new Vector3(0, mainSceneView.pivot.y, mainSceneView.pivot.z);
                    break;
                case RollDirection.Right:
                case RollDirection.Left:
                    mainSceneView.pivot += new Vector3(TwisterParameter.MovePositionGain * DirectionSign(rollDirection), 0, 0); 
                    break;
            }
        }

        public void MovePositionY(TwisterParams TwisterParamter, byte rollData) {
            //Debug.Log("posY");
            var rollDirection = EnumConverter.ToEnum<RollDirection>(rollData);

            switch (rollDirection) {
                case RollDirection.PressDown:
                    mainSceneView.pivot = new Vector3(mainSceneView.pivot.x, 0, mainSceneView.pivot.z);
                    break;
                case RollDirection.Right:
                case RollDirection.Left:
                    mainSceneView.pivot += new Vector3(0, TwisterParamter.MovePositionGain * DirectionSign(rollDirection), 0);
                    break;
            }
        }

        public void MovePositionZ(TwisterParams TwisterParameter, byte rollData) {
            //Debug.Log("posZ");
            var rollDirection = EnumConverter.ToEnum<RollDirection>(rollData);

            switch (rollDirection) {
                case RollDirection.PressDown:
                    mainSceneView.pivot = new Vector3(mainSceneView.pivot.x, mainSceneView.pivot.y, 0);
                    break;
                case RollDirection.Right:
                case RollDirection.Left:
                    mainSceneView.pivot += new Vector3(0, 0, TwisterParameter.MovePositionGain * DirectionSign(rollDirection));
                    break;
            }
        }

        public void ResetPosition(TwisterParams TwisterParameter, byte rollData) {
            //Debug.Log("ResetPos");
            var rollDirection = EnumConverter.ToEnum<RollDirection>(rollData);

            switch (rollDirection) {
                case RollDirection.PressDown:
                    mainSceneView.pivot = Vector3.zero;
                    break;
            }
        }

        public void MoveRotation(TwisterParams TwisterParameter, byte rollData, Vector3 Ratio) {
            //Debug.Log("");
            var rollDirection = EnumConverter.ToEnum<RollDirection>(rollData);

            switch (rollDirection) {
                case RollDirection.PressDown:
                    mainSceneView.rotation = Quaternion.Euler(reverseFlag(Ratio.x) * mainSceneView.rotation.eulerAngles.x,
                                                              reverseFlag(Ratio.y) * mainSceneView.rotation.eulerAngles.y,
                                                              reverseFlag(Ratio.z) * mainSceneView.rotation.eulerAngles.z);
                    break;
                case RollDirection.Right:
                case RollDirection.Left:
                    mainSceneView.rotation = Quaternion.Euler((Ratio * TwisterParameter.MoveRotateGain * DirectionSign(rollDirection)) + mainSceneView.rotation.eulerAngles);
                    break;
            }
        }

        public void MoveRotationX(TwisterParams TwisterParameter, byte rollData) {
            //Debug.Log("rotX");
            var rollDirection = EnumConverter.ToEnum<RollDirection>(rollData);

            switch (rollDirection) {
                case RollDirection.PressDown:
                    mainSceneView.rotation = new Quaternion(default(Quaternion).x, mainSceneView.rotation.y, default(Quaternion).z, mainSceneView.rotation.w);
                    break;
                case RollDirection.Right:
                case RollDirection.Left:
                    mainSceneView.rotation = Quaternion.Euler((Vector3.left * TwisterParameter.MoveRotateGain * DirectionSign(rollDirection)) + mainSceneView.rotation.eulerAngles);
                    break;
            }
        }

        public void MoveRotationY(TwisterParams TwisterParameter, byte rollData) {
            //Debug.Log("rotY");
            var rollDirection = EnumConverter.ToEnum<RollDirection>(rollData);

            switch (rollDirection) {
                case RollDirection.PressDown:
                    mainSceneView.rotation = new Quaternion(default(Quaternion).x, default(Quaternion).y, mainSceneView.rotation.z, mainSceneView.rotation.w);
                    break;
                case RollDirection.Right:
                case RollDirection.Left:
                    Debug.Log("rotation:" + mainSceneView.rotation.eulerAngles);
                    mainSceneView.rotation = Quaternion.Euler((Vector3.up * TwisterParameter.MoveRotateGain * DirectionSign(rollDirection)) + mainSceneView.rotation.eulerAngles);
                    break;
            }
        }

        public void MoveRotationZ(TwisterParams TwisterParameter, byte rollData) {
            //Debug.Log("rotZ");
            var rollDirection = EnumConverter.ToEnum<RollDirection>(rollData);

            switch (rollDirection) {
                case RollDirection.PressDown:
                    mainSceneView.rotation = new Quaternion(mainSceneView.rotation.x, default(Quaternion).y, default(Quaternion).z, mainSceneView.rotation.w);
                    break;
                case RollDirection.Right:
                case RollDirection.Left:
                    Debug.Log("rotation:" + mainSceneView.rotation.eulerAngles);
                    mainSceneView.rotation = Quaternion.Euler((Vector3.forward * TwisterParameter.MoveRotateGain * DirectionSign(rollDirection)) + mainSceneView.rotation.eulerAngles);
                    break;
            }
        }

        public void ResetRotation(TwisterParams TwisterParametr, byte rollData) {
            //Debug.Log("ResetRota");
            var rollDirection = EnumConverter.ToEnum<RollDirection>(rollData);

            switch (rollDirection) {
                case RollDirection.PressDown:
                    mainSceneView.rotation = new Quaternion(default(Quaternion).x, default(Quaternion).y, default(Quaternion).z, default(Quaternion).w);
                    break;
            }
        }

        public void ChangeOrthographic(TwisterParams TwisterParameter, byte rollData) {
            //Debug.Log("ChangeOrthographic");
            var rollDirection = EnumConverter.ToEnum<RollDirection>(rollData);

            switch (rollDirection) {
                case RollDirection.PressDown:
                    mainSceneView.orthographic = !mainSceneView.orthographic;
                    break;
            }
        }

        private int DirectionSign(RollDirection rollDirection) {
            int sign = -1;
            if (rollDirection == RollDirection.Right) {
                sign = 1;
            }

            return sign;
        }

        private int reverseFlag(float flag) {

            if (flag == 0f) {
                return 1;
            }

            return 0;
        }
    }

}
