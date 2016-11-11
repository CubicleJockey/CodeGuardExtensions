using System;
using CubicleJockey.CodeGuardExtensions.Helpers;
using Seterlund.CodeGuard;

namespace CubicleJockey.CodeGuardExtensions
{
    public static class BoolExtensions
    {
        /// <summary>
        /// Custom message for IsTrue
        /// </summary>
        /// <param name="arg">Self</param>
        /// <param name="message">Custom Message</param>
        /// <returns>Self</returns>
        public static IArg<bool> IsTrue(this IArg<bool> arg, string message)
        {
            InternalHelpers.IsCustomMessageValid(message, nameof(IsTrue));
            try
            {
                Guard.That(arg.Value).IsTrue();
            }
            catch (Exception)
            {
                arg.Message.Set(message);
            }
            return arg;
        }

        /// <summary>
        /// Custom Message for IsFalse
        /// </summary>
        /// <param name="arg">Self</param>
        /// <param name="message">Custom Message</param>
        /// <returns>Self</returns>
        public static IArg<bool> IsFalse(this IArg<bool> arg, string message)
        {
            InternalHelpers.IsCustomMessageValid(message, nameof(IsFalse));
            try
            {
                Guard.That(arg.Value).IsFalse();
            }
            catch (Exception)
            {
                arg.Message.Set(message);
            }
            return arg;
        }
    }
}
