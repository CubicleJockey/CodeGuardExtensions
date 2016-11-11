using System;
using CubicleJockey.CodeGuardExtensions.Helpers;
using Seterlund.CodeGuard;

namespace CubicleJockey.CodeGuardExtensions
{
    public static class CharExtensions
    {
        /// <summary>
        /// Extension method to IsEqual which allows a custom message.
        /// </summary>
        /// <param name="arg">Self</param>
        /// <param name="param">Value to compare</param>
        /// <param name="message">The Custom Message</param>
        /// <returns>Self</returns>
        public static IArg<char> IsEqual(this IArg<char> arg, char param, string message)
        {
            InternalHelpers.IsCustomMessageValid(message, nameof(IsEqual));
            try
            {
                Guard.That(arg.Value).IsEqual(param);
            }
            catch(Exception)
            {
                arg.Message.Set(message);
            }
            return arg;
        }

        /// <summary>
        /// Extension method to IsNotEqual which allows a custom message.
        /// </summary>
        /// <param name="arg">Self</param>
        /// <param name="param">Value to compare</param>
        /// <param name="message">The Custom Message</param>
        /// <returns>Self</returns>
        public static IArg<char> IsNotEqual(this IArg<char> arg, char param, string message)
        {
            InternalHelpers.IsCustomMessageValid(message, nameof(IsNotEqual));
            try
            {
                Guard.That(arg.Value).IsNotEqual(param);
            }
            catch (Exception)
            {
                arg.Message.Set(message);
            }
            return arg;
        }

        /// <summary>
        /// Extension method to IsGreaterThan which allows a custom message.
        /// </summary>
        /// <param name="arg">Self</param>
        /// <param name="param">Value to compare</param>
        /// <param name="message">The Custom Message</param>
        /// <returns>Self</returns>
        public static IArg<char> IsGreaterThan(this IArg<char> arg, char param, string message)
        {
            InternalHelpers.IsCustomMessageValid(message, nameof(IsGreaterThan));
            try
            {
                Guard.That(arg.Value).IsGreaterThan(param);
            }
            catch(Exception)
            {
                arg.Message.Set(message);
            }
            return arg;
        }

        /// <summary>
        /// Extension method to IsGreaterThan which allows a custom message.
        /// </summary>
        /// <param name="arg">Self</param>
        /// <param name="param">Function with return value to compare</param>
        /// <param name="message">The Custom Message</param>
        /// <returns>Self</returns>
        public static IArg<char> IsGreaterThan(this IArg<char> arg, Func<char> param, string message)
        {
            InternalHelpers.IsCustomMessageValid(message, nameof(IsGreaterThan));
            try
            {
                Guard.That(arg.Value).IsGreaterThan(param);
            }
            catch (Exception)
            {
                arg.Message.Set(message);
            }
            return arg;
        }

        /// <summary>
        /// Extension method to IsLessThan which allows a custom message.
        /// </summary>
        /// <param name="arg">Self</param>
        /// <param name="param">Value to compare</param>
        /// <param name="message">The Custom Message</param>
        /// <returns>Self</returns>
        public static IArg<char> IsLessThan(this IArg<char> arg, char param, string message)
        {
            InternalHelpers.IsCustomMessageValid(message, nameof(IsLessThan));
            try
            {
                Guard.That(arg.Value).IsLessThan(param);
            }
            catch(Exception)
            {
                arg.Message.Set(message);
            }
            return arg;
        }

        /// <summary>
        /// Extension method to IsLessThan which allows a custom message.
        /// </summary>
        /// <param name="arg">Self</param>
        /// <param name="param">Function with return value to compare</param>
        /// <param name="message">The Custom Message</param>
        /// <returns>Self</returns>
        public static IArg<char> IsLessThan(this IArg<char> arg, Func<char> param, string message)
        {
            InternalHelpers.IsCustomMessageValid(message, nameof(IsLessThan));
            try
            {
                Guard.That(arg.Value).IsLessThan(param);
            }
            catch (Exception)
            {
                arg.Message.Set(message);
            }
            return arg;
        }

        /// <summary>
        /// Extension method to IsLessThan which allows a custom message.
        /// </summary>
        /// <param name="arg">Self</param>
        /// <param name="start">Starting Character</param>
        /// <param name="end">Ending Character</param>
        /// <param name="message">The Custom Message</param>
        /// <returns>Self</returns>
        public static IArg<char> IsInRange(this IArg<char> arg, char start, char end, string message)
        {
            InternalHelpers.IsCustomMessageValid(message, nameof(IsInRange));
            try
            {
                Guard.That(arg.Value).IsInRange(start, end);
            }
            catch (Exception)
            {
                arg.Message.Set(message);
            }
            return arg;
        }
    }
}
