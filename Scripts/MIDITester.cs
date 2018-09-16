using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TwisterForUnity;
using TwisterForUnity.MidiJack;
using MidiJack;

namespace TwisterForUnity.Test {
    public class MIDITester : MonoBehaviour {

        [SerializeField]
        private TwisterObject TwisterParam;

	    // Use this for initialization
	    void Start () {
            TwisterParam.GetInfo();
	    }
	
	    // Update is called once per frame
	    void Update () {
            //Debug.Log(MidiMaster.GetKeyDown(TwisterParam.channel, TwisterParam.HandCameraTransform.x));

            var data = new MidiMessage(MidiJackEx.DequeueIncomingData());

            Debug.Log(data.ToString());
        }


    }

}

