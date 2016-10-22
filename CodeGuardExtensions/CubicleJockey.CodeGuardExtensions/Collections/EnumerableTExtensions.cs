using System;
using System.Collections.Generic;
using System.Linq;
using CubicleJockey.CodeGuardExtensions.Helpers;
using Seterlund.CodeGuard;

namespace CubicleJockey.CodeGuardExtensions
{
    public static class EnumerableTExtensions
    {
        public static IArg<IEnumerable<T>> IsEmpty<T>(this IArg<IEnumerable<T>> arg)
        {
            try
            {
                if (arg.Value.Any())
                {
                    throw new ArgumentNullException();
                }
            }
            catch (Exception)
            {
                arg.Message.Set("IEnumberable<T> should be empty.");
            }
            return arg;
        }

        public static IArg<IEnumerable<T>> IsEmpty<T>(this IArg<IEnumerable<T>> arg, string message)
        {
            InternalHelpers.IsCustomMessageValid(message, nameof(IsEmpty));
            try
            {
                if (arg.Value.Any())
                {
                    throw new ArgumentNullException();
                }
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
        public static IArg<IEnumerable<T>> IsNotEmpty<T>(this IArg<IEnumerable<T>> arg, string message)
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
