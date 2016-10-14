using System;
using CubicleJockey.CodeGuardExtensions.Helpers;
using Seterlund.CodeGuard;

namespace CubicleJockey.CodeGuardExtensions
{
    public static class IntExtensions
    {
        /// <summary>
        /// Extensions method to add a Custom Message to IsPositive
        /// </summary>
        /// <param name="arg">Self</param>
        /// <param name="message">Custom Message</param>
        /// <returns>Self</returns>
        public static IArg<int> IsPositive(this IArg<int> arg, string message)
        {
            InternalHelpers.IsCustomMessageValid(message, nameof(IsPositive));
            try
            {
                Guard.That(arg.Value).IsPositive();
            }
            catch(Exception)
            {
                arg.Message.Set(message);
            }
            return arg;
        }

        /// <summary>
        /// Extension method to add a Custom Message to IsNegative
        /// </summary>
        /// <param name="arg">Self</param>
        /// <param name="message">Custom Message</param>
        /// <returns>Self</returns>
        public static IArg<int> IsNegative(this IArg<int> arg, string message)
        {
            InternalHelpers.IsCustomMessageValid(message, nameof(IsNegative));
            try
            {
                Guard.That(arg.Value).IsNegative();
            }
            catch(Exception)
            {
                arg.Message.Set(message);
            }
            return arg;
        }
    }
}
