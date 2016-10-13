using System;
using System.Collections.Generic;

namespace CubicleJockey.CodeGuardExtensions
{
    internal static class InternalHelpers
    {
        public static void IsCustomMessageValid(string customMessage, string methodName)
        {
            if (string.IsNullOrWhiteSpace(customMessage))
            {
                throw new ArgumentException($"Cannot pass Null, Empty or Whitespace as {nameof(customMessage)} for {methodName} extension.");
            }
        }

        public static bool IsDefault<T>(T value)
        {
            return EqualityComparer<T>.Default.Equals(value, default(T));
        }
    }
}
