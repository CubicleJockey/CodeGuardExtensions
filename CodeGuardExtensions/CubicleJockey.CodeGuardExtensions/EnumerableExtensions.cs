using System;
using Seterlund.CodeGuard;

namespace CubicleJockey.CodeGuardExtensions
{
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Extension method to IsNotEmpty which allows a custom message
        /// </summary>
        /// <param name="arg">Self</param>
        /// <param name="message">The Custom Message</param>
        /// <returns>Self</returns>
        public static IArg<T[]> IsNotEmpty<T>(this IArg<T[]> arg, string message)
        {
            InternalHelpers.IsCustomMessageValid(message, nameof(IsNotEmpty));
            try
            {
                Guard.That(arg.Value).IsNotEmpty();
            }
            catch (Exception)
            {
                arg.Message.Set(message);
            }
            return arg;
        }
    }
}
