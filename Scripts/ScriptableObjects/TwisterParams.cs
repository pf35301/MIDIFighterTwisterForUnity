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

        public float MovePositionGain;
        public float MoveRotationGain;

        [Header("MIDI Fighter Twister")]
        public byte CCMidiRangeMin;
        public byte CCMidiRangeMax;

        public TwisterParams(string TwisterPortName) {
            this.TwisterPortName = TwisterPortName;
        }

        public void GetInfo() {
            channel = MidiJackEx.GetChannel(TwisterPortName);
            id = MidiJackEx.GetId(channel);
        }
    }

    public enum Direction3FTo41 : byte {
        Right = 0x41,
        Left = 0x3f,
        PressDown = 0x7f,
        PressUp = 0x00
    }

    public enum MidiStatus : byte {
        Press = 0xB1,
        Roll = 0xB0
    }
}
