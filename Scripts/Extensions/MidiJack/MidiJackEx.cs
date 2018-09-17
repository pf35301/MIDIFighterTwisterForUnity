using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using MidiJack;

namespace TwisterForUnity.Extensions {

    public static class MidiJackEx  {

        public static MidiChannel GetChannel(string TargetMidiDeviceName) {

            var endpointCount = CountEndpoints();

            for (var i = 0; i < endpointCount; i++) {
                var id = GetEndpointIdAtIndex(i);
                var name = GetEndpointName(id);

                if (TargetMidiDeviceName == name) {
                    return (MidiChannel)i;
                }

            }

            return MidiChannel.All;
        }

        public static uint GetId(string TargetMidiDeviceName) {

            var endpointCount = CountEndpoints();

            for (var i = 0; i < endpointCount; i++) {
                var id = GetEndpointIdAtIndex(i);
                var name = GetEndpointName(id);

                if (TargetMidiDeviceName == name) {
                    return id;
                }
            }

            return new uint();
        }

        public static uint GetId(int Index) {
            return GetEndpointIdAtIndex(Index);
        }

        public static uint GetId(MidiChannel channel) {
            return GetEndpointIdAtIndex((int)channel);
        }

        #region Native Plugin Interface

        [DllImport("MidiJackPlugin", EntryPoint = "MidiJackCountEndpoints")]
        public static extern int CountEndpoints();

        [DllImport("MidiJackPlugin", EntryPoint = "MidiJackGetEndpointIDAtIndex")]
        public static extern uint GetEndpointIdAtIndex(int index);

        [DllImport("MidiJackPlugin")]
        public static extern System.IntPtr MidiJackGetEndpointName(uint id);

        [DllImport("MidiJackPlugin", EntryPoint = "MidiJackDequeueIncomingData")]
        public static extern ulong DequeueIncomingData();

        public static string GetEndpointName(uint id) {
            return Marshal.PtrToStringAnsi(MidiJackGetEndpointName(id));
        }

        #endregion
    }
}

