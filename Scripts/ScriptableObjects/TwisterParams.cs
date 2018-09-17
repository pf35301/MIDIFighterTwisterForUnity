using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiJack;
using TwisterForUnity.Extensions;

namespace TwisterForUnity {
    [CreateAssetMenu(menuName = "MIDIFighterTwisterForUnity/Twister Parameter Object")]
    public sealed class TwisterParams : ScriptableObject {

        public string TwisterPortName;
        private bool initialized = false;

        public MidiChannel Channel {
            get {
                if (!initialized) {
                    GetInfo();
                    initialized = true;
                }
                return channel;
            }
        }
        public uint Id {
            get {
                if(!initialized) {
                    GetInfo();
                    initialized = false;
                }
                return id;
            }
        }

        private MidiChannel channel;
        private uint id;

        public Vector HandCameraTransform = new Vector(0, 1, 2); 
        public Vector MoveCameraTransform = new Vector(4, 5, 6); 
        public Vector RotateCameraTransform = new Vector(8, 9, 10);

        public float MoveHandCameraGain;
        public float MoveMoveCameraGain;
        public float MoveRotateCameraGain;

        public TwisterParams(string TwisterPortName) {
            this.TwisterPortName = TwisterPortName;
        }

        public void GetInfo() {
            channel = MidiJackEx.GetChannel(TwisterPortName);
            id = MidiJackEx.GetId(channel);
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
    public enum RollDirection : byte {
        None = 0x00,
        Right = 0x41,
        Left = 0x3f
    }
}
