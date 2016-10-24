using System;
using CubicleJockey.CodeGuardExtensions.Helpers;
using Seterlund.CodeGuard;

namespace CubicleJockey.CodeGuardExtensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Extension method to IsNotNullOrWhiteSpace which allows a custom message.
        /// </summary>
        /// <param name="arg">Self</param>
        /// <param name="message">The Custom Message</param>
        /// <returns>Self</returns>
        public static IArg<string> IsNotNullOrWhiteSpace(this IArg<string> arg, string message)
        {
            InternalHelpers.IsCustomMessageValid(message, nameof(IsNotNullOrWhiteSpace));
            try
            {
                Guard.That(arg.Value).IsNotNullOrWhiteSpace();
            }
            catch(Exception)
            {
                arg.Message.Set(message);
            }
            return arg;
        }

        /// <summary>
        /// Extension method to IsNotEmpty which allows a custom message.
        /// </summary>
        /// <param name="arg">Self</param>
        /// <param name="message">The Custom Message</param>
        /// <returns>Self</returns>
        public static IArg<string> IsNotEmpty(this IArg<string> arg, string message)
        {
            InternalHelpers.IsCustomMessageValid(message, nameof(IsNotEmpty));
            try
            {
                Guard.That(arg.Value).IsNotEmpty();
            }
            catch(Exception)
            {
                arg.Message.Set(message);
            }
            return arg;
        }

        /// <summary>
        /// Extension method to Contains which allows a custom message.
        /// </summary>
        /// <param name="arg">Self</param>
        /// <param name="message">The Custom Message</param>
        /// <returns>Self</returns>
        public static IArg<string> Contains(this IArg<string> arg, string value, string message)
        {
            InternalHelpers.IsCustomMessageValid(message, nameof(Contains));
            try
            {
                Guard.That(arg.Value).Contains(value);
            }
            catch(Exception)
            {
                arg.Message.Set(message);
            }
            return arg;
        }

        /// <summary>
        /// Extension method to EndsWith which allows a custom message.
        /// </summary>
        /// <param name="arg">Self</param>
        /// <param name="message">The Custom Message</param>
        /// <returns>Self</returns>
        public static IArg<string> EndsWith(this IArg<string> arg, string value, string message)
        {
            InternalHelpers.IsCustomMessageValid(message, nameof(EndsWith));
            try
            {
                Guard.That(arg.Value).EndsWith(value);
            }
            catch(Exception)
            {
                arg.Message.Set(message);
            }
            return arg;
        }

        /// <summary>
        /// Extension method to IsMatch which allows a custom message.
        /// </summary>
        /// <param name="arg">Self</param>
        /// <param name="message">The Custom Message</param>
        /// <returns>Self</returns>
        public static IArg<string> IsMatch(this IArg<string> arg, string pattern, string message)
        {
            InternalHelpers.IsCustomMessageValid(message, nameof(IsMatch));
            try
            {
                Guard.That(arg.Value).IsMatch(pattern);
            }
            catch(Exception)
            {
                arg.Message.Set(message);
            }
            return arg;
        }
    }
}
