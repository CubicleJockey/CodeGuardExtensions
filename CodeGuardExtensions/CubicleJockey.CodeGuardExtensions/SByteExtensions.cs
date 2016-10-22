using System;
using CubicleJockey.CodeGuardExtensions.Helpers;
using Seterlund.CodeGuard;

namespace CubicleJockey.CodeGuardExtensions
{
    public static class SByteExtensions
    {

        /// <summary>
        /// Extensions method to add IsPositive
        /// </summary>
        /// <param name="arg">Self</param>
        /// <returns>Self</returns>
        public static IArg<sbyte> IsPositive(this IArg<sbyte> arg)
        {
            if(arg.Value < 0)
            {
                throw new ArgumentException("Value has to be positive.");
            }
            return arg;
        }

        /// <summary>
        /// Extensions method to add a Custom Message to IsPositive
        /// </summary>
        /// <param name="arg">Self</param>
        /// <param name="message">Custom Message</param>
        /// <returns>Self</returns>
        public static IArg<sbyte> IsPositive(this IArg<sbyte> arg, string message)
        {
            InternalHelpers.IsCustomMessageValid(message, nameof(IsPositive));
            try
            {
                Guard.That(arg.Value).IsPositive();
            }
            catch (Exception)
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
        public static IArg<sbyte> IsNegative(this IArg<sbyte> arg, string message)
        {
            InternalHelpers.IsCustomMessageValid(message, nameof(IsNegative));
            try
            {
                Guard.That(arg.Value).IsNegative();
            }
            catch (Exception)
            {
                arg.Message.Set(message);
            }
            return arg;
        }

        /// <summary>
        /// Extension method to add IsNegative
        /// </summary>
        /// <param name="arg">Self</param>
        /// <returns>Self</returns>
        public static IArg<sbyte> IsNegative(this IArg<sbyte> arg)
        {
            if (arg.Value >= 0)
            {
                throw new ArgumentException("Value cannot be positive.");
            }
            return arg;
        }

        /// <summary>
        /// Extension method to add IsEven
        /// </summary>
        /// <param name="arg">Self</param>
        /// <returns>Self</returns>
        public static IArg<sbyte> IsEven(this IArg<sbyte> arg)
        {
            if (arg.Value % 2 != 0)
            {
                throw new ArgumentException("Value must be even.");
            }
            return arg;
        }

        /// <summary>
        /// Extension method to add a Custom Message to IsEven
        /// </summary>
        /// <param name="arg">Self</param>
        /// <param name="message">Custom Message</param>
        /// <returns>Self</returns>
        public static IArg<sbyte> IsEven(this IArg<sbyte> arg, string message)
        {
            InternalHelpers.IsCustomMessageValid(message, nameof(IsEven));
            try
            {
                Guard.That(arg.Value).IsEven();
            }
            catch (Exception)
            {
                arg.Message.Set(message);
            }
            return arg;
        }

        /// <summary>
        /// Extension method to add a IsOdd
        /// </summary>
        /// <param name="arg">Self</param>
        /// <returns>Self</returns>
        public static IArg<sbyte> IsOdd(this IArg<sbyte> arg)
        {
            if (arg.Value % 2 == 0)
            {
                throw new ArgumentException("Value must be odd.");
            }
            return arg;
        }

        /// <summary>
        /// Extension method to add a Custom Message to IsOdd
        /// </summary>
        /// <param name="arg">Self</param>
        /// <param name="message">Custom Message</param>
        /// <returns>Self</returns>
        public static IArg<sbyte> IsOdd(this IArg<sbyte> arg, string message)
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
        public static IArg<sbyte> IsGreaterThan(this IArg<sbyte> arg, sbyte param, string message)
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
        /// Extension method to add a Custom Message to IsGreaterThan
        /// </summary>
        /// <param name="arg">Self</param>
        /// <param name="param">Function to compare against</param>
        /// <param name="message">Custom Message</param>
        /// <returns>Self</returns>
        public static IArg<sbyte> IsGreaterThan(this IArg<sbyte> arg, Func<sbyte> param, string message)
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
        /// Extension method to add a Custom Message to IsLessThan
        /// </summary>
        /// <param name="arg">Self</param>
        /// <param name="param">Value to compare against</param>
        /// <param name="message">Custom Message</param>
        /// <returns>Self</returns>
        public static IArg<sbyte> IsLessThan(this IArg<sbyte> arg, sbyte param, string message)
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
        public static IArg<sbyte> IsLessThan(this IArg<sbyte> arg, Func<sbyte> param, string message)
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
        public static IArg<sbyte> IsEqual(this IArg<sbyte> arg, sbyte param, string message)
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
        /// Extension method to add a Custom Message to IsEqual
        /// </summary>
        /// <param name="arg">Self</param>
        /// <param name="param">Function to compare against</param>
        /// <param name="message">Custom Message</param>
        /// <returns>Self</returns>
        public static IArg<sbyte> IsEqual(this IArg<sbyte> arg, Func<sbyte> param, string message)
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
        public static IArg<sbyte> IsNotEqual(this IArg<sbyte> arg, sbyte param, string message)
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
        /// Extension method to add a Custom Message to IsNotEqual
        /// </summary>
        /// <param name="arg">Self</param>
        /// <param name="param">Action to compare against</param>
        /// <param name="message">Custom Message</param>
        /// <returns>Self</returns>
        public static IArg<sbyte> IsNotEqual(this IArg<sbyte> arg, Func<sbyte> param, string message)
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
        public static IArg<sbyte> IsInRange(this IArg<sbyte> arg, sbyte start, sbyte end, string message)
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

        /// <summary>
        /// Extension method to add a Custome Message to IsPrime
        /// </summary>
        /// <param name="arg">Self</param>
        /// <returns>Self</returns>
        public static IArg<sbyte> IsPrime(this IArg<sbyte> arg)
        {
            if (!InternalHelpers.IsPrime(arg.Value))
            {
                throw new ArgumentException("Value cannot be Non-Prime.");
            }
            return arg;
        }

        /// <summary>
        /// Extension method to add a Custome Message to IsPrime
        /// </summary>
        /// <param name="arg">Self</param>
        /// <param name="message">Custom Message</param>
        /// <returns>Self</returns>
        public static IArg<sbyte> IsPrime(this IArg<sbyte> arg, string message)
        {
            InternalHelpers.IsCustomMessageValid(message, nameof(IsPrime));
            try
            {
                Guard.That(arg.Value).IsPrime();
            }
            catch (Exception)
            {
                arg.Message.Set(message);
            }
            return arg;
        }

        /// <summary>
        /// Extension method to add a Custome Message to IsNotPrime
        /// </summary>
        /// <param name="arg">Self</param>
        /// <returns>Self</returns>
        public static IArg<sbyte> IsNotPrime(this IArg<sbyte> arg)
        {
            if (InternalHelpers.IsPrime(arg.Value))
            {
                throw new ArgumentException("Value cannot be Prime.");
            }
            return arg;
        }

        /// <summary>
        /// Extension method to add a Custome Message to IsNotPrime
        /// </summary>
        /// <param name="arg">Self</param>
        /// <param name="message">Custom Message</param>
        /// <returns>Self</returns>
        public static IArg<sbyte> IsNotPrime(this IArg<sbyte> arg, string message)
        {
            InternalHelpers.IsCustomMessageValid(message, nameof(IsNotPrime));
            try
            {
                Guard.That(arg.Value).IsNotPrime();
            }
            catch (Exception)
            {
                arg.Message.Set(message);
            }
            return arg;
        }
    }
}