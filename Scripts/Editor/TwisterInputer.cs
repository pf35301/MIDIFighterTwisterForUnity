using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TwisterForUnity;
using TwisterForUnity.Extensions;
using MidiJack;

namespace TwisterForUnity.Editor {
    public sealed class TwisterInputer {

        public TwisterHandler<TwisterParams, RollDirection> TwisterEvent00 = new TwisterHandler<TwisterParams, RollDirection>();
        public TwisterHandler<TwisterParams, RollDirection> TwisterEvent01 = new TwisterHandler<TwisterParams, RollDirection>();
        public TwisterHandler<TwisterParams, RollDirection> TwisterEvent02 = new TwisterHandler<TwisterParams, RollDirection>();
        public TwisterHandler<TwisterParams, RollDirection> TwisterEvent03 = new TwisterHandler<TwisterParams, RollDirection>();
        public TwisterHandler<TwisterParams, RollDirection> TwisterEvent04 = new TwisterHandler<TwisterParams, RollDirection>();
        public TwisterHandler<TwisterParams, RollDirection> TwisterEvent05 = new TwisterHandler<TwisterParams, RollDirection>();
        public TwisterHandler<TwisterParams, RollDirection> TwisterEvent06 = new TwisterHandler<TwisterParams, RollDirection>();
        public TwisterHandler<TwisterParams, RollDirection> TwisterEvent07 = new TwisterHandler<TwisterParams, RollDirection>();
        public TwisterHandler<TwisterParams, RollDirection> TwisterEvent08 = new TwisterHandler<TwisterParams, RollDirection>();
        public TwisterHandler<TwisterParams, RollDirection> TwisterEvent09 = new TwisterHandler<TwisterParams, RollDirection>();
        public TwisterHandler<TwisterParams, RollDirection> TwisterEvent10 = new TwisterHandler<TwisterParams, RollDirection>();
        public TwisterHandler<TwisterParams, RollDirection> TwisterEvent11 = new TwisterHandler<TwisterParams, RollDirection>();
        public TwisterHandler<TwisterParams, RollDirection> TwisterEvent12 = new TwisterHandler<TwisterParams, RollDirection>();
        public TwisterHandler<TwisterParams, RollDirection> TwisterEvent13 = new TwisterHandler<TwisterParams, RollDirection>();
        public TwisterHandler<TwisterParams, RollDirection> TwisterEvent14 = new TwisterHandler<TwisterParams, RollDirection>();
        public TwisterHandler<TwisterParams, RollDirection> TwisterEvent15 = new TwisterHandler<TwisterParams, RollDirection>();

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

        public void Update (TwisterParams Twister) {
            var message = new MidiMessage(MidiJackEx.DequeueIncomingData());

            if (Twister.Id != message.source) {
                return;
            }

            EventSelecter(EnumConverter.ToEnum<TwisterNumber>(message.data1), EnumConverter.ToEnum<RollDirection>(message.data2), Twister);
        }

        private void EventSelecter(TwisterNumber twiNum, RollDirection rollDirection, TwisterParams twister) {
            switch (twiNum) {
                case TwisterNumber.TwisterNumber00:
                    TwisterEvent00?.Invoke(twister, rollDirection);
                    break;
                case TwisterNumber.TwisterNumber01:
                    TwisterEvent01.Invoke(twister, rollDirection);
                    break;
                case TwisterNumber.TwisterNumber02:
                    TwisterEvent02.Invoke(twister, rollDirection);
                    break;
                case TwisterNumber.TwisterNumber03:
                    TwisterEvent03.Invoke(twister, rollDirection);
                    break;
                case TwisterNumber.TwisterNumber04:
                    TwisterEvent04.Invoke(twister, rollDirection);
                    break;
                case TwisterNumber.TwisterNumber05:
                    TwisterEvent05.Invoke(twister, rollDirection);
                    break;
                case TwisterNumber.TwisterNumber06:
                    TwisterEvent06.Invoke(twister, rollDirection);
                    break;
                case TwisterNumber.TwisterNumber07:
                    TwisterEvent07.Invoke(twister, rollDirection);
                    break;
                case TwisterNumber.TwisterNumber08:
                    TwisterEvent08.Invoke(twister, rollDirection);
                    break;
                case TwisterNumber.TwisterNumber09:
                    TwisterEvent09.Invoke(twister, rollDirection);
                    break;
                case TwisterNumber.TwisterNumber10:
                    TwisterEvent10.Invoke(twister, rollDirection);
                    break;
                case TwisterNumber.TwisterNumber11:
                    TwisterEvent11.Invoke(twister, rollDirection);
                    break;
                case TwisterNumber.TwisterNumber12:
                    TwisterEvent12.Invoke(twister, rollDirection);
                    break;
                case TwisterNumber.TwisterNumber13:
                    TwisterEvent13.Invoke(twister, rollDirection);
                    break;
                case TwisterNumber.TwisterNumber14:
                    TwisterEvent14.Invoke(twister, rollDirection);
                    break;
                case TwisterNumber.TwisterNumber15:
                    TwisterEvent15.Invoke(twister, rollDirection);
                    break;
            }
        }

        public sealed class TwisterHandler<TwisterParams, RollDirection> : UnityEvent<TwisterParams, RollDirection> {

        }
    }
}

