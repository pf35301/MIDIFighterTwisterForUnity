using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiJack;
using TwisterForUnity.MidiJack;

namespace TwisterForUnity {
    [CreateAssetMenu(menuName = "MIDIFighterTwisterForUnity/Twister Parameter Object")]
    public class TwisterParams : ScriptableObject {

        public string TwisterPortName;

        public MidiChannel channel;
        public uint Id;

        public Vector HandCameraTransform = new Vector(0, 1, 2); 
        public Vector MoveCameraTransform = new Vector(4, 5, 6); 
        public Vector RotateCameraTransform = new Vector(8, 9, 10);

        public int RightRoll = 0x41;
        public int LeftRoll = 0x3F;

        public void GetInfo() {
            channel = MidiJackEx.GetChannel(TwisterPortName);
            Id = MidiJackEx.GetId(channel);
        }

        public class Vector {
            public int x;
            public int y;
            public int z;

            public Vector(int x, int y, int z) {
                this.x = x;
                this.y = y;
                this.z = z;
            }
        }
    }
}
