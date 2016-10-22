using System;
using System.Collections.Generic;
using System.Linq;
using CubicleJockey.CodeGuardExtensions.Helpers;
using Seterlund.CodeGuard;

namespace CubicleJockey.CodeGuardExtensions
{
    public static class IListExtensions
    {
        /// <summary>
        /// Extension method that fills in the missing IList<T>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arg"></param>
        /// <returns></returns>
        public static IArg<IList<T>> IsNotEmpty<T>(this IArg<IList<T>> arg)
        {
            try
            {
                Guard.That(arg.Value.AsEnumerable()).IsNotEmpty();
            }
            catch (Exception)
            {
                arg.Message.Set($"IList<{typeof(T).Name}> should be empty.");
            }
            return arg;
        } 

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
                Guard.That(arg.Value.AsEnumerable()).IsNotEmpty();
            }
            catch (Exception)
            {
                arg.Message.Set(message);
            }
            return arg;
        }

        /// <summary>
        /// IsEmpty is missing from Code Guard
        /// </summary>
        /// <typeparam name="T">IListT </typeparam>
        /// <param name="arg">Self</param>
        /// <returns>Self</returns>
        public static IArg<IList<T>> IsEmpty<T>(this IArg<IList<T>> arg)
        {
            try
            {
                Guard.That(arg.Value.AsEnumerable()).IsEmpty();
            }
            catch (Exception)
            {
                arg.Message.Set("IList contains items when it should not.");
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
    }
}