using System;
using Seterlund.CodeGuard;

namespace CubicleJockey.CodeGuardExtensions
{
    public static class ObjectExtensions
    {
        /// <summary>
        /// Extension method to IsNotNull which allows a custom message
        /// </summary>
        /// <param name="arg">Self</param>
        /// <param name="message">The Custom Message</param>
        /// <returns>Self</returns>
        public static IArg<T> IsNotNull<T>(this IArg<T> arg, string message)
        {
            InternalHelpers.IsCustomMessageValid(message, nameof(IsNotNull));
            try
            {
                if (arg.Value == null)
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

        //public static IArg<T> IsNotNullOrDefault<T>(this IArg<T> arg, string message)
        //{
        //    InternalHelpers.IsCustomMessageValid(message, nameof(IsNotNull));
        //    try
        //    {
        //        if (arg.Value == null || arg.Value == default(T))
        //        {
        //            throw new ArgumentNullException();
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        arg.Message.Set(message);
        //    }
        //    return arg;
        //}
    }
}
