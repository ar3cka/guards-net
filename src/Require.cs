using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;

namespace GuardsNet
{
    internal static partial class Require
    {
        [DebuggerNonUserCode]
        public static void True(bool value, string param, string message)
        {
            if (value == false)
            {
                throw new ArgumentException(message, param);
            }
        }

        [DebuggerNonUserCode]
        public static void False(bool value, string param, string message)
        {
            if (value)
            {
                throw new ArgumentException(message, param);
            }
        }

        [DebuggerNonUserCode]
        public static void ZeroOrGreater(long value, string param)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(param, value, "Value must be zero or greater.");
            }
        }

        [DebuggerNonUserCode]
        public static void ZeroOrGreater(int value, string param)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(param, value, "Value must be zero or greater.");
            }
        }

        [DebuggerNonUserCode]
        public static void Positive(long value, string param)
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(param, value, "Value must be greater than zero.");
            }
        }

        [DebuggerNonUserCode]
        public static void Positive(int value, string param)
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(param, value, "Value must be greater than zero.");
            }
        }

        [DebuggerNonUserCode]
        public static void NotNull(object value, string param)
        {
            if (value == null)
            {
                throw new ArgumentNullException(param);
            }
        }

        [DebuggerNonUserCode]
        public static void NotEmpty(string value, string param)
        {
            False(string.IsNullOrEmpty(value), param, "Value must be not empty.");
        }

        [DebuggerNonUserCode]
        public static void NotEmpty(Guid value, string param)
        {
            False(value == Guid.Empty, param, "Value must be not empty.");
        }

        [DebuggerNonUserCode]
        public static void NotEmpty<T>(IEnumerable<T> value, string param)
        {
            True(value.Any(), param, "Collection must be not empty.");
        }
    }
}
