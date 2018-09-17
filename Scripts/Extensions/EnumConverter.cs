using System;

namespace TwisterForUnity.Extensions {
    class EnumConverter {
        public static T ToEnum<T>(object value) where T : struct {
            if (Enum.IsDefined(typeof(T), value)) {
                return (T)value;
            }
            else {
                throw new ArgumentException();
            }
        }
    }
}
