using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TwisterForUnity;
using TwisterForUnity.MidiJack;
using MidiJack;

namespace TwisterForUnity.Test {
    public class MIDITester : MonoBehaviour {

        [SerializeField]
        private TwisterParams TwisterParam;

	    // Use this for initialization
	    void Start () {
            TwisterParam.GetInfo();
	    }
	
	    // Update is called once per frame
	    void Update () {
            var data = new MidiMessage(MidiJackEx.DequeueIncomingData());

            if (data.data1 == TwisterParam.HandCameraTransform.x) {

                if (data.data2 == TwisterParam.RightRoll) {
                    Debug.Log("Right");
                }

                if (data.data2 == TwisterParam.LeftRoll) {
                    Debug.Log("Left");
                }
                
            }
        }
    }
}

