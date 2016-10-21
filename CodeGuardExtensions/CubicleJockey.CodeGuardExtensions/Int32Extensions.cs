using System;
using CubicleJockey.CodeGuardExtensions.Helpers;
using Seterlund.CodeGuard;

namespace CubicleJockey.CodeGuardExtensions
{
    public static class Int32Extensions
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

        /// <summary>
        /// Extension method to add a Custom Message to IsEven
        /// </summary>
        /// <param name="arg">Self</param>
        /// <param name="message">Custom Message</param>
        /// <returns>Self</returns>
        public static IArg<int> IsEven(this IArg<int> arg, string message)
        {
            InternalHelpers.IsCustomMessageValid(message, nameof(IsEven));
            try
            {
                Guard.That(arg.Value).IsEven();
            }
            catch(Exception)
            {
                arg.Message.Set(message);
            }
            return arg;
        }

        /// <summary>
        /// Extension method to add a Custom Message to IsOdd
        /// </summary>
        /// <param name="arg">Self</param>
        /// <param name="message">Custom Message</param>
        /// <returns>Self</returns>
        public static IArg<int> IsOdd(this IArg<int> arg, string message)
        {
            InternalHelpers.IsCustomMessageValid(message, nameof(IsOdd));
            try
            {
                Guard.That(arg.Value).IsOdd();
            }
            catch (Exception)
            {
                arg.Message.Set(message);
            }
            return arg;
        }

        /// <summary>
        /// Extension method to add a Custom Message to IsGreaterThan
        /// </summary>
        /// <param name="arg">Self</param>
        /// <param name="param">Value to compare against</param>
        /// <param name="message">Custom Message</param>
        /// <returns>Self</returns>
        public static IArg<int> IsGreaterThan(this IArg<int> arg, int param, string message)
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
        /// Extension method to add a Custom Message to IsGreaterThan
        /// </summary>
        /// <param name="arg">Self</param>
        /// <param name="param">Function to compare against</param>
        /// <param name="message">Custom Message</param>
        /// <returns>Self</returns>
        public static IArg<int> IsGreaterThan(this IArg<int> arg, Func<int> param, string message)
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
        /// Extension method to add a Custom Message to IsLessThan
        /// </summary>
        /// <param name="arg">Self</param>
        /// <param name="param">Value to compare against</param>
        /// <param name="message">Custom Message</param>
        /// <returns>Self</returns>
        public static IArg<int> IsLessThan(this IArg<int> arg, int param, string message)
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
        /// Extension method to add a Custom Message to IsLessThan
        /// </summary>
        /// <param name="arg">Self</param>
        /// <param name="param">Action to compare against</param>
        /// <param name="message">Custom Message</param>
        /// <returns>Self</returns>
        public static IArg<int> IsLessThan(this IArg<int> arg, Func<int> param, string message)
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
        /// Extension method to add a Custom Message to IsEqual
        /// </summary>
        /// <param name="arg">Self</param>
        /// <param name="param">Value to compare against</param>
        /// <param name="message">Custom Message</param>
        /// <returns>Self</returns>
        public static IArg<int> IsEqual(this IArg<int> arg, int param, string message)
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
        /// Extension method to add a Custom Message to IsEqual
        /// </summary>
        /// <param name="arg">Self</param>
        /// <param name="param">Function to compare against</param>
        /// <param name="message">Custom Message</param>
        /// <returns>Self</returns>
        public static IArg<int> IsEqual(this IArg<int> arg, Func<int> param, string message)
        {
            InternalHelpers.IsCustomMessageValid(message, nameof(IsEqual));
            try
            {
                Guard.That(arg.Value).IsEqual(param);
            }
            catch (Exception)
            {
                arg.Message.Set(message);
            }
            return arg;
        }

        /// <summary>
        /// Extension method to add a Custom Message to IsNotEqual
        /// </summary>
        /// <param name="arg">Self</param>
        /// <param name="param">Value to compare</param>
        /// <param name="message">Custom Message</param>
        /// <returns>Self</returns>
        public static IArg<int> IsNotEqual(this IArg<int> arg, int param, string message)
        {
            InternalHelpers.IsCustomMessageValid(message, nameof(IsNotEqual));
            try
            {
                Guard.That(arg.Value).IsNotEqual(param);
            }
            catch(Exception)
            {
                arg.Message.Set(message);
            }
            return arg;
        }

        /// <summary>
        /// Extension method to add a Custom Message to IsNotEqual
        /// </summary>
        /// <param name="arg">Self</param>
        /// <param name="param">Action to compare against</param>
        /// <param name="message">Custom Message</param>
        /// <returns>Self</returns>
        public static IArg<int> IsNotEqual(this IArg<int> arg, Func<int> param, string message)
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
        /// Extension method to add a Custom Message to IsInRange
        /// </summary>
        /// <param name="arg">Self</param>
        /// <param name="start">Starting Number of Range</param>
        /// <param name="end">Ending Number of Range</param>
        /// <param name="message">Custom Message</param>
        /// <returns>Self</returns>
        public static IArg<int> IsInRange(this IArg<int> arg, int start, int end, string message)
        {
            InternalHelpers.IsCustomMessageValid(message, nameof(IsInRange));
            try
            {
                Guard.That(arg.Value).IsInRange(start, end);
            }
            catch(Exception)
            {
                arg.Message.Set(message);
            }
            return arg;
        }

        /// <summary>
        /// Extension method to add a Custome Message to IsPrime
        /// </summary>
        /// <param name="arg">Self</param>
        /// <param name="message">Custom Message</param>
        /// <returns>Self</returns>
        public static IArg<int> IsPrime(this IArg<int> arg, string message)
        {
            InternalHelpers.IsCustomMessageValid(message, nameof(IsPrime));
            try
            {
                Guard.That(arg.Value).IsPrime();
            }
            catch(Exception)
            {
                arg.Message.Set(message);
            }
            return arg;
        }

        /// <summary>
        /// Extension method to add IsNotPrime
        /// </summary>
        /// <param name="arg">Self</param>
        /// <returns>Self</returns>
        public static IArg<int> IsNotPrime(this IArg<int> arg)
        {
            if(InternalHelpers.IsPrime(arg.Value))
            {
                throw new ArgumentException("Value cannot be prime.");
            }
            return arg;
        }

        /// <summary>
        /// Extension method to add a Custom Message to IsNotPrime
        /// </summary>
        /// <param name="arg">Self</param>
        /// <param name="message">Custom Message</param>
        /// <returns>Self</returns>
        public static IArg<int> IsNotPrime(this IArg<int> arg, string message)
        {
            InternalHelpers.IsCustomMessageValid(message, nameof(IsNotPrime));
            try
            {
                Guard.That(arg.Value).IsNotPrime();
            }
            catch(Exception)
            {
                arg.Message.Set(message);
            }
            return arg;
        }
    }
}
