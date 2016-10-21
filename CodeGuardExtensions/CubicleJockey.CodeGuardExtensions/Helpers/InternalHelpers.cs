using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

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


        /// <summary>
        /// Check if a integer value is Prime
        /// </summary>
        /// <typeparam name="T">An integer type.</typeparam>
        /// <param name="value">Value to check for Primeness</param>
        /// <returns>True if Prime, else False</returns>
        public static bool IsPrime<T>(T value)
        {
            var validTypes = new[]
            {
                typeof(byte),
                typeof(sbyte),
                typeof(ushort),
                typeof(short),
                typeof(uint),
                typeof(int),
                typeof(ulong),
                typeof(long)
            };

            if(!validTypes.Contains(typeof(T)))
            {
                throw new InternalHelperException($"{nameof(T)} cannot be checked for prime status as it is not an integer.");
            }

            long checkValue;

            if(!long.TryParse(value.ToString(), out checkValue))
            {
                throw new InternalHelperException($"Failed to convert {nameof(T)} to a type of long.");
            }

            if (checkValue < 2)
            {
                return false;
            }

            var squareRootOfValue = (long)Math.Sqrt(checkValue);
            for (var i = 2; i <= squareRootOfValue; i++)
            {
                // If remainder is 0, number is not prime
                if (checkValue % i == 0)
                {
                    // return false
                    return false;
                }
            }
            return true;
        }
    }

    internal class InternalHelperException : Exception
    {
        public InternalHelperException(string message) : base(message) { }
        public InternalHelperException(string message, Exception innerException) : base(message, innerException) { }
        public InternalHelperException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
