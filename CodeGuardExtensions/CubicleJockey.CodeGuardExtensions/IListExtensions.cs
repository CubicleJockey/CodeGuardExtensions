using System;
using System.Collections.Generic;
using Seterlund.CodeGuard;

namespace CubicleJockey.CodeGuardExtensions
{
    public static class IListExtensions
    {
        /// <summary>
        /// Extension method to IsNotEmpty which allows a custom message
        /// </summary>
        /// <param name="arg">Self</param>
        /// <param name="message">The Custom Message</param>
        /// <returns>Self</returns>
        public static IArg<IList<T>> IsNotEmpty<T>(this IArg<IList<T>> arg, string message)
        {
            InternalHelpers.IsCustomMessageValid(message, nameof(IsNotEmpty));
            try
            {
                if (arg.Value == null || arg.Value.Count == 0)
                {
                    throw new ArgumentException();
                }
            }
            catch (Exception)
            {
                arg.Message.Set(message);
            }
            return arg;
        }

        /// <summary>
        /// Extension method to IsEmpty which allows a custom message
        /// </summary>
        /// <param name="arg">Self</param>
        /// <param name="message">The Custom Message</param>
        /// <returns>Self</returns>
        public static IArg<IList<T>> IsEmpty<T>(this IArg<IList<T>> arg, string message)
        {
            InternalHelpers.IsCustomMessageValid(message, nameof(IsNotEmpty));
            try
            {
                if (arg.Value.Count != 0)
                {
                    throw new ArgumentException();
                }
            }
            catch (Exception)
            {
                arg.Message.Set(message);
            }
            return arg;
        } 
    }
}
