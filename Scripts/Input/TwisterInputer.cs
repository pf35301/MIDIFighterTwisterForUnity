using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TwisterForUnity;
using TwisterForUnity.Extensions;
using MidiJack;

namespace TwisterForUnity.Input {
    public sealed class SingletonTwisterInputer {

        private static SingletonTwisterInputer SingletonInstance = new SingletonTwisterInputer();

        public List<TwisterEvent<TwisterParams, byte, byte>> TwisterEvents = new List<TwisterEvent<TwisterParams, byte, byte>>();

        public static SingletonTwisterInputer GetInstance() {
            return SingletonInstance;
        }

        public void Update(TwisterParams Twister) {
            var message = new MidiMessage(MidiJackEx.DequeueIncomingData());

            if (Twister.Id != message.source) {
                return;
            }

            EventSelecter(message.data1, message.status, message.data2, Twister);
        }

        public void AddTwisterEvents(TwisterParams Twister) {
            TwisterEvents.Clear();
            for (int twisterNumber = 0; twisterNumber < Twister.TheNumberOfTwister; twisterNumber++) {
                TwisterEvents.Add(new TwisterEvent<TwisterParams, byte, byte>());
            }
        }

        private void EventSelecter(byte twiNum, byte status, byte rollData, TwisterParams twister) {
            TwisterEvents[twiNum].Invoke(twister, status, rollData);
        }

        public sealed class TwisterEvent<T1, T2, T3> : UnityEvent<T1, T2, T3> {

        }
    }
}

