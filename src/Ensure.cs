using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace GuardsNet
{
    internal static partial class Ensure
    {
        [DebuggerNonUserCode]
        public static void True(bool condition, string error)
        {
            True<InvalidOperationException>(condition, error);
        }

        [DebuggerNonUserCode]
        public static void True<TException>(bool condition, string error)
            where TException : Exception
        {
            Require.NotEmpty(error, "error");

            if (condition)
            {
                return;
            }

            throw (TException)Activator.CreateInstance(typeof(TException), error);
        }

        [DebuggerNonUserCode]
        public static void True<TException>(bool condition)
            where TException : Exception
        {
            if (condition)
            {
                return;
            }

            throw Activator.CreateInstance<TException>();
        }

        [DebuggerNonUserCode]
        public static void True<TException>(bool condition, TException exception)
            where TException : Exception
        {
            Require.NotNull(exception, "exception");

            if (condition)
            {
                return;
            }

            throw exception;
        }

        [DebuggerNonUserCode]
        public static void True<TException>(bool condition, Func<TException> exception)
            where TException : Exception
        {
            Require.NotNull(exception, "exception");

            if (condition)
            {
                return;
            }

            throw exception();
        }

        [DebuggerNonUserCode]
        public static void False(bool condition, string error)
        {
            False<InvalidOperationException>(condition, error);
        }

        [DebuggerNonUserCode]
        public static void False<TException>(bool condition, string error)
            where TException : Exception
        {
            True<TException>(condition == false, error);
        }

        [DebuggerNonUserCode]
        public static void False<TException>(bool condition)
            where TException : Exception
        {
            True<TException>(condition == false);
        }

        [DebuggerNonUserCode]
        public static void False<TException>(bool condition, TException exception)
            where TException : Exception
        {
            True(condition == false, exception);
        }

        [DebuggerNonUserCode]
        public static void False<TException>(bool condition, Func<TException> exception)
            where TException : Exception
        {
            True(condition == false, exception);
        }
    }
}
