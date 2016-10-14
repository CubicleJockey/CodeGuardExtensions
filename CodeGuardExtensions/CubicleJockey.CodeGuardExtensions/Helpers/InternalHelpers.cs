using System;
using System.Collections.Generic;

namespace CubicleJockey.CodeGuardExtensions.Helpers
{
    internal static class InternalHelpers
    {
        /// <summary>
        /// Checks if custom method is Null, Empty String or Whitespace.
        /// </summary>
        /// <param name="customMessage">Message to check</param>
        /// <param name="methodName">Name of the method providing the message.</param>
        public static void IsCustomMessageValid(string customMessage, string methodName)
        {
            if (string.IsNullOrWhiteSpace(customMessage))
            {
                throw new ArgumentException($"Cannot pass Null, Empty or Whitespace as {nameof(customMessage)} for {methodName} extension.");
            }
        }

        /// <summary>
        /// Checks if an object is set to its Default value
        /// </summary>
        /// <typeparam name="T">Type of Object</typeparam>
        /// <param name="value">Object to check</param>
        /// <returns>True if it is set to Default, else False</returns>
        public static bool IsDefault<T>(T value)
        {
            return EqualityComparer<T>.Default.Equals(value, default(T));
        }
    }
}
