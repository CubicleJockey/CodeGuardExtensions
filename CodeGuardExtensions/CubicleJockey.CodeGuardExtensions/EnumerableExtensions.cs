using System;
using System.Linq;
using CubicleJockey.CodeGuardExtensions.Helpers;
using Seterlund.CodeGuard;

namespace CubicleJockey.CodeGuardExtensions
{
    public static class EnumerableExtensions
    {
        public static IArg<T[]> IsEmpty<T>(this IArg<T[]> arg)
        {
            try
            {
                Guard.That(arg.Value.AsEnumerable()).IsEmpty();
            }
            catch (Exception)
            {
                arg.Message.Set($"{typeof(T).Name}[] should not be empty.");
            }
            return arg;
        }

        public static IArg<T[]> IsEmpty<T>(this IArg<T[]> arg, string message)
        {
            InternalHelpers.IsCustomMessageValid(message, nameof(IsEmpty));
            try
            {
                Guard.That(arg.Value.AsEnumerable()).IsEmpty();
            }
            catch (Exception)
            {
                arg.Message.Set(message);
            }
            return arg;
        }

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
