using System;

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
    }
}
