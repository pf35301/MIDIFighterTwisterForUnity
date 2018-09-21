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

        private static SingletonTwisterInputer singletonInstance = new SingletonTwisterInputer();

        public TwisterEvent<TwisterParams, byte> TwisterEvent00 = new TwisterEvent<TwisterParams, byte>();
        public TwisterEvent<TwisterParams, byte> TwisterEvent01 = new TwisterEvent<TwisterParams, byte>();
        public TwisterEvent<TwisterParams, byte> TwisterEvent02 = new TwisterEvent<TwisterParams, byte>();
        public TwisterEvent<TwisterParams, byte> TwisterEvent03 = new TwisterEvent<TwisterParams, byte>();
        public TwisterEvent<TwisterParams, byte> TwisterEvent04 = new TwisterEvent<TwisterParams, byte>();
        public TwisterEvent<TwisterParams, byte> TwisterEvent05 = new TwisterEvent<TwisterParams, byte>();
        public TwisterEvent<TwisterParams, byte> TwisterEvent06 = new TwisterEvent<TwisterParams, byte>();
        public TwisterEvent<TwisterParams, byte> TwisterEvent07 = new TwisterEvent<TwisterParams, byte>();
        public TwisterEvent<TwisterParams, byte> TwisterEvent08 = new TwisterEvent<TwisterParams, byte>();
        public TwisterEvent<TwisterParams, byte> TwisterEvent09 = new TwisterEvent<TwisterParams, byte>();
        public TwisterEvent<TwisterParams, byte> TwisterEvent10 = new TwisterEvent<TwisterParams, byte>();
        public TwisterEvent<TwisterParams, byte> TwisterEvent11 = new TwisterEvent<TwisterParams, byte>();
        public TwisterEvent<TwisterParams, byte> TwisterEvent12 = new TwisterEvent<TwisterParams, byte>();
        public TwisterEvent<TwisterParams, byte> TwisterEvent13 = new TwisterEvent<TwisterParams, byte>();
        public TwisterEvent<TwisterParams, byte> TwisterEvent14 = new TwisterEvent<TwisterParams, byte>();
        public TwisterEvent<TwisterParams, byte> TwisterEvent15 = new TwisterEvent<TwisterParams, byte>();

        public static SingletonTwisterInputer GetInstance() {
            return singletonInstance;
        }

        public void Update(TwisterParams Twister) {
            var message = new MidiMessage(MidiJackEx.DequeueIncomingData());

            if (Twister.Id != message.source) {
                return;
            }

            EventSelecter(EnumConverter.ToEnum<TwisterNumber>(message.data1), message.data2, Twister);
        }

        private void EventSelecter(TwisterNumber twiNum, byte rollData, TwisterParams twister) {
            switch (twiNum) {
                case TwisterNumber.TwisterNumber00:
                    TwisterEvent00.Invoke(twister, rollData);
                    break;
                case TwisterNumber.TwisterNumber01:
                    TwisterEvent01.Invoke(twister, rollData);
                    break;
                case TwisterNumber.TwisterNumber02:
                    TwisterEvent02.Invoke(twister, rollData);
                    break;
                case TwisterNumber.TwisterNumber03:
                    TwisterEvent03.Invoke(twister, rollData);
                    break;
                case TwisterNumber.TwisterNumber04:
                    TwisterEvent04.Invoke(twister, rollData);
                    break;
                case TwisterNumber.TwisterNumber05:
                    TwisterEvent05.Invoke(twister, rollData);
                    break;
                case TwisterNumber.TwisterNumber06:
                    TwisterEvent06.Invoke(twister, rollData);
                    break;
                case TwisterNumber.TwisterNumber07:
                    TwisterEvent07.Invoke(twister, rollData);
                    break;
                case TwisterNumber.TwisterNumber08:
                    TwisterEvent08.Invoke(twister, rollData);
                    break;
                case TwisterNumber.TwisterNumber09:
                    TwisterEvent09.Invoke(twister, rollData);
                    break;
                case TwisterNumber.TwisterNumber10:
                    TwisterEvent10.Invoke(twister, rollData);
                    break;
                case TwisterNumber.TwisterNumber11:
                    TwisterEvent11.Invoke(twister, rollData);
                    break;
                case TwisterNumber.TwisterNumber12:
                    TwisterEvent12.Invoke(twister, rollData);
                    break;
                case TwisterNumber.TwisterNumber13:
                    TwisterEvent13.Invoke(twister, rollData);
                    break;
                case TwisterNumber.TwisterNumber14:
                    TwisterEvent14.Invoke(twister, rollData);
                    break;
                case TwisterNumber.TwisterNumber15:
                    TwisterEvent15.Invoke(twister, rollData);
                    break;
            }
        }

        public enum TwisterNumber : byte {
            TwisterNumber00 = 0x00,
            TwisterNumber01 = 0x01,
            TwisterNumber02 = 0x02,
            TwisterNumber03 = 0x03,
            TwisterNumber04 = 0x04,
            TwisterNumber05 = 0x05,
            TwisterNumber06 = 0x06,
            TwisterNumber07 = 0x07,
            TwisterNumber08 = 0x08,
            TwisterNumber09 = 0x09,
            TwisterNumber10 = 0x0A,
            TwisterNumber11 = 0x0B,
            TwisterNumber12 = 0x0C,
            TwisterNumber13 = 0x0D,
            TwisterNumber14 = 0x0E,
            TwisterNumber15 = 0x0F
        }

        public sealed class TwisterEvent<T1, T2> : UnityEvent<T1, T2> {

        }
    }
}

