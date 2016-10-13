using System;
using Seterlund.CodeGuard;

namespace CubicleJockey.CodeGuardExtensions
{
    public static class ObjectExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arg"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static IArg<T> IsNull<T>(this IArg<T> arg, string message)
        {
            InternalHelpers.IsCustomMessageValid(message, nameof(IsNull));
            try
            {
                if (arg.Value != null)
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
        /// Extension method to IsNotNull and allows a custom message
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

        /// <summary>
        /// Extension method to IsNotDefault and allows a custom message.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arg"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static IArg<T> IsNotDefault<T>(this IArg<T> arg, string message)
        {
            InternalHelpers.IsCustomMessageValid(message, nameof(IsNotDefault));
            try
            {
                if(InternalHelpers.IsDefault(arg.Value))
                {
                    throw new ArgumentException();
                }
            }
            catch(Exception)
            {
                arg.Message.Set(message);
            }
            return arg;
        }

        /// <summary>
        /// Extension method to IsNotDefault and allows a custom message.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arg"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static IArg<T> IsDefault<T>(this IArg<T> arg, string message)
        {
            InternalHelpers.IsCustomMessageValid(message, nameof(IsDefault));
            try
            {
                if (!InternalHelpers.IsDefault(arg.Value))
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

        public static IArg<T> IsNotNullOrDefault<T>(this IArg<T> arg, string message)
        {
            InternalHelpers.IsCustomMessageValid(message, nameof(IsNotNullOrDefault));
            try
            {
                if (arg.Value == null || InternalHelpers.IsDefault(arg.Value))
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

        public static IArg<T> IsNullOrDefault<T>(this IArg<T> arg, string message)
        {
            InternalHelpers.IsCustomMessageValid(message, nameof(IsNullOrDefault));
            try
            {
                if (arg.Value != null || !InternalHelpers.IsDefault(arg.Value))
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
    }
}
